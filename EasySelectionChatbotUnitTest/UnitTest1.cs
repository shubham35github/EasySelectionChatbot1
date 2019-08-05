using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EasySelectionChatbot;
using System.Collections.Generic;
namespace EasySelectionChatbotUnitTest
{
    [TestClass]
    public class UnitTest1
    {

        //Test case for Reading the DB and storing it into Dictionary 
        [TestMethod]
        public void ReadProductAttributesTest1()
        {
            EasySelectionChatBot easySelectionChatbot = new EasySelectionChatBot();
            Dictionary<int, string> FeatureDictionaryActual = easySelectionChatbot.ReadProductAttributes();
            Dictionary<int, string> FeatureDictionaryExpected = new Dictionary<int, string>();
            FeatureDictionaryExpected.Add(0, "monitors_no");
            FeatureDictionaryExpected.Add(1, "measurment");
            FeatureDictionaryExpected.Add(2, "touchscreen");
            FeatureDictionaryExpected.Add(3, "category");
            FeatureDictionaryExpected.Add(4, "portablity_true");
            FeatureDictionaryExpected.Add(5, "feature_true");
            FeatureDictionaryExpected.Add(6, "size_true");
            FeatureDictionaryExpected.Add(7, "feature_2");
            FeatureDictionaryExpected.Add(8, "feature_3");
            FeatureDictionaryExpected.Add(9, "portablity_2");
            FeatureDictionaryExpected.Add(10, "ante/intrapartum");
            FeatureDictionaryExpected.Add(11, "display_mode");
            FeatureDictionaryExpected.Add(12, "weights");
            FeatureDictionaryExpected.Add(13, "feature_4");
            FeatureDictionaryExpected.Add(14, "invasive_bp");
            FeatureDictionaryExpected.Add(15, "co2_measurment");
            FeatureDictionaryExpected.Add(16, "nbp_measurment");
            FeatureDictionaryExpected.Add(17, "speed");
            FeatureDictionaryExpected.Add(18, "storage_size");
            FeatureDictionaryExpected.Add(19, "monitors_name");
            foreach (int key in FeatureDictionaryExpected.Keys)
            {
                StringAssert.Equals(FeatureDictionaryExpected[key], FeatureDictionaryActual[key]);
            }
        }

