using System;
using SQLite.Net.Attributes;

namespace Diabetes.localDB
{
    public class Track
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string taken { get; set; }
        public string cancelled { get; set; }

    }
}
