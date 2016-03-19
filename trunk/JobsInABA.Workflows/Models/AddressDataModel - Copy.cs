using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace JobsInABA.Workflows.Models
{
    public class AddressDataModel
    {
        [DataMember()]
        public Int32 AddressID { get; set; }

        [DataMember()]
        public String Title { get; set; }

        [DataMember()]
        public String Line1 { get; set; }

        [DataMember()]
        public String Line2 { get; set; }

        [DataMember()]
        public String Line3 { get; set; }

        [DataMember()]
        public String City { get; set; }

        [DataMember()]
        public String State { get; set; }

        [DataMember()]
        public String ZipCode { get; set; }

        [DataMember()]
        public Boolean AddressIsPrimary { get; set; }

        [DataMember()]
        public Nullable<Int32> AddressCountryID { get; set; }

        [DataMember()]
        public String AddressCountryName { get; set; }

        [DataMember()]
        public String AddressCountryAbbreviation { get; set; }

        [DataMember()]
        public String AddressCountryCode { get; set; }

        [DataMember()]
        public String AddressCountryPhoneCode { get; set; }

        [DataMember()]
        public Nullable<Int32> AddressTypeID { get; set; }

        [DataMember()]
        public String AddressTypeName { get; set; }

        [DataMember()]
        public String AddressTypeCode { get; set; }

        [DataMember()]
        public String AddressTypeDescription { get; set; }

        [DataMember()]
        public Int32 AddressTypeClassTypeID { get; set; }
    }
}
