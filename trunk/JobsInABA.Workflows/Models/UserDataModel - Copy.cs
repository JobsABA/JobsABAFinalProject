using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace JobsInABA.Workflows.Models
{
    [DataContract()]
    public class UserDataModel
    {
        [DataMember()]
        public Int32 UserID { get; set; }

        [DataMember()]
        public String UserName { get; set; }

        [DataMember()]
        public String FirstName { get; set; }

        [DataMember()]
        public String MiddleName { get; set; }

        [DataMember()]
        public String LastName { get; set; }

        [DataMember()]
        public Nullable<DateTime> DOB { get; set; }

        [DataMember()]
        public Boolean IsActive { get; set; }

        [DataMember()]
        public Boolean IsDeleted { get; set; }

        [DataMember()]
        public Nullable<Int32> insuser { get; set; }

        [DataMember()]
        public Nullable<DateTime> insdt { get; set; }

        [DataMember()]
        public Nullable<Int32> upduser { get; set; }

        [DataMember()]
        public Nullable<DateTime> upddt { get; set; }

        [DataMember()]
        public Int32 PrimaryUserAddressID { get; set; }

        [DataMember()]
        public Int32 PrimayAddress_AddressID { get; set; }

        [DataMember()]
        public String PrimaryAddressTitle { get; set; }

        [DataMember()]
        public String PrimaryAddressLine1 { get; set; }

        [DataMember()]
        public String PrimaryAddressLine2 { get; set; }

        [DataMember()]
        public String PrimaryAddressLine3 { get; set; }

        [DataMember()]
        public String PrimaryAddressCity { get; set; }

        [DataMember()]
        public String PrimaryAddressState { get; set; }

        [DataMember()]
        public String PrimaryAddressZipCode { get; set; }

        [DataMember()]
        public Nullable<Int32> PrimaryAddressCountryID { get; set; }

        [DataMember()]
        public String PrimaryAddressCountryName { get; set; }

        [DataMember()]
        public String PrimaryAddressCountryAbbreviation { get; set; }

        [DataMember()]
        public String PrimaryAddressCountryCode { get; set; }

        [DataMember()]
        public String PrimaryAddressCountryPhoneCode { get; set; }

        [DataMember()]
        public Nullable<Int32> PrimaryAddressTypeID { get; set; }

        [DataMember()]
        public String PrimaryAddressTypeName { get; set; }

        [DataMember()]
        public String PrimaryAddressTypeCode { get; set; }

        [DataMember()]
        public String PrimaryAddressTypeDescription { get; set; }

        [DataMember()]
        public Int32 PrimaryAddressTypeClassTypeID { get; set; }

        [DataMember()]
        public Int32 PrimaryUserEmailID { get; set; }

        [DataMember()]
        public Int32 PrimaryEmail_EmailID { get; set; }

        [DataMember()]
        public String PrimaryEmailAddress { get; set; }

        [DataMember()]
        public Nullable<Int32> PrimaryEmailTypeID { get; set; }

        [DataMember()]
        public String PrimaryEmailTypeName { get; set; }

        [DataMember()]
        public String PrimaryEmailTypeCode { get; set; }

        [DataMember()]
        public String PrimaryEmailTypeDescription { get; set; }

        [DataMember()]
        public Int32 PrimaryEmailTypeClassTypeID { get; set; }

        [DataMember()]
        public Int32 PrimaryUserPhoneID { get; set; }

        [DataMember()]
        public Int32 PrimaryPhone_PhoneID { get; set; }

        [DataMember()]
        public String PrimaryPhoneNumber { get; set; }

        [DataMember()]
        public String PrimaryPhoneExt { get; set; }

        [DataMember()]
        public Nullable<Int32> PrimaryPhoneTypeID { get; set; }

        [DataMember()]
        public String PrimaryPhoneTypeName { get; set; }

        [DataMember()]
        public String PrimaryPhoneTypeCode { get; set; }

        [DataMember()]
        public String PrimaryPhoneTypeDescription { get; set; }

        [DataMember()]
        public Int32 PrimaryPhoneTypeClassTypeID { get; set; }

        [DataMember()]
        public IEnumerable<AddressDataModel> Addresses { get; set; }

    }
}
