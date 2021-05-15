using System;
using System.Collections.Generic;

#nullable disable

namespace SimpleCustomerDemo.Database
{
    public partial class EventLog
    {
        public int Id { get; set; }
        public string LogType { get; set; }
        public string LogMessage { get; set; }
        public string LogDetails { get; set; }
        public DateTime? LogTimeStamp { get; set; }
    }
}
