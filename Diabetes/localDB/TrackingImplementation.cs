using System;
namespace Diabetes.localDB
{
    public class TrackingImplementation : ISetTrack
    {
      
        public void addtrackdetails(string taken, string cancelled)
        {
            MedicationDatabase db = new MedicationDatabase();
           // db.addtrackdetails(taken,cancelled);
        }
    }
}
