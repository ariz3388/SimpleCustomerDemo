using System;
using System.Collections.Generic;

#nullable disable

namespace SimpleCustomerDemo.Database
{
    public partial class PostalState
    {
        public int Id { get; set; }
        public string StateCode { get; set; }
        public string StateFullName { get; set; }
        public bool? IsCanadian { get; set; }
    }
}
