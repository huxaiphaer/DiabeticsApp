using System;
using SQLite.Net.Attributes;

namespace Diabetes.localDB
{
    public class TrackMissed
    {
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string missed { get; set; }
    }
}
