using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelectedItemsContractLib;
using ChatBotModelLib;
using System.Data.Linq;
using System.Linq.Dynamic;

namespace SelectMonitorsLib
{
    public class SelectMonitors : ISelectedItemsContract
    {
        public List<string> GetAllSelectedItems(string Feature, string FeatureValue)
        {
            List<string> Selectedlist = new List<string>();
            if (!Feature.Equals(string.Empty) || !FeatureValue.Equals(string.Empty))
            {
                using (ChatBotDataModelDataContext dbcontext = new ChatBotDataModelDataContext())
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
                throw new ArgumentException("String Empty");
            return Selectedlist;
        }
    }
}

