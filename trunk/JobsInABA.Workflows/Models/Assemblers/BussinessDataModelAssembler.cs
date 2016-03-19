using JobsInABA.BL.DTOs;
using System.Collections.Generic;

namespace JobsInABA.Workflows.Models.Assemblers
{
    public static class BusinessDataModelAssembler
    {
        public static BusinessDataModel ToDataModel(BusinessDTO BusinessDTO, List<AddressDTO> primaryAddressDTO, PhoneDTO primaryPhoneDTO,
            EmailDTO primaryEmailDTO, ImageDTO ImageDTO, List<AchievementDTO> primaryAchievementDTO
            , BusinessUserMapDTO businessUserMapDTO, List<ServiceDTO> primaryServiceDTO)
        {
            BusinessDataModel model = new BusinessDataModel();

            if (model != null)
            {
                model.Abbreviation = BusinessDTO.Abbreviation;
                model.BusinessID = BusinessDTO.BusinessID;
                model.BusinessTypeID = BusinessDTO.BusinessTypeID;
                model.insdt = BusinessDTO.insdt;
                model.insuser = BusinessDTO.insuser;
                model.IsActive = BusinessDTO.IsActive;
                model.IsDeleted = BusinessDTO.IsDeleted;
                model.Name = BusinessDTO.Name;
                model.StartDate = BusinessDTO.StartDate;
                model.upddt = BusinessDTO.upddt;
                model.upduser = BusinessDTO.upduser;
                model.Description = BusinessDTO.Description;
                
            }

            if (businessUserMapDTO != null)
            {
                model.BusinessUserId = businessUserMapDTO.BusinessUserMapID;
                model.BusinessUserMapTypeCodeId = businessUserMapDTO.BusinessUserTypeID ?? 0;
            }

            model.Addresses = new List<AddressDTO>();

            if (primaryAddressDTO != null)
            {
                foreach (var item in primaryAddressDTO)
                {
                    if (item != null)
                    {
                        AddressDTO addressDTO = new AddressDTO();
                        addressDTO.AddressID = item.AddressID;
                        addressDTO.AddressTypeID = item.AddressTypeID;
                        addressDTO.City = item.City;
                        addressDTO.CountryID = item.CountryID;
                        addressDTO.AddressID = item.AddressID;
                        addressDTO.Line1 = item.Line1;
                        addressDTO.Line2 = item.Line2;
                        addressDTO.Line3 = item.Line3;
                        addressDTO.State = item.State;

                        addressDTO.Title = item.Title;
                        addressDTO.ZipCode = item.ZipCode;

                        model.Addresses.Add(addressDTO);
                    }
                }
            }

            model.Achievement = new List<AchievementDTO>();

            if (primaryAchievementDTO != null)
            {
                foreach (var item in primaryAchievementDTO)
                {
                    if (item != null)
                    {
                        AchievementDTO achievementDTO = new AchievementDTO();
                        achievementDTO.AchievementID = item.AchievementID;
                        achievementDTO.Date = item.Date;
                        achievementDTO.Name = item.Name;

                        model.Achievement.Add(achievementDTO);
                    }
                }
            }

            model.Service = new List<ServiceDTO>();

            if (primaryServiceDTO != null)
            {
                foreach (var item in primaryServiceDTO)
                {
                    if (item != null)
                    {
                        ServiceDTO serviceDTO = new ServiceDTO();
                        serviceDTO.ServiceID = item.ServiceID;
                        serviceDTO.BusinessID = item.BusinessID;
                        serviceDTO.Name = item.Name;
                        
                        model.Service.Add(serviceDTO);
                    }
                }
            }

            if (primaryPhoneDTO != null)
            {
                model.BusinessPhoneCountryID = primaryPhoneDTO.CountryID;
                model.BusinessPhoneExt = primaryPhoneDTO.Ext;
                model.BusinessPhoneID = primaryPhoneDTO.PhoneID;
                model.BusinessPhoneNumber = primaryPhoneDTO.Number;
                model.BusinessPhoneTypeID = primaryPhoneDTO.PhoneTypeID;
                model.BusinessPhoneAddressbookID = primaryPhoneDTO.AddressbookID;
            }

            if (primaryEmailDTO != null)
            {
                model.BusinessEmailAddress = primaryEmailDTO.Address;
                model.BusinessEmailID = primaryEmailDTO.EmailID;
                model.BusinessEmailTypeID = primaryEmailDTO.EmailTypeID;
            }

            if (ImageDTO != null)
            {
                model.BusinessImageID = ImageDTO.ImageID;
                model.ImageExtension = ImageDTO.ImageExtension;
                model.ImageName = ImageDTO.Name;
            }

            return model;
        }

