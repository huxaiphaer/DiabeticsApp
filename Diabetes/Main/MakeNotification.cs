using System;
using System.Diagnostics;
using Diabetes.localDB;
using Xamarin.Forms;

namespace Diabetes.Main
{
    public class MakeNotification
    {


        public MakeNotification()
        {
        }

        public void MakeAlarm()
        {
            // Setting the Alarm time 
            MedicationDatabase db = new MedicationDatabase();
            var alarm_list = db.GetAlarmList();
            //Debug.WriteLine(" Time -- : "+ m.ToString());
            foreach (var list in alarm_list)
            {
                var hour = Int32.Parse(list.Substring(0, 2));
                var min = Int32.Parse(list.Substring(3, 2));
                Debug.WriteLine("Hour : " + hour + "\n");
                Debug.WriteLine("Minute   " + min + "\n");
                try
                {
                    DependencyService.Get<ISetAlarm>().SetAlarm(hour, min, "Diabetics App", "Hello i remind you to take medicine");
                }
                catch (FormatException v)
                {
                    Debug.WriteLine("Format Exception : " + v);
                }
                catch (OverflowException c)
                {
                    Debug.WriteLine("Overflow Exception : " + c);
                }
                catch(NullReferenceException en){
					Debug.WriteLine("Overflow Exception : " + en);

				}
            }

        }
    }
}
