using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Glene.API.Models
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
    public class CustomerCustomerDemo
    {
        //public Customer Customer { get; set; }
        public string CustomerID { get; set; }
        //public CustomerDemographics CustomerDemographics { get; set; }
        public string CustomerTypeID { get; set; }
    }
}