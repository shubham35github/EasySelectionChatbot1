using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using System.IO;

namespace EasySelectionChatbot
{
    public class EasySelectionChatBot:IEasySelectionChatbot,IDataInput
    {
        //Dictionary for storing the Answer of with questions_no
        Dictionary<int, string> AnswerDictionary = new Dictionary<int, string>();
        int feature_no = 1;

        //Reading the column from DB and mapping to Feature Dictionary 
        public Dictionary<int,string> ReadProductAttributes()
        {
            Dictionary<int, string> FeaturesDictionary = new Dictionary<int, string>();
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
            return FeaturesDictionary;
        }

        // Filtering the Question from Feature dictionary and Storing the Option in Answer Dictionary using DB
        public Dictionary<int, string> ProcessChatbotFeatures(IDataInput dataInput, Dictionary<int,string> FeaturesDictionary)
        {
            List<string> SelectedItems;
            using (ChatbotModalDataContext dbcontext = new ChatbotModalDataContext())
            {
                //For Each Feature from 1st to Last Question
                for (int i = 1; i < FeaturesDictionary.Count()-1; i++)
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
                                Console.WriteLine("Do you want '{0}' ?", FeaturesDictionary[i].ToUpper());
                            }
                            else
                            {
                                Console.WriteLine("Choose from the following '{0}' options:", FeaturesDictionary[i].ToUpper());
                            }
                            int index = 0;
                            foreach (var option in Options)
                            {
                                Console.Write("{0}: ", ++index);
                                Console.WriteLine(option);
                            }
                            Console.Write("{0}: {1}\n{2}: {3}\n{4}: {5}\n", ++index,DefaultFeatures.Display_Filtered_Items.ToString().Replace('_',' '), ++index,DefaultFeatures.Start_Again.ToString().Replace('_', ' '), ++index,DefaultFeatures.Exit_the_Application.ToString().Replace('_', ' '));
                            bool valid = false;
                            int option_choosen = 0;
                            while(valid==false)
                            {
                                input = dataInput.getInput();
                                if (int.TryParse(input, out option_choosen))
                                {
                                    if(option_choosen>0 && option_choosen<=index)
                                        valid = true;
                                    else
                                        Console.WriteLine("!!!! Choose the Valid Option !!!!\n");
                                }
                                else
                                    Console.WriteLine("!!!! Choose the Valid Option !!!!\n");
                            }

                            //Display the Selected Items
                            if (option_choosen == list.Count() + 1)
                            {
                                SelectedItems = SelectItems("FirstFeature", "FirstValue");
                                DisplayItems(SelectedItems);
                                i = i - 1;
                            }

                            //Start Again from the Home
                            else if(option_choosen==list.Count() + 2)
                            {
                                i = StartAgain();
                            }

                            //Aborting the Application
                            else if(option_choosen == list.Count() + 3)
                            {
                                ExitApplication();
                                //return null;
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
                                Console.WriteLine("\nDo you want '{0}' ?", FeaturesDictionary[i].ToUpper());
                            }
                            else
                            {
                                Console.WriteLine("\nChoose from the following '{0}' options:", FeaturesDictionary[i].ToUpper());
                            }
                            int index = 0;
                            foreach (var option in Options)
                            {
                                Console.Write("{0}: ", ++index);
                                Console.WriteLine(option);
                            }
                            Console.Write("{0}: {1}\n{2}: {3}\n{4}: {5}\n{6}: {7}\n", ++index, DefaultFeatures.Display_Filtered_Items.ToString().Replace('_',' '), ++index, DefaultFeatures.Start_Again.ToString().Replace('_', ' '), ++index,DefaultFeatures.Back_To_Previous_Question.ToString().Replace('_', ' '), ++index, DefaultFeatures.Exit_the_Application.ToString().Replace('_', ' '));
                            bool valid = false;
                            int option_choosen = 0;
                            while (valid == false)
                            {
                                input =dataInput.getInput();

                                if (int.TryParse(input, out option_choosen))
                                {
                                    if (option_choosen > 0 && option_choosen <= index)
                                        valid = true;
                                    else
                                        Console.WriteLine("!!!! Please Choose the Valid Option !!!!\n");
                                }
                                else
                                    Console.WriteLine("!!!! Please Choose the Valid Option !!!!\n");
                            }

                            //Display the Selected Items
                            if (option_choosen == list.Count() + 1)
                            {
                                SelectedItems = SelectItems(FeaturesDictionary[feature_no], AnswerDictionary[feature_no]);
                                DisplayItems(SelectedItems);
                                i = i - 1;
                            }

                            //Start Again from the Home
                            else if (option_choosen == list.Count()+2)
                            {
                                i=StartAgain();
                            }

                            //Back to the previous question
                            else if(option_choosen==list.Count()+3)
                            {
                                i=BackPropagation(feature_no);
                            }

                            //Aborting the Application
                            else if (option_choosen == list.Count() + 4)
                            {
                                ExitApplication();
                               // return null;
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
                SelectedItems = SelectItems(FeaturesDictionary[feature_no], AnswerDictionary[feature_no]);
                
                DisplayItems(SelectedItems);
                Console.WriteLine("\n---------------------------------!!!!! Thank you for your Interaction, Hope I was able to assist you here. !!!!!----------\n      ---------------------------------------!!!!! HAVE A NICE DAY VISIT AGAIN !!!!!---------------------------------");
                return AnswerDictionary;
            }
        }

        //Return the Selected Monitors
        public List<string> SelectItems(string Feature, string FeatureValue)
        {
            List<string> Selectedlist = new List<string>();
            if (!Feature.Equals(String.Empty) || !FeatureValue.Equals(String.Empty))
            {
                using (ChatbotModalDataContext dbcontext = new ChatbotModalDataContext())
                {
                    if (Feature.Equals("FirstFeature") && FeatureValue.Equals("FirstValue"))
                    {
                        var Selectedtems = dbcontext.ChatbotTable_s.Select("monitors_name");
                        foreach (var Item in Selectedtems)
                        {
                            Selectedlist.Add(Item.ToString());
                        }
                    }
                    else
                    {
                        var Selectedtems = dbcontext.ChatbotTable_s.Where(Feature + "=\"" + FeatureValue + "\"").Select("monitors_name");
                        foreach (var Item in Selectedtems)
                        {
                            Selectedlist.Add(Item.ToString());
                        }
                    }
                }
            }
            else
                throw new Exception("String Empty");
            return Selectedlist;
        }

        //Display the selected Monitors
        void DisplayItems(List<string> SelectedItems)
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Here are some Items Suggestions for you : \n");
            foreach (var Monitors in SelectedItems)
            {
                Console.WriteLine(Monitors);
            }
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine();

        }

        //Reverse to the previous Question
        int BackPropagation(int index)
        {
            AnswerDictionary.Remove(feature_no);
            int i = index - 1;
            if (i != 0)
                feature_no = AnswerDictionary.Keys.Max();
            return i;
        }

        //Back to home
        int StartAgain()
        {
            AnswerDictionary.Clear();
            feature_no = 1;
            return 0;
        }

        //Exit the Application
        void ExitApplication()
        {
            Console.WriteLine("\n---------------------------------!!!!! Thank you for your Interaction, Hope I was able to assist you here. !!!!!---------\n      ---------------------------------------!!!!! HAVE A NICE DAY VISIT AGAIN !!!!!---------------------------------");
            Console.ReadKey();
            System.Environment.Exit(1);
        }

        public string getInput()
        {
            return Console.ReadLine();
        }
    }
}
