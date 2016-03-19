using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace JobsInABA.Core.DTOs
{
    [DataContract()]
    public partial class BusinessDTO
    {
        [DataMember()]
        public Int32 BusinessID { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public String Abbreviation { get; set; }

        [DataMember()]
        public Nullable<DateTime> StartDate { get; set; }
        
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
        public Int32 BusinessTypeID { get; set; }

        [DataMember()]
        public String BusinessTypeName { get; set; }

        [DataMember()]
        public String BusinessTypeCode { get; set; }

        [DataMember()]
        public String BusinessTypeDescription { get; set; }

        [DataMember()]
        public Int32 BusinessTypeClassTypeID { get; set; }

        [DataMember()]
        public Int32 BusinessTypeParentTypeCodeID { get; set; }

        [DataMember()]
        public Int32 BusinessAddressID { get; set; }
        
        [DataMember()]
        public Int32 BusinessAddress_AddressID { get; set; }

        [DataMember()]
        public String BusinessAddressTitle { get; set; }

        [DataMember()]
        public String BusinessAddressLine1 { get; set; }

        [DataMember()]
        public String BusinessAddressLine2 { get; set; }

        [DataMember()]
        public String BusinessAddressLine3 { get; set; }

        [DataMember()]
        public String BusinessAddressCity { get; set; }

        [DataMember()]
        public String BusinessAddressState { get; set; }

        [DataMember()]
        public String BusinessAddressZipCode { get; set; }

        [DataMember()]
        public Boolean BusinessAddressIsPrimary { get; set; }

        [DataMember()]
        public Nullable<Int32> BusinessAddressCountryID { get; set; }

        [DataMember()]
        public String BusinessAddressCountryName { get; set; }

        [DataMember()]
        public String BusinessAddressCountryAbbreviation { get; set; }

        [DataMember()]
        public String BusinessAddressCountryCode { get; set; }

        [DataMember()]
        public String BusinessAddressCountryPhoneCode { get; set; }

        [DataMember()]
        public Nullable<Int32> BusinessAddressTypeID { get; set; }

        [DataMember()]
        public String BusinessAddressTypeName { get; set; }

        [DataMember()]
        public String BusinessAddressTypeCode { get; set; }

        [DataMember()]
        public String BusinessAddressTypeDescription { get; set; }

        [DataMember()]
        public Int32 BusinessAddressTypeClassTypeID { get; set; }

        [DataMember()]
        public Int32 BusinessEmailID { get; set; }

        [DataMember()]
        public Int32 BusinessEmail_EmailID { get; set; }

        [DataMember()]
        public Boolean BusinessEmailIsPrimary { get; set; }
        
        [DataMember()]
        public String BusinessEmailAddress { get; set; }

        [DataMember()]
        public Nullable<Int32> BusinessEmailTypeID { get; set; }

        [DataMember()]
        public String BusinessEmailTypeName { get; set; }

        [DataMember()]
        public String BusinessEmailTypeCode { get; set; }

        [DataMember()]
        public String BusinessEmailTypeDescription { get; set; }

        [DataMember()]
        public Int32 BusinessEmailTypeClassTypeID { get; set; }

        [DataMember()]
        public Int32 BusinessPhoneID { get; set; }

        [DataMember()]
        public Int32 BusinessPhone_PhoneID { get; set; }

        [DataMember()]
        public Boolean BusinessPhoneIsPrimary { get; set; }
        
        [DataMember()]
        public String BusinessPhoneNumber { get; set; }

        [DataMember()]
        public String BusinessPhoneExt { get; set; }

        [DataMember()]
        public Nullable<Int32> BusinessPhoneTypeID { get; set; }

        [DataMember()]
        public String BusinessPhoneTypeName { get; set; }

        [DataMember()]
        public String BusinessPhoneTypeCode { get; set; }

        [DataMember()]
        public String BusinessPhoneTypeDescription { get; set; }

        [DataMember()]
        public Int32 BusinessPhoneTypeClassTypeID { get; set; }

        /*
        [DataMember()]
        public List<BusinessUserMapDTO> BusinessUserMaps { get; set; }

        [DataMember()]
        public List<JobDTO> Jobs { get; set; }
        

        public BusinessDTO()
        {
        }

        public BusinessDTO(Int32 businessID, String name, String abbreviation, Nullable<DateTime> startDate, Int32 businessTypeID, Boolean isActive, Boolean isDeleted, Nullable<Int32> insuser, Nullable<DateTime> insdt, Nullable<Int32> upduser, Nullable<DateTime> upddt, C_TypeCodesDTO c_TypeCodes, UserDTO user, UserDTO user1, List<BusinessAddressDTO> businessAddresses, List<BusinessEmailDTO> businessEmails, List<BusinessPhoneDTO> businessPhones, List<BusinessUserMapDTO> businessUserMaps, List<JobDTO> jobs)
        {
			this.BusinessID = businessID;
			this.Name = name;
			this.Abbreviation = abbreviation;
			this.StartDate = startDate;
			//this.BusinessTypeID = businessTypeID;
			this.IsActive = isActive;
			this.IsDeleted = isDeleted;
			this.insuser = insuser;
			this.insdt = insdt;
			this.upduser = upduser;
			this.upddt = upddt;
			//this.C_TypeCodes = c_TypeCodes;
			//this.User = user;
			//this.User1 = user1;
			//this.BusinessAddresses = businessAddresses;
			//this.BusinessEmails = businessEmails;
			//this.BusinessPhones = businessPhones;
			//this.BusinessUserMaps = businessUserMaps;
			//this.Jobs = jobs;
        }
        */
    }
}
