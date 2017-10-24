using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SQLite.Net.Attributes;
using Xamarin.Forms.Internals;

namespace Diabetes.localDB
{
    public class SetReminder
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string alarm_time { get; set; }
        public string unique_id { get; set; }
        public string username { get; set; }
        public string insulin_type { get; set; }
        public string units { get; set; }
        public string status { get; set; }
        public string count_times { get; set; }
        public string Count { get { return CountTimes(); } }
        public string AlarmList { get { return AlarmConvert(); } set { AlarmConvert(); } }


        public string AlarmConvert()
        {

            MedicationDatabase db = new MedicationDatabase();
            var r = db.GetAlarmList();
            //var alarm_result = JsonConvert.SerializeObject(r).ToString().Replace("[", "").Replace("]", "");
			//var list = new List<string> { "12", "13", "14" };
			//var result = string.Join(",", list);
            var final = string.Join(",", r);
            //final.Replace(",","\n");
            Debug.WriteLine("Output : " + final.Replace(",","\n"));


            return final.Replace(",", "\n");


        }


        public string CountTimes()
        {
            MedicationDatabase db = new MedicationDatabase();
            var r = db.GetAlarmList();

            var alarm_result = JsonConvert.SerializeObject(r);
            JObject jObj = (JObject)JsonConvert.DeserializeObject(alarm_result);
            int count = jObj.Count;

            return "" + "2" + " Time(s) dialy";
        }
        public SetReminder()
        {
        }
    }
}
