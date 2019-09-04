using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InputReaderContractsLib;
using SelectedItemsContractLib;
using DataAccessLayerContractLib;
using LoggerContractsLib;

namespace ChatBotProcessorLib
{
    public class ChatBotProcessor
    {
        IInputReaderContract ReaderRef;
        ISelectedItemsContract SelectionRef;
        IDataAccessLayerContract DataRef;
        ILoggerContract LoggerRef;
        Dictionary<int, string> AnswerDictionary = new Dictionary<int, string>();
        int feature_no = 1;

        public ChatBotProcessor(IInputReaderContract readerRef, ISelectedItemsContract selectionRef, IDataAccessLayerContract dataRef, ILoggerContract loggerRef)
        {
            this.ReaderRef = readerRef;
            this.SelectionRef = selectionRef;
            this.DataRef = dataRef;
            this.LoggerRef = loggerRef;
        }
        public void ProcessChatBot()
        {
            var FeaturesDictionary = DataRef.ReadAttributes();
            List<string> SelectedItems;
            //For Each Feature from 1st to Last Question
            for (int i = 1; i < FeaturesDictionary.Count() - 1; i++)
            {
                string input = "";
                var list = new List<string>();
                //For First Question Reading  
                if (i == 1)
                {
                    var Options = DataRef.ReadData(FeaturesDictionary, null, i);
                    if (Options.Count() > 0)
                    {
                        foreach (var option in Options)
                        {
                            list.Add(option);
                        }
                        QuestionSelection(FeaturesDictionary, i, list);
                        int index = OptionsDisplay(Options);
                        LoggerRef.Write(string.Format("\n!!!! Or else Choose Default options!!!! \n{0}: {1}\n{2}: {3}\n{4}: {5}\n", ++index, DefaultFeatures.Display_Items, ++index, DefaultFeatures.Start_Again, ++index, DefaultFeatures.Exit_the_Application));
                        int option_choosen = OptionCheck(index);

                        //Display the Selected Items
                        if (option_choosen == list.Count() + 1)
                        {
                            SelectedItems = SelectionRef.GetAllSelectedItems("FirstFeature", "FirstValue");
                            DisplayItems(SelectedItems);
                            i = i - 1;
                        }

                        //Start Again from the Home
                        else if (option_choosen == list.Count() + 2)
                        {
                            i = StartAgain();
                        }

                        //Aborting the Application
                        else if (option_choosen == list.Count() + 3)
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
                    var Options = DataRef.ReadData(FeaturesDictionary, AnswerDictionary, i);
                    if (Options.Count() > 0)
                    {
                        foreach (var option in Options)
                        {
                            list.Add(option);
                        }
                        QuestionSelection(FeaturesDictionary, i, list);
                        int index = OptionsDisplay(Options);
                        LoggerRef.Write(string.Format("\n\n!!!! Or else Choose Default options!!!! \n{0}: {1}\n{2}: {3}\n{4}: {5}\n{6}: {7}\n", ++index, DefaultFeatures.Display_Items, ++index, DefaultFeatures.Start_Again, ++index, DefaultFeatures.Back, ++index, DefaultFeatures.Exit_the_Application));
                        int option_choosen = OptionCheck(index);

                        //Display the Selected Items
                        if (option_choosen == list.Count() + 1)
                        {
                            SelectedItems = SelectionRef.GetAllSelectedItems(FeaturesDictionary[feature_no], AnswerDictionary[feature_no]);
                            DisplayItems(SelectedItems);
                            i = i - 1;
                        }

                        //Start Again from the Home
                        else if (option_choosen == list.Count() + 2)
                        {
                            i = StartAgain();
                        }

                        //Back to the previous question
                        else if (option_choosen == list.Count() + 3)
                        {
                            i = BackPropagation(feature_no);
                        }

                        //Aborting the Application
                        else if (option_choosen == list.Count() + 4)
                        {
                            ExitApplication();

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
            SelectedItems = SelectionRef.GetAllSelectedItems(FeaturesDictionary[feature_no], AnswerDictionary[feature_no]);

            DisplayItems(SelectedItems);
            LoggerRef.Write("\n---------------------------------!!!!! Thank you for your Interaction !!!!!---------------------------------\n      ---------------------------------------!!!!! VISIT AGAIN !!!!!---------------------------------");
        }

        private int BackPropagation(int index)
        {
            AnswerDictionary.Remove(feature_no);
            int i = index - 1;
            if (i != 0)
                feature_no = AnswerDictionary.Keys.Max();
            return i;
        }

        private int OptionCheck(int index)
        {
            int option_choosen;
            while (true)
            {
                option_choosen = ReaderRef.ReadInput();
                if (option_choosen > 0 && option_choosen <= index)
                    break;
                else
                    LoggerRef.Write("!!!! Choose the Valid Option !!!!\n");
            }

            return option_choosen;
        }

        private int OptionsDisplay(List<string> Options)
        {
            int index = 0;
            foreach (var option in Options)
            {
                LoggerRef.Write(string.Format("{0}:{1} ", ++index, option));
            }
            return index;
        }

        private void QuestionSelection(Dictionary<int, string> FeaturesDictionary, int i, List<string> list)
        {
            if (list.Contains("true") || list.Contains("false"))
            {
                LoggerRef.Write(string.Format("Do you want '{0}' ?", FeaturesDictionary[i].ToUpper()));
            }
            else
            {
                LoggerRef.Write(string.Format("Choose the following '{0}' options:", FeaturesDictionary[i].ToUpper()));
            }
        }

        private void ExitApplication()
        {
            LoggerRef.Write("\n---------------------------------!!!!! Thank you for your Interaction !!!!!---------------------------------\n       ---------------------------------------!!!!! VISIT AGAIN !!!!!---------------------------------");
            Console.ReadKey();
            System.Environment.Exit(1);
        }

        private int StartAgain()
        {
            AnswerDictionary.Clear();
            feature_no = 1;
            return 0;
        }

        private void DisplayItems(List<string> selectedItems)
        {
            foreach (var selectedItem in selectedItems)
            {
                LoggerRef.Write(selectedItem);
            }
        }
    }
}
