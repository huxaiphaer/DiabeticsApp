using System;
namespace Diabetes.Main
{
    public interface ISetAlarm
    {
		void SetAlarm(int hour, int minute,string message , string title);
    }
}
