using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsInABA.Workflows.Models
{
    public class BussinessDataModel
    {
        public int BusinessID { get; set; }
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

        public string BusinessTypeName { get; set; }
        public string BusinessTypeCode { get; set; }
        public string BusinessTypeDescription { get; set; }
        public int BusinessTypeClassTypeID { get; set; }
        public Nullable<int> BusinessTypeParentTypeCodeID { get; set; }
    
        public int BusinessAddressID { get; set; }
        public int BusinessPrimaryAddressID { get; set; }
        
        public int BusinessEmailID { get; set; }
        public int BusinessPrimaryEmailID { get; set; }
        
        public int BusinessPhoneID { get; set; }
        public int BusinessPrimaryPhoneID { get; set; }
        
        public int BusinessUserMapID { get; set; }
        public int BusinessOwnerUserID { get; set; }
        public Nullable<int> BusinessOwnerUserTypeID { get; set; }

        public string BussinessAddressTitle { get; set; }
        public string BussinessAddressLine1 { get; set; }
        public string BussinessAddressLine2 { get; set; }
        public string BussinessAddressLine3 { get; set; }
        public string BussinessAddressCity { get; set; }
        public string BussinessAddressState { get; set; }
        public string BussinessAddressZipCode { get; set; }
        public Nullable<int> BussinessAddressCountryID { get; set; }
        public Nullable<int> BussinessAddressTypeID { get; set; }

        public string BussinessAddressTypeName { get; set; }
        public string BussinessAddressTypeCode { get; set; }
        public string BussinessAddressTypeDescription { get; set; }
        public int BussinessAddressTypeClassTypeID { get; set; }
        public Nullable<int> BussinessAddressTypeParentTypeCodeID { get; set; }
  
        public string BussinessCountryName { get; set; }
        public string BussinessCountryAbbreviation { get; set; }
        public string BussinessCountryCode { get; set; }
        public string BussinessCountryPhoneCode { get; set; }

        public string BussinessEmailAddress { get; set; }
        public Nullable<int> BussinessEmailTypeID { get; set; }

        public string BussinessEmailTypeName { get; set; }
        public string BussinessEmailTypeCode { get; set; }
        public string BussinessEmailTypeDescription { get; set; }
        public int BussinessEmailTypeClassTypeID { get; set; }
        public Nullable<int> BussinessEmailTypeParentTypeCodeID { get; set; }
    
        public Nullable<int> BussinessPhoneCountryID { get; set; }
        public string BussinessPhoneNumber { get; set; }
        public string BussinessPhoneNumberExt { get; set; }
        public Nullable<int> BussinessPhoneTypeID { get; set; }

        public string BussinessPhoneTypeName { get; set; }
        public string BussinessPhoneTypeCode { get; set; }
        public string BussinessPhoneTypeDescription { get; set; }
        public int BussinessPhoneTypeClassTypeID { get; set; }
        public Nullable<int> BussinessPhoneTypeParentTypeCodeID { get; set; }
    
    }
}
