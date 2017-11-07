using System;
namespace Diabetes.Main
{
    public interface ISetMyAlarm
    {
        void MakeAlarm(int hour, int minute, string title, string message);
    }
}