        //Unit Test cases for Process Chatbot 
        [TestMethod]
        public void ProcessChatbotFeaturesTest1()
        {
            List<string> Inputs = new List<string>();
            Inputs.Add("5");
            Inputs.Add("2");
            Inputs.Add("5");
            EasySelectionChatBot easySelectionChatbot = new EasySelectionChatBot();
            Dictionary<int, string> FeatureDictionary = easySelectionChatbot.ReadProductAttributes();
            Dictionary<int, string> AnswerDictionaryActual = easySelectionChatbot.ProcessChatbotFeatures(new DataInput(Inputs), FeatureDictionary);
            Dictionary<int, string> AnswerDictionaryExcpected = new Dictionary<int, string>();
            AnswerDictionaryExcpected.Add(1, "Vitals and ECG");
            AnswerDictionaryExcpected.Add(2, "true");
            AnswerDictionaryExcpected.Add(3, "Telemetry");
            foreach (int key in AnswerDictionaryExcpected.Keys)
            {
                StringAssert.Equals(AnswerDictionaryExcpected[key], AnswerDictionaryActual[key]);
            }
        }
        [TestMethod]
        public void ProcessChatbotFeaturesTest2()
        {
            List<string> Inputs = new List<string>();
            Inputs.Add("5");
            Inputs.Add("2");
            Inputs.Add("1");
            Inputs.Add("2");
            Inputs.Add("2");
            Inputs.Add("2");
            EasySelectionChatBot easySelectionChatbot = new EasySelectionChatBot();
            Dictionary<int, string> FeatureDictionary = easySelectionChatbot.ReadProductAttributes();
            Dictionary<int, string> AnswerDictionaryActual = easySelectionChatbot.ProcessChatbotFeatures(new DataInput(Inputs), FeatureDictionary);
            Dictionary<int, string> AnswerDictionaryExcpected = new Dictionary<int, string>();
            AnswerDictionaryExcpected.Add(1, "Vitals and ECG");
            AnswerDictionaryExcpected.Add(2, "true");
            AnswerDictionaryExcpected.Add(3, "Bedside");
            AnswerDictionaryExcpected.Add(4, "Portable");
            AnswerDictionaryExcpected.Add(6, "Medium(10-12)");
            AnswerDictionaryExcpected.Add(8, "Integrated PC");
            foreach (int key in AnswerDictionaryExcpected.Keys)
            {
                StringAssert.Equals(AnswerDictionaryExcpected[key], AnswerDictionaryActual[key]);
            }
        }
        [TestMethod]
        public void ProcessChatbotFeaturesTest3()
        {
            List<string> Inputs = new List<string>();
            Inputs.Add("3");

            EasySelectionChatBot easySelectionChatbot = new EasySelectionChatBot();
            Dictionary<int, string> FeatureDictionary = easySelectionChatbot.ReadProductAttributes();
            Dictionary<int, string> AnswerDictionaryActual = easySelectionChatbot.ProcessChatbotFeatures(new DataInput(Inputs), FeatureDictionary);
            Dictionary<int, string> AnswerDictionaryExcpected = new Dictionary<int, string>();
            AnswerDictionaryExcpected.Add(1, "Cost Effective Monitoring");

            foreach (int key in AnswerDictionaryExcpected.Keys)
            {
                StringAssert.Equals(AnswerDictionaryExcpected[key], AnswerDictionaryActual[key]);
            }
        }
        [TestMethod]
        public void ProcessChatbotFeaturesTest4()
        {
            List<string> Inputs = new List<string>();
            Inputs.Add("4");
            Inputs.Add("1");
            Inputs.Add("1");
            EasySelectionChatBot easySelectionChatbot = new EasySelectionChatBot();
            Dictionary<int, string> FeatureDictionary = easySelectionChatbot.ReadProductAttributes();
            Dictionary<int, string> AnswerDictionaryActual = easySelectionChatbot.ProcessChatbotFeatures(new DataInput(Inputs), FeatureDictionary);
            Dictionary<int, string> AnswerDictionaryExcpected = new Dictionary<int, string>();
            AnswerDictionaryExcpected.Add(1, "Vitals");
            AnswerDictionaryExcpected.Add(16, "true");
            AnswerDictionaryExcpected.Add(17, "Fast");
            foreach (int key in AnswerDictionaryExcpected.Keys)
            {
                StringAssert.Equals(AnswerDictionaryExcpected[key], AnswerDictionaryActual[key]);
            }
        }
        [TestMethod]
        public void ProcessChatbotFeaturesTest5_Back()
        {
            List<string> Inputs = new List<string>();
            Inputs.Add("5");
            Inputs.Add("2");
            Inputs.Add("8");
            Inputs.Add("1");
            Inputs.Add("1");
            EasySelectionChatBot easySelectionChatbot = new EasySelectionChatBot();
            Dictionary<int, string> FeatureDictionary = easySelectionChatbot.ReadProductAttributes();
            Dictionary<int, string> AnswerDictionaryActual = easySelectionChatbot.ProcessChatbotFeatures(new DataInput(Inputs), FeatureDictionary);
            Dictionary<int, string> AnswerDictionaryExcpected = new Dictionary<int, string>();
            AnswerDictionaryExcpected.Add(1, "Vitals and ECG");
            AnswerDictionaryExcpected.Add(2, "false");
            AnswerDictionaryExcpected.Add(14, "false");

            foreach (int key in AnswerDictionaryExcpected.Keys)
            {
                StringAssert.Equals(AnswerDictionaryExcpected[key], AnswerDictionaryActual[key]);
            }
        }
        [TestMethod]
        public void ProcessChatbotFeaturesTest6_Back2()
        {
            List<string> Inputs = new List<string>();
            Inputs.Add("5");
            Inputs.Add("2");
            Inputs.Add("8");
            Inputs.Add("5");
            Inputs.Add("3");
            EasySelectionChatBot easySelectionChatbot = new EasySelectionChatBot();
            Dictionary<int, string> FeatureDictionary = easySelectionChatbot.ReadProductAttributes();
            Dictionary<int, string> AnswerDictionaryActual = easySelectionChatbot.ProcessChatbotFeatures(new DataInput(Inputs), FeatureDictionary);
            Dictionary<int, string> AnswerDictionaryExcpected = new Dictionary<int, string>();
            AnswerDictionaryExcpected.Add(1, "Cost Effective Monitoring");



            foreach (int key in AnswerDictionaryExcpected.Keys)
            {
                StringAssert.Equals(AnswerDictionaryExcpected[key], AnswerDictionaryActual[key]);
            }
        }
        [TestMethod]
        public void ProcessChatbotFeaturesTest7_start()
        {
            List<string> Inputs = new List<string>();
            Inputs.Add("5");
            Inputs.Add("2");
            Inputs.Add("7");
            Inputs.Add("3");
            EasySelectionChatBot easySelectionChatbot = new EasySelectionChatBot();
            Dictionary<int, string> FeatureDictionary = easySelectionChatbot.ReadProductAttributes();
            Dictionary<int, string> AnswerDictionaryActual = easySelectionChatbot.ProcessChatbotFeatures(new DataInput(Inputs), FeatureDictionary);
            Dictionary<int, string> AnswerDictionaryExcpected = new Dictionary<int, string>();
            AnswerDictionaryExcpected.Add(1, "Cost Effective Monitoring");



            foreach (int key in AnswerDictionaryExcpected.Keys)
            {
                StringAssert.Equals(AnswerDictionaryExcpected[key], AnswerDictionaryActual[key]);
            }
        }

