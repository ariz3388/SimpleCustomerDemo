using System;
using Newtonsoft.Json;

#nullable disable

namespace SimpleCustomerDemo.Database
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }

        [JsonProperty(PropertyName = "State")]
        public string StateCode { get; set; }

        [JsonProperty(PropertyName = "PostalCode")]
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
