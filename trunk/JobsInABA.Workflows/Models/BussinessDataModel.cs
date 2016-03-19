using JobsInABA.BL.DTOs;
using JobsInABA.DAL.Entities;
using System;
using System.Collections.Generic;

namespace JobsInABA.Workflows.Models
{
    public class BusinessDataModel
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

        public int BusinessAddressID { get; set; }
        public string BusinessAddressTitle { get; set; }
        public string BusinessAddressLine1 { get; set; }
        public string BusinessAddressLine2 { get; set; }
        public string BusinessAddressLine3 { get; set; }
        public string BusinessAddressCity { get; set; }
        public string BusinessAddressState { get; set; }
        public string BusinessAddressZipCode { get; set; }
        public Nullable<int> BusinessAddressCountryID { get; set; }
        public Nullable<int> BusinessAddressAddressTypeID { get; set; }

        public int BusinessUserMapTypeCodeId { get; set; }
        public int BusinessUserId { get; set; }

        public int BusinessEmailID { get; set; }
        public string BusinessEmailAddress { get; set; }
        public Nullable<int> BusinessEmailTypeID { get; set; }

        public int BusinessPhoneID { get; set; }
        public Nullable<int> BusinessPhoneCountryID { get; set; }
        public string BusinessPhoneNumber { get; set; }
        public string BusinessPhoneExt { get; set; }
        public Nullable<int> BusinessPhoneTypeID { get; set; }
        public List<AddressDTO> Addresses = new List<AddressDTO>();
        public List<AchievementDTO> Achievement { get; set; }
        public int BusinessPhoneAddressbookID { get; set; }
        public int PrimaryAddressID { get; set; }

        public int BusinessImageID { get; set; }
        public string ImageExtension { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }

        public List<UserDTO> Employee = new List<UserDTO>();

        public List<ServiceDTO> Service{ get; set; }
        public int Count { get; set; }

        public List<ServiceDTO> BusinessServices { get; set; }

        public UserDTO Owner { get; set; }

        public int UserID { get; set; }

        public int ImageTypeID { get; set; }

        public bool BusinessImagePrimary { get; set; }

        public int ImageID { get; set; }
    }
}