        public static BusinessDTO ToBusinessDTO(BusinessDataModel datamodel)
        {

            BusinessDTO dto = new BusinessDTO();
            if (datamodel != null)
            {
                dto.Abbreviation = datamodel.Abbreviation;
                dto.BusinessID = datamodel.BusinessID;
                dto.BusinessTypeID = datamodel.BusinessTypeID;
                dto.insdt = datamodel.insdt;
                dto.insuser = datamodel.insuser;
                dto.IsActive = datamodel.IsActive;
                dto.IsDeleted = datamodel.IsDeleted;
                dto.Name = datamodel.Name;
                dto.StartDate = datamodel.StartDate;
                dto.upddt = datamodel.upddt;
                dto.upduser = datamodel.upduser;
                dto.Description = datamodel.Description;
            }

            return dto;
        }

        public static List<AddressDTO> ToAddressDTO(BusinessDataModel model)
        {
            List<AddressDTO> dto = new List<AddressDTO>();
            if (model.Addresses != null)
                dto = model.Addresses;
            //if (model != null)
            //{
            //    dto.AddressTypeID = model.BusinessAddressAddressTypeID;
            //    dto.City = model.BusinessAddressCity;
            //    dto.CountryID = model.BusinessAddressCountryID;
            //    dto.AddressID = model.BusinessAddressID;
            //    dto.Line1 = model.BusinessAddressLine1;
            //    dto.Line2 = model.BusinessAddressLine2;
            //    dto.Line3 = model.BusinessAddressLine3;
            //    dto.State = model.BusinessAddressState;

            //    dto.Title = model.BusinessAddressTitle;
            //    dto.ZipCode = model.BusinessAddressZipCode;
            //}

            return dto;
        }

        public static PhoneDTO ToPhoneDTO(BusinessDataModel model)
        {

            PhoneDTO dto = new PhoneDTO();
            if (model != null)
            {
                dto.CountryID = model.BusinessPhoneCountryID;
                dto.Ext = model.BusinessPhoneExt;
                dto.PhoneID = model.BusinessPhoneID;
                dto.Number = model.BusinessPhoneNumber;
                dto.PhoneTypeID = model.BusinessPhoneTypeID;
                dto.AddressbookID = model.BusinessImageID;
            }

            return dto;
        }

        public static BusinessUserMapDTO ToBusinessUserMapDTO(BusinessDataModel model)
        {

            BusinessUserMapDTO dto = new BusinessUserMapDTO();
            if (model != null)
            {
                dto.BusinessUserMapID = model.BusinessUserId;
                dto.BusinessUserTypeID = model.BusinessUserMapTypeCodeId;
            }

            return dto;
        }

        public static EmailDTO ToEmailDTO(BusinessDataModel model)
        {
            EmailDTO dto = new EmailDTO();
            if (model != null)
            {
                dto.Address = model.BusinessEmailAddress;
                dto.EmailID = model.BusinessEmailID;
                dto.EmailTypeID = model.BusinessEmailTypeID;
            }

            return dto;
        }

        public static ImageDTO ToImageDTO(BusinessDataModel datamodel)
        {
            ImageDTO dto = new ImageDTO();
            if (datamodel != null)
            {
                dto.ImageID = datamodel.ImageID;
                dto.Name = datamodel.ImageName;
                dto.ImageTypeID = datamodel.ImageTypeID;
                dto.ImageExtension = datamodel.ImageExtension;
            }

            return dto;
        }
        public static BusinessImageDTO ToBusinessImageDTO(BusinessDataModel datamodel)
        {
            BusinessImageDTO dto = new BusinessImageDTO();
            if (datamodel != null)
            {
                dto.ImageID = datamodel.ImageID;
                dto.BusinessImageID = datamodel.BusinessImageID;
                dto.BusinessID = datamodel.BusinessID;
                dto.IsPrimary = datamodel.BusinessImagePrimary;
            }

            return dto;
        }
    }
}