        //Unit Test Cases for Selected Items When Feature and Feature value is Empty
        [TestMethod]
        public void SelectItemsTest1()
        {
            EasySelectionChatBot easySelectionChatbot = new EasySelectionChatBot();
            var exceptionThrown = false;
            try
            {
                List<string> SelectedlistActual = easySelectionChatbot.SelectItems("", "");
            }
            catch(Exception)
            {
                exceptionThrown = true;
            }
            if(!exceptionThrown)
            {
                throw new AssertFailedException("Exception Failed due to Null String");
            }
            
        }

        //Unit Test Cases for All Display Selected Items 
        [TestMethod]
        public void SelectItemsTest2()
        {
            EasySelectionChatBot easySelectionChatbot = new EasySelectionChatBot();
            List<string> SelectedlistActual = easySelectionChatbot.SelectItems("FirstFeature", "FirstValue");
            List<string> SelectedlistExcpected = new List<string>();
            SelectedlistExcpected.Add("Intellivue MP5T");
            SelectedlistExcpected.Add("Intellivue MMS X2");
            SelectedlistExcpected.Add("Intellivue guardian solution");
            SelectedlistExcpected.Add("Intellivue MM5 SC");
            SelectedlistExcpected.Add("Intellivue MMX40");
            SelectedlistExcpected.Add("Intellivue MP90");
            SelectedlistExcpected.Add("Intellivue MX700");
            SelectedlistExcpected.Add("Intellivue MP5");
            SelectedlistExcpected.Add("Intellivue MX550");
            SelectedlistExcpected.Add("Intellivue MP2");
            SelectedlistExcpected.Add("Intellivue MX400");
            SelectedlistExcpected.Add("Intellivue MX800");
            SelectedlistExcpected.Add("Intellivue MX450");
            SelectedlistExcpected.Add("Intellivue MX500");
            SelectedlistExcpected.Add("Avalon CL");
            SelectedlistExcpected.Add("Avalon FM20");
            SelectedlistExcpected.Add("Avalon FM40");
            SelectedlistExcpected.Add("Avalon FM50");
            SelectedlistExcpected.Add("Avalon FM30");
            SelectedlistExcpected.Add("Efficia CMS200");
            SelectedlistExcpected.Add("IntelliSpace Alarm Reporting");
            SelectedlistExcpected.Add("IntelliVue Information Center iX");
            SelectedlistExcpected.Add("IntelliSpace Event Management");
            SelectedlistExcpected.Add("Suresight VM6");
            SelectedlistExcpected.Add("Suresight VM4");
            SelectedlistExcpected.Add("Suresight VM8");
            SelectedlistExcpected.Add("Suresight VSI");
            SelectedlistExcpected.Add("Suresight VM2+");
            SelectedlistExcpected.Add("Suresight VM4");
            SelectedlistExcpected.Add("Suresight VM3");
            SelectedlistExcpected.Add("Suresight VM1");
            for(int i=0;i<SelectedlistExcpected.Count;i++)
            {
                StringAssert.Equals(SelectedlistExcpected[i], SelectedlistActual[i]);
            }
        }

        //Unit Test Cases for Display Selected Items When Features their Feature value is Selected
        [TestMethod]
        public void SelectItemsTest3()
        {
            EasySelectionChatBot easySelectionChatbot = new EasySelectionChatBot();
            List<string> SelectedlistActual = easySelectionChatbot.SelectItems("category", "Bedside");
            List<string> SelectedlistExcpected = new List<string>();
            SelectedlistExcpected.Add("Intellivue MMX40");
            SelectedlistExcpected.Add("Intellivue MP90");
            SelectedlistExcpected.Add("Intellivue MX700");
            SelectedlistExcpected.Add("Intellivue MP5");
            SelectedlistExcpected.Add("Intellivue MX550");
            SelectedlistExcpected.Add("Intellivue MP2");
            SelectedlistExcpected.Add("Intellivue MX400");
            SelectedlistExcpected.Add("Intellivue MX800");
            SelectedlistExcpected.Add("Intellivue MX450");
            SelectedlistExcpected.Add("Intellivue MX500");
            for (int i = 0; i < SelectedlistExcpected.Count; i++)
            {
                StringAssert.Equals(SelectedlistExcpected[i], SelectedlistActual[i]);
            }
        }

    }
}
