﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using System.IO;

namespace EasySelectionChatbot
{
    class EasySelectionChatbot:IEasySelectionChatbot
    {
        Dictionary<int, string> FeaturesDictionary = new Dictionary<int, string>();
        Dictionary<int, string> AnswerDictionary = new Dictionary<int, string>();


        //Creating the Feature Dictionary from DB
        void IEasySelectionChatbot.CreateFeatureDictionary()
        {
            using (ChatbotModalDataContext dbcontext = new ChatbotModalDataContext())
            {
                var columnnames = from t in typeof(ChatbotTable_).GetProperties() select t.Name;
                int i = 0;
                foreach (var c in columnnames)
                {
                    FeaturesDictionary.Add(i, c.ToString());
                    i = i + 1;
                }
            }
        }

        // Filtering the Question from Feature dictionary and Storing the Option in Answer Dictionary using DB
        void IEasySelectionChatbot.ReadDatabase(IEasySelectionChatbot easySelectionChatbot)
        {
            using (ChatbotModalDataContext dbcontext = new ChatbotModalDataContext())
            {
                int feature_no = 1;

                //For Each Feature from 1st to Last Question
                for (int i = 1; i < FeaturesDictionary.Count-1; i++)
                {
                    string input="";
                    var list = new List<string>();
                    
                    //For First Question Reading  
                    if (i == 1)
                    {
                        var Options = dbcontext.ChatbotTable_s.Where(FeaturesDictionary[i] + "!=\"" + null + "\"").Select(FeaturesDictionary[i]).Distinct();
                        if (Options.Count() > 0)
                        {
                            foreach (var option in Options)
                            {
                                list.Add(option.ToString());
                            }
                            if (list.Contains("true") || list.Contains("false"))
                            {
                                Console.WriteLine("\nDo you want {0} :", FeaturesDictionary[i]);
                            }
                            else
                            {
                                Console.WriteLine("\nChoose the following {0} options:", FeaturesDictionary[i]);
                            }
                            int index = 0;
                            foreach (var option in Options)
                            {
                                Console.Write("{0}: ", ++index);
                                Console.WriteLine(option);
                            }
                            Console.Write("\n!!!! Or else Choose Default options!!!! \n{0}: {1}\n{2}: {3}\n{4}: {5}\n", ++index,DefaultFeatures.Display_Items,++index,DefaultFeatures.Start_Again ,++index,DefaultFeatures.Exit_the_Application);
                            bool valid = false;
                            int option_choosen = 0;
                            while(valid==false)
                            {
                                input = Console.ReadLine();
                                if (int.TryParse(input, out option_choosen))
                                {
                                    if(option_choosen>0 && option_choosen<=index)
                                        valid = true;
                                    else
                                        Console.WriteLine("!!!! Choose the Valid Option !!!!");
                                }
                                else
                                    Console.WriteLine("!!!! Choose the Valid Option !!!!");
                            }

                            //Display the Selected Items
                            if (option_choosen == list.Count() + 1)
                            {
                                easySelectionChatbot.DisplayItems("FirstFeature", "FirstValue");
                                i = i - 1;
                            }

                            //Start Again from the Home
                            else if(option_choosen==list.Count() + 2)
                            {
                                i = 0;
                                AnswerDictionary.Clear();
                                feature_no = 1;
                            }

                            //Aborting the Application
                            else if(option_choosen == list.Count() + 3)
                            {
                                Console.WriteLine("!!!!! Thank you for Interaction !!!!!\n !!!!! VISIT AGAIN !!!!");
                                return;
                            }

                            //Storing the option for next question
                            else
                                AnswerDictionary.Add(i, list[option_choosen - 1]);
                        }
                    }
                    else
                    {
                        var Options = dbcontext.ChatbotTable_s.Where(FeaturesDictionary[feature_no] + "=\"" + AnswerDictionary[feature_no] + "\"").Where(FeaturesDictionary[i] + "!=\"" + null + "\"").Select(FeaturesDictionary[i]).Distinct();
                        if (Options.Count()>0)
                        {
                            foreach (var option in Options)
                            {
                                list.Add(option.ToString());
                            }
                            if (list.Contains("true") || list.Contains("false"))
                            {
                                Console.WriteLine("\nDo you want {0} :", FeaturesDictionary[i]);
                            }
                            else
                            {
                                Console.WriteLine("\nChoose the following {0} options:", FeaturesDictionary[i]);
                            }
                            int index = 0;
                            foreach (var option in Options)
                            {
                                Console.Write("{0}: ", ++index);
                                Console.WriteLine(option);
                            }
                            Console.Write("\n\n!!!! Or else Choose Default options!!!! \n{0}: {1}\n{2}: {3}\n{4}: {5}\n", ++index, DefaultFeatures.Display_Items, ++index, DefaultFeatures.Start_Again, ++index, DefaultFeatures.Exit_the_Application);
                            bool valid = false;
                            int option_choosen = 0;
                            while (valid == false)
                            {
                                input = Console.ReadLine();
                                if (int.TryParse(input, out option_choosen))
                                {
                                    if (option_choosen > 0 && option_choosen <= index)
                                        valid = true;
                                    else
                                        Console.WriteLine("!!!! Choose the Valid Option !!!!");
                                }
                                else
                                    Console.WriteLine("!!!! Choose the Valid Option !!!!");
                            }

                            //Display the Selected Items
                            if (option_choosen == list.Count() + 1)
                            {
                                easySelectionChatbot.DisplayItems(FeaturesDictionary[feature_no], AnswerDictionary[feature_no]);
                                i = i - 1;
                            }

                            //Start Again from the Home
                            else if (option_choosen == list.Count()+2)
                            {
                                i = 0;
                                AnswerDictionary.Clear();
                                feature_no = 1;
                            }

                            //Aborting the Application
                            else if (option_choosen == list.Count() + 3)
                            {
                                Console.WriteLine("!!!!! Thank you for Interaction !!!!!\n !!!!! VISIT AGAIN !!!!");
                                return;
                            }

                            //Storing the option for next question
                            else
                            {
                                AnswerDictionary.Add(i, list[option_choosen - 1]);
                                feature_no = i;
                            }
                        }
                    }
                }
                easySelectionChatbot.DisplayItems(FeaturesDictionary[feature_no], AnswerDictionary[feature_no]);
            }
        }

        //Displaying the Selected Monitors
        void IEasySelectionChatbot.DisplayItems(string Feature, string FeatureValue)
        {
            
       
            using (ChatbotModalDataContext dbcontext = new ChatbotModalDataContext())
            {
                string pk = "monitors_name";
                if (Feature.Equals("FirstFeature") && FeatureValue.Equals("FirstValue"))
                {
                    var linquery = dbcontext.ChatbotTable_s.Select(pk);
                    Console.WriteLine("The Items which meet your Requirnment are : ");
                    foreach (var c in linquery)
                    {
                        Console.WriteLine(c.ToString());
                    }
                }
                else
                {
                    var linquery = dbcontext.ChatbotTable_s.Where(Feature + "=\"" + FeatureValue + "\"").Select(pk);
                    Console.WriteLine("The Items which meet your Requirnment are : ");
                    foreach (var c in linquery)
                    {
                        Console.WriteLine(c.ToString());

                    }
                }
                
            }
        }
        void IEasySelectionChatbot.BackPropagation()
        {
            throw new NotImplementedException();
        }
    }
}
