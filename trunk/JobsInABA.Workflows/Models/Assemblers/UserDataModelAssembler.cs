using JobsInABA.BL.DTOs;
using System.Collections.Generic;
using System.Text;

namespace JobsInABA.Workflows.Models.Assemblers
{
    public static class UserDataModelAssembler
    {
        public static UserDataModel ToDataModel(UserDTO userDTO, UserAccountDTO accountDTO, AddressDTO addressDTO, PhoneDTO phoneDTO, EmailDTO emailDTO, List<ExperienceDTO> userExpriencelDTO, List<AchievementDTO> userAchievementlDTO, List<EducationDTO> userEducationlDTO, List<SkillDTO> userSkillDTO, List<LanguageDTO> userLanguageDTO, ImageDTO imageDTO)
        {

            UserDataModel model = null;

            if (userDTO != null)
            {
                model = new UserDataModel
                {
                    UserID = userDTO.UserID,
                    UserName = userDTO.UserName,
                    FirstName = userDTO.FirstName,
                    MiddleName = userDTO.MiddleName,
                    LastName = userDTO.LastName,
                    DOB = userDTO.DOB,
                    IsActive = userDTO.IsActive,
                    IsDeleted = userDTO.IsDeleted,
                    insuser = userDTO.insuser,
                    insdt = userDTO.insdt,
                    upduser = userDTO.upduser,
                    upddt = userDTO.upddt,
                    Description = userDTO.Description
                };

                if (accountDTO != null)
                {
                    model.UserAccountID = accountDTO.UserAccountID;
                    model.UserAccountinsdt = accountDTO.insdt;
                    model.UserAccountinsuser = accountDTO.insuser;
                    model.UserAccountIsActive = accountDTO.IsActive;
                    model.UserAccountIsDeleted = accountDTO.IsDeleted;
                    model.UserAccountPassword = Encoding.ASCII.GetString(accountDTO.Password);
                    model.UserAccountupddt = accountDTO.upddt;
                    model.UserAccountupduser = accountDTO.upduser;
                    model.UserAccountUserName = accountDTO.UserName;
                }

                if (addressDTO != null)
                {
                    model.UserAddressAddressTypeID = addressDTO.AddressTypeID;
                    model.UserAddressCity = addressDTO.City;
                    model.UserAddressCountryID = addressDTO.CountryID;
                    model.UserAddressID = addressDTO.AddressID;
                    model.UserAddressLine1 = addressDTO.Line1;
                    model.UserAddressLine2 = addressDTO.Line2;
                    model.UserAddressLine3 = addressDTO.Line3;
                    model.UserAddressState = addressDTO.State;
                    model.UserAddressTitle = addressDTO.Title;
                    model.UserAddressZipCode = addressDTO.ZipCode;

                }

                if (phoneDTO != null)
                {
                    model.UserPhoneCountryID = phoneDTO.CountryID;
                    model.UserPhoneAddressBookID = phoneDTO.AddressbookID;
                    model.UserPhoneExt = phoneDTO.Ext;
                    model.UserPhoneID = phoneDTO.PhoneID;
                    model.UserPhoneNumber = phoneDTO.Number;
                    model.UserPhoneTypeID = phoneDTO.PhoneTypeID;
                }

                if (emailDTO != null)
                {
                    model.UserEmailAddress = emailDTO.Address;
                    model.UserEmailID = emailDTO.EmailID;
                    model.UserEmailTypeID = emailDTO.EmailTypeID;
                }

                if (userExpriencelDTO != null)
                {
                    List<ExperienceDTO> lst = new List<ExperienceDTO>();
                    foreach (var item in userExpriencelDTO)
                    {
                        lst.Add(new ExperienceDTO()
                        {
                            Business = item.Business,
                            JobPossition = item.JobPossition,
                            StartDate = item.StartDate,
                            EndDate = item.EndDate,
                            ExperienceID = item.ExperienceID,
                            BusinessID = item.BusinessID,
                            IsCurrent = item.IsCurrent

                        });
                    }
                    model.ExprienceModal = lst;
                }

                if (userAchievementlDTO != null)
                {
                    List<AchievementDTO> lst = new List<AchievementDTO>();
                    foreach (var item in userAchievementlDTO)
                    {
                        lst.Add(item);
                    }
                    model.AchievementModel = lst;
                }

                if (userEducationlDTO != null)
                {
                    List<EducationDTO> lst = new List<EducationDTO>();
                    foreach (var item in userEducationlDTO)
                    {
                        lst.Add(item);
                    }
                    model.EducationModel = lst;
                }

                if (userSkillDTO != null)
                {
                    List<SkillDTO> lst = new List<SkillDTO>();
                    foreach (var item in userSkillDTO)
                    {
                        lst.Add(item);
                    }
                    model.SkillModel = lst;
                }

                if (userLanguageDTO != null)
                {
                    List<LanguageDTO> lst = new List<LanguageDTO>();
                    foreach (var item in userLanguageDTO)
                    {
                        lst.Add(item);
                    }
                    model.LanguageModel = lst;
                }
                if (imageDTO != null)
                {
                    model.UserImageExt = imageDTO.ImageExtension;
                    model.UserImageName = imageDTO.Name;
                }
            }

            return model;
        }

