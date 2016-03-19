using JobsInABA.BL.DTOs;
using System;
using System.Collections.Generic;

namespace JobsInABA.Workflows.Models
{
    public class UserDataModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> insuser { get; set; }
        public Nullable<System.DateTime> insdt { get; set; }
        public Nullable<int> upduser { get; set; }
        public Nullable<System.DateTime> upddt { get; set; }

        public int UserAccountID { get; set; }
        public string UserAccountUserName { get; set; }
        public string UserAccountPassword { get; set; }
        public bool UserAccountIsActive { get; set; }
        public bool UserAccountIsDeleted { get; set; }
        public Nullable<int> UserAccountinsuser { get; set; }
        public Nullable<System.DateTime> UserAccountinsdt { get; set; }
        public Nullable<int> UserAccountupduser { get; set; }
        public Nullable<System.DateTime> UserAccountupddt { get; set; }

        public int UserAddressID { get; set; }
        public string UserAddressTitle { get; set; }
        public string UserAddressLine1 { get; set; }
        public string UserAddressLine2 { get; set; }
        public string UserAddressLine3 { get; set; }
        public string UserAddressCity { get; set; }
        public string UserAddressState { get; set; }
        public string UserAddressZipCode { get; set; }
        public Nullable<int> UserAddressCountryID { get; set; }
        public Nullable<int> UserAddressAddressTypeID { get; set; }

        public int UserEmailID { get; set; }
        public string UserEmailAddress { get; set; }
        public Nullable<int> UserEmailTypeID { get; set; }

        public int UserPhoneID { get; set; }
        public Nullable<int> UserPhoneCountryID { get; set; }
        public int UserPhoneAddressBookID { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserPhoneExt { get; set; }
        public Nullable<int> UserPhoneTypeID { get; set; }

        public string Description { get; set; }

        public List<ExperienceDTO> ExprienceModal { get; set; }

        public List<AchievementDTO> AchievementModel { get; set; }

        public List<EducationDTO> EducationModel { get; set; }

        public List<SkillDTO> SkillModel { get; set; }

        public List<LanguageDTO> LanguageModel { get; set; }

        public string UserImageName { get; set; }
        public string UserImageExt { get; set; }


        public int PhoneID { get; set; }

        public int EmailID { get; set; }

        public int ImageID { get; set; }

        public string Name { get; set; }

        public int ImageTypeID { get; set; }

        public string ImageExtension { get; set; }

        public int UserImageID { get; set; }

        public bool UserimagePrimary { get; set; }

        public bool BusinessImagePrimary { get; set; }

        public int AddressID { get; set; }
    }
}
