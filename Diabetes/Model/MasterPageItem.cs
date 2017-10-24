using System;
namespace Diabetes.Model
{
    public class MasterPageItem
    {
		public string Title { get; set; }
		public string IconSource { get; set; }
		public Type TargetType { get; set; }
		public MasterPageItem()
		{
		}
    }
}
