using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySelectionChatbot;
namespace EasySelectionChatbotUnitTest
{
    public class DataInput:IDataInput
    {
        public List<string> UserInputs = new List<string>();
        public int count;
        public DataInput(List<string> userInputs)
        {
            UserInputs = userInputs;
            count = 0;
        }
        public string getInput()
        {
            return UserInputs[count++];
        }
    }
}
