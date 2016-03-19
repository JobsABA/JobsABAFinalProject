using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsInABA.Web.Models
{
    public class CompanyDataModel
    {
        public int BusinessID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public int BusinessTypeID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> insuser { get; set; }
        public Nullable<System.DateTime> insdt { get; set; }
        public Nullable<int> upduser { get; set; }
        public Nullable<System.DateTime> upddt { get; set; }
        
        public string Title { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public Nullable<int> CountryID { get; set; }
        public Nullable<int> AddressTypeID { get; set; }

        public string Address { get; set; }
        public Nullable<int> EmailTypeID { get; set; }

        public string Number { get; set; }
        public string Ext { get; set; }
        public Nullable<int> PhoneTypeID { get; set; }
    }
}