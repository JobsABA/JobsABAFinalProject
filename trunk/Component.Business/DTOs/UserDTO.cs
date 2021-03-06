﻿//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/02/22 - 20:58:43
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
    public partial class UserDTO
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
        public String Description { get; set; }

        [DataMember()]
        public IEnumerable<AchievementDTO> Achievements { get; set; }

        [DataMember()]
        public List<Int32> Achievements_AchievementID { get; set; }

        [DataMember()]
        public IEnumerable<BusinessDTO> Businesses { get; set; }

        [DataMember()]
        public List<Int32> Businesses_BusinessID { get; set; }

        [DataMember()]
        public List<Int32> Businesses1_BusinessID { get; set; }

        [DataMember()]
        public BusinessUserMapDTO BusinessUserMaps { get; set; }

        [DataMember()]
        public List<Int32> BusinessUserMaps_BusinessUserMapID { get; set; }

        [DataMember()]
        public IEnumerable<EducationDTO> Educations { get; set; }

        [DataMember()]
        public List<Int32> Educations_EducationID { get; set; }

        [DataMember()]
        public IEnumerable<ExperienceDTO> Experiences { get; set; }

        [DataMember()]
        public List<Int32> Experiences_ExperienceID { get; set; }

        [DataMember()]
        public IEnumerable<JobApplicationDTO> JobApplications { get; set; }

        [DataMember()]
        public List<Int32> JobApplications_JobApplicationID { get; set; }

        [DataMember()]
        public IEnumerable<LanguageDTO> Languages { get; set; }

        [DataMember()]
        public List<Int32> Languages_LanguageID { get; set; }

        [DataMember()]
        public IEnumerable<SkillDTO> Skills { get; set; }

        [DataMember()]
        public List<Int32> Skills_SkillID { get; set; }

        [DataMember()]
        public IEnumerable<UserAccountDTO> UserAccounts { get; set; }

        [DataMember()]
        public List<Int32> UserAccounts_UserAccountID { get; set; }

        [DataMember()]
        public IEnumerable<UserAddressDTO> UserAddresses { get; set; }

        [DataMember()]
        public List<Int32> UserAddresses_UserAddressID { get; set; }

        [DataMember()]
        public IEnumerable<UserEmailDTO> UserEmails { get; set; }

        [DataMember()]
        public List<Int32> UserEmails_UserEmailID { get; set; }

        [DataMember()]
        public IEnumerable<UserImageDTO> UserImages { get; set; }

        [DataMember()]
        public List<Int32> UserImages_UserImageID { get; set; }

        [DataMember()]
        public IEnumerable<UserPhoneDTO> UserPhone { get; set; }

        [DataMember()]
        public List<Int32> UserPhones_UserPhoneID { get; set; }

        [DataMember()]
        public IEnumerable<UserRoleDTO> UserRoles { get; set; }

        [DataMember()]
        public List<Int32> UserRoles_UserRoleID { get; set; }

        [DataMember()]
        public List<Int32> Users1_UserID { get; set; }

        [DataMember()]
        public Int32 User1_UserID { get; set; }

        [DataMember()]
        public List<Int32> Users11_UserID { get; set; }

        [DataMember()]
        public Int32 User2_UserID { get; set; }

        public UserDTO()
        {
        }

        public UserDTO(Int32 userID, String userName, String firstName, String middleName, String lastName, Nullable<DateTime> dOB, Boolean isActive, Boolean isDeleted, Nullable<Int32> insuser, Nullable<DateTime> insdt, Nullable<Int32> upduser, Nullable<DateTime> upddt, String description, List<Int32> achievements_AchievementID, List<Int32> businesses_BusinessID, List<Int32> businesses1_BusinessID, List<Int32> businessUserMaps_BusinessUserMapID, List<Int32> educations_EducationID, List<Int32> experiences_ExperienceID, List<Int32> jobApplications_JobApplicationID, List<Int32> languages_LanguageID, List<Int32> skills_SkillID, List<Int32> userAccounts_UserAccountID, List<Int32> userAddresses_UserAddressID, List<Int32> userEmails_UserEmailID, List<Int32> userImages_UserImageID, List<Int32> userPhones_UserPhoneID, List<Int32> userRoles_UserRoleID, List<Int32> users1_UserID, Int32 user1_UserID, List<Int32> users11_UserID, Int32 user2_UserID)
        {
			this.UserID = userID;
			this.UserName = userName;
			this.FirstName = firstName;
			this.MiddleName = middleName;
			this.LastName = lastName;
			this.DOB = dOB;
			this.IsActive = isActive;
			this.IsDeleted = isDeleted;
			this.insuser = insuser;
			this.insdt = insdt;
			this.upduser = upduser;
			this.upddt = upddt;
			this.Description = description;
			this.Achievements_AchievementID = achievements_AchievementID;
			this.Businesses_BusinessID = businesses_BusinessID;
			this.Businesses1_BusinessID = businesses1_BusinessID;
			this.BusinessUserMaps_BusinessUserMapID = businessUserMaps_BusinessUserMapID;
			this.Educations_EducationID = educations_EducationID;
			this.Experiences_ExperienceID = experiences_ExperienceID;
			this.JobApplications_JobApplicationID = jobApplications_JobApplicationID;
			this.Languages_LanguageID = languages_LanguageID;
			this.Skills_SkillID = skills_SkillID;
			this.UserAccounts_UserAccountID = userAccounts_UserAccountID;
			this.UserAddresses_UserAddressID = userAddresses_UserAddressID;
			this.UserEmails_UserEmailID = userEmails_UserEmailID;
			this.UserImages_UserImageID = userImages_UserImageID;
			this.UserPhones_UserPhoneID = userPhones_UserPhoneID;
			this.UserRoles_UserRoleID = userRoles_UserRoleID;
			this.Users1_UserID = users1_UserID;
			this.User1_UserID = user1_UserID;
			this.Users11_UserID = users11_UserID;
			this.User2_UserID = user2_UserID;
        }
    }
}
