using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerContractLib
{
    public interface IDataAccessLayerContract
    {
        Dictionary<int, string> ReadAttributes();
        List<string> ReadData(Dictionary<int, string> FeaturesDictionary, Dictionary<int, string> AnswerDictionary, int QuestionNumber);
    }
}
