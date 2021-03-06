//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/02/22 - 20:58:30
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace JobsInABA.BL.DTOs
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
        public String Description { get; set; }

        [DataMember()]
        public Int32 BusinessTypeID { get; set; }

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
        public List<AchievementDTO> Achievements { get; set; }

        [DataMember()]
        public List<Int32> Achievements_AchievementID { get; set; }

        [DataMember()]
        public List<BusinessAddressDTO> BusinessAddresses { get; set; }

        [DataMember()]
        public List<Int32> BusinessAddresses_BusinessAddressID { get; set; }

        [DataMember()]
        public List<BusinessEmailDTO> BusinessEmails { get; set; }

        [DataMember()]
        public List<Int32> BusinessEmails_BusinessEmailID { get; set; }

        [DataMember()]
        public TypeCodeDTO TypeCode { get; set; }

        [DataMember()]
        public Int32 TypeCode_TypeCodeID { get; set; }

        [DataMember()]
        public UserDTO User { get; set; }

        [DataMember()]
        public Int32 User_UserID { get; set; }

        [DataMember()]
        public Int32 User1_UserID { get; set; }

        [DataMember()]
        public List<BusinessImageDTO> BusinessImages { get; set; }

        [DataMember()]
        public List<Int32> BusinessImages_BusinessImageID { get; set; }

        [DataMember()]
        public List<BusinessPhoneDTO> BusinessPhones { get; set; }

        [DataMember()]
        public List<Int32> BusinessPhones_BusinessPhoneID { get; set; }

        [DataMember()]
        public List<BusinessUserMapDTO> BusinessUserMaps { get; set; }

        [DataMember()]
        public List<Int32> BusinessUserMaps_BusinessUserMapID { get; set; }

        [DataMember()]
        public List<ExperienceDTO> Experiences { get; set; }

        [DataMember()]
        public List<Int32> Experiences_ExperienceID { get; set; }

        [DataMember()]
        public List<JobDTO> Jobs { get; set; }

        [DataMember()]
        public List<Int32> Jobs_JobID { get; set; }

        [DataMember()]
        public List<ServiceDTO> Services { get; set; }

        [DataMember()]
        public List<Int32> Services_ServiceID { get; set; }

        public BusinessDTO()
        {
        }

        public BusinessDTO(Int32 businessID, String name, String abbreviation, Nullable<DateTime> startDate, String description, Int32 businessTypeID, Boolean isActive, Boolean isDeleted, Nullable<Int32> insuser, Nullable<DateTime> insdt, Nullable<Int32> upduser, Nullable<DateTime> upddt, List<Int32> achievements_AchievementID, List<Int32> businessAddresses_BusinessAddressID, List<Int32> businessEmails_BusinessEmailID, Int32 typeCode_TypeCodeID, Int32 user_UserID, Int32 user1_UserID, List<Int32> businessImages_BusinessImageID, List<Int32> businessPhones_BusinessPhoneID, List<Int32> businessUserMaps_BusinessUserMapID, List<Int32> experiences_ExperienceID, List<Int32> jobs_JobID, List<Int32> services_ServiceID)
        {
			this.BusinessID = businessID;
			this.Name = name;
			this.Abbreviation = abbreviation;
			this.StartDate = startDate;
			this.Description = description;
			this.BusinessTypeID = businessTypeID;
			this.IsActive = isActive;
			this.IsDeleted = isDeleted;
			this.insuser = insuser;
			this.insdt = insdt;
			this.upduser = upduser;
			this.upddt = upddt;
			this.Achievements_AchievementID = achievements_AchievementID;
			this.BusinessAddresses_BusinessAddressID = businessAddresses_BusinessAddressID;
			this.BusinessEmails_BusinessEmailID = businessEmails_BusinessEmailID;
			this.TypeCode_TypeCodeID = typeCode_TypeCodeID;
			this.User_UserID = user_UserID;
			this.User1_UserID = user1_UserID;
			this.BusinessImages_BusinessImageID = businessImages_BusinessImageID;
			this.BusinessPhones_BusinessPhoneID = businessPhones_BusinessPhoneID;
			this.BusinessUserMaps_BusinessUserMapID = businessUserMaps_BusinessUserMapID;
			this.Experiences_ExperienceID = experiences_ExperienceID;
			this.Jobs_JobID = jobs_JobID;
			this.Services_ServiceID = services_ServiceID;
        }
    }
}
