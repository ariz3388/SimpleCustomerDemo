using System;

namespace SimpleCustomerDemo.Logic
{
    public class Logging
    {
        private Database.CustomerDemoContext db;

        public Logging(Database.CustomerDemoContext dataContext)
        {
            db = dataContext;
        }

        public void LogException(Exception ex)
        {
            Database.EventLog obj = new Database.EventLog();
            obj.LogType = "ERROR";
            obj.LogMessage = ex.Message;
            obj.LogDetails = ex.ToString();

            db.Add(obj);
            db.SaveChangesAsync();
        }
    }
}