        public static UserDTO ToUserDTO(UserDataModel datamodel)
        {
            UserDTO dto = new UserDTO();
            if (datamodel != null)
            {
                dto.UserID = datamodel.UserID;
                dto.UserName = datamodel.UserName;
                dto.FirstName = datamodel.FirstName;
                dto.MiddleName = datamodel.MiddleName;
                dto.LastName = datamodel.LastName;
                dto.DOB = datamodel.DOB;
                dto.IsActive = datamodel.IsActive;
                dto.IsDeleted = datamodel.IsDeleted;
                dto.insuser = datamodel.insuser;
                dto.insdt = datamodel.insdt;
                dto.upduser = datamodel.upduser;
                dto.upddt = datamodel.upddt;
                dto.Description = datamodel.Description;
            }

            return dto;
        }

        public static UserAccountDTO ToUserAccountDTO(UserDataModel datamodel)
        {
            UserAccountDTO model = new UserAccountDTO();
            if (datamodel != null)
            {
                model.UserAccountID = datamodel.UserAccountID;
                model.UserID = datamodel.UserID;
                model.insdt = datamodel.UserAccountinsdt;
                model.insuser = datamodel.UserAccountinsuser;
                model.IsActive = datamodel.UserAccountIsActive;
                model.IsDeleted = datamodel.UserAccountIsDeleted;
                if (datamodel.UserAccountPassword != null)
                    model.Password = Encoding.ASCII.GetBytes(datamodel.UserAccountPassword);
                model.upddt = datamodel.UserAccountupddt;
                model.upduser = datamodel.UserAccountupduser;
                model.UserName = datamodel.UserAccountUserName;
            }
            return model;
        }

        public static AddressDTO ToAddressDTO(UserDataModel datamodel)
        {
            AddressDTO dto = new AddressDTO();
            if (datamodel != null)
            {
                dto.AddressID = datamodel.AddressID;
                dto.AddressTypeID = datamodel.UserAddressAddressTypeID;
                dto.City = datamodel.UserAddressCity;
                dto.CountryID = datamodel.UserAddressCountryID;
                dto.Line1 = datamodel.UserAddressLine1;
                dto.Line2 = datamodel.UserAddressLine2;
                dto.Line3 = datamodel.UserAddressLine3;
                dto.State = datamodel.UserAddressState;
                dto.Title = datamodel.UserAddressTitle;
                dto.ZipCode = datamodel.UserAddressZipCode;
            }

            return dto;
        }

        public static PhoneDTO ToPhoneDTO(UserDataModel datamodel)
        {
            PhoneDTO dto = new PhoneDTO();
            if (datamodel != null)
            {
                dto.CountryID = datamodel.UserPhoneCountryID;
                dto.AddressbookID = datamodel.UserPhoneAddressBookID;
                dto.Ext = datamodel.UserPhoneExt;
                dto.Number = datamodel.UserPhoneNumber;
                dto.PhoneID = datamodel.PhoneID;
                dto.PhoneTypeID = datamodel.UserPhoneTypeID;
                
            }

            return dto;
        }

        public static EmailDTO ToEmailDTO(UserDataModel datamodel)
        {
            EmailDTO dto = new EmailDTO();
            if (datamodel != null)
            {
                dto.Address = datamodel.UserEmailAddress;
                dto.EmailID = datamodel.EmailID;
                dto.EmailTypeID = datamodel.UserEmailTypeID;
            }

            return dto;
        }

        public static ImageDTO ToImageDTO(UserDataModel datamodel)
        {
            ImageDTO dto = new ImageDTO();
            if (datamodel != null)
            {
                dto.ImageID = datamodel.ImageID;
                dto.Name = datamodel.Name;
                dto.ImageTypeID = datamodel.ImageTypeID;
                dto.ImageExtension = datamodel.ImageExtension;
            }

            return dto;
        }

        public static UserImageDTO ToUserImageDTO(UserDataModel datamodel)
        {
            UserImageDTO dto = new UserImageDTO();
            if (datamodel != null)
            {
                dto.ImageID = datamodel.ImageID;
                dto.UserImageID = datamodel.UserImageID;
                dto.UserID = datamodel.UserID;
                dto.IsPrimary = datamodel.UserimagePrimary;
            }

            return dto;
        }

        public static UserAccountDTO ToUserChnagePasswordDTO(ChangePassword datamodel)
        {
            UserAccountDTO model = new UserAccountDTO();
            if (datamodel != null)
            {
                model.UserAccountID = datamodel.UserAccountID;
                model.UserID = datamodel.UserID;
                if (datamodel.UserAccountPassword != null)
                    model.Password = Encoding.ASCII.GetBytes(datamodel.UserAccountPassword);
                model.UserName = datamodel.UserAccountUserName;

            }
            return model;
        }
    }

}
