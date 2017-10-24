using System;
using SQLite.Net.Attributes;

namespace Diabetes.localDB
{
    public class TrackTaken
    {
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string taken { get; set; }
    }
}
