using System;
using SQLite.Net.Attributes;

namespace Diabetes.localDB
{
    public class Medication
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string unique_id { get; set; }
        public string username { get; set; }
        public string insulin_type { get; set; }
        public string units { get; set; }
        public string status { get; set; }

        public string alarm_time { get; set; }
        public Medication()
        {
        }
    }
}
