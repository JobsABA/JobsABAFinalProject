using System.Collections.Generic;
using System.Linq;
using JobsInABA.BL;
using JobsInABA.Workflows.Models;
using JobsInABA.Workflows.Models.Assemblers;
using JobsInABA.BL.DTOs;
using System;

namespace JobsInABA.Workflows
{
    public class UserWorkflows : IDisposable
    {
        UsersBL _UsersBL;
        AddressBL _AddressBL;
        UserAccountBL _AccountBL;
        EmailsBL _EmailsBL;
        PhonesBL _PhonesBL;
        AddressWorkflows _AddressWorkflows;
        ImageBL _ImageBL;
        UserImageBL _UserImageBL;

        public UserDataModel Get(int id)
        {
            UserDataModel userDataModel = null;
            if (id > 0)
            {
                UserDTO userDTO = usersBL.Get(id);

                if (userDTO != null)
                {
                    userDataModel = Get(userDTO);
                    if (userDataModel != null)
                        if (userDataModel.ExprienceModal != null)
                            foreach (var exprience in userDataModel.ExprienceModal)
                            {
                                exprience.Business.Services = new ServiceBL().Get().Where(p => p.BusinessID == exprience.BusinessID).ToList();
                            }

                }
            }
            return userDataModel;
        }

        public List<UserDataModel> GetUsersBySearch(string searchText, int from, int to)
        {
            List<UserDataModel> userDataModels = new List<UserDataModel>();
            List<UserDTO> userDTOs = usersBL.GetUsersBySearch(searchText, from, to);
            userDataModels = userDTOs.Select(userdto => Get(userdto)).ToList();
            return userDataModels;
        }

        public UserDataModel CanLogIn(string username, string password)
        {
            var userDTO = usersBL.CanLogIn(username, password);

            if (userDTO == null)
                return null;

            UserEmailDTO userEmailDTO = (userDTO.UserEmails != null) ? userDTO.UserEmails.Where(o => o.IsPrimary).FirstOrDefault() : null;
            EmailDTO oPrimaryEmailDTO = (userEmailDTO != null) ? userEmailDTO.Email : null;

            return UserDataModelAssembler.ToDataModel(userDTO, null, null,
                null, oPrimaryEmailDTO, null, null, null, null, null, null);
        }

        public UserDataModel Get(UserDTO modelDTO)
        {
            UserDataModel userDataModel = null;
            if (modelDTO != null)
            {
                UserAddressDTO userAddressDTO = (modelDTO.UserAddresses != null) ? modelDTO.UserAddresses.Where(o => o.IsPrimary).FirstOrDefault() : null;
                AddressDTO oPrimaryAddressDTO = (userAddressDTO != null) ? userAddressDTO.Address : null;

                UserAccountDTO userAccountDTO = (modelDTO.UserAccounts != null) ? modelDTO.UserAccounts.FirstOrDefault(o => o.IsActive == true) : null;

                UserPhoneDTO userPhoneDTO = (modelDTO.UserPhone != null) ? modelDTO.UserPhone.Where(o => o.IsPrimary).FirstOrDefault() : null;
                PhoneDTO oPrimaryPhoneDTO = (userPhoneDTO != null) ? userPhoneDTO.Phone : null;

                UserEmailDTO userEmailDTO = (modelDTO.UserEmails != null) ? modelDTO.UserEmails.Where(o => o.IsPrimary).FirstOrDefault() : null;
                EmailDTO oPrimaryEmailDTO = (userEmailDTO != null) ? userEmailDTO.Email : null;

                List<ExperienceDTO> userExpriencelDTO = (modelDTO.Experiences != null) ? modelDTO.Experiences.ToList() : null;
                List<AchievementDTO> userAchievementlDTO = (modelDTO.Achievements != null) ? modelDTO.Achievements.ToList() : null;
                List<EducationDTO> userEducationlDTO = (modelDTO.Educations != null) ? modelDTO.Educations.ToList() : null;
                List<SkillDTO> userSkillDTO = (modelDTO.Skills != null) ? modelDTO.Skills.ToList() : null;
                List<LanguageDTO> userLanguageDTO = (modelDTO.Languages != null) ? modelDTO.Languages.ToList() : null;

                ImageDTO userImageDTO = (modelDTO.UserImages != null) ? modelDTO.UserImages.Where(x => x.IsPrimary == true).FirstOrDefault().Image : null;
                //ImageDTO oPrimaryImage = (userImageDTO != null) ? userImageDTO.UserImageID : null;

                userDataModel = UserDataModelAssembler.ToDataModel(modelDTO, userAccountDTO, oPrimaryAddressDTO, oPrimaryPhoneDTO, oPrimaryEmailDTO, userExpriencelDTO, userAchievementlDTO, userEducationlDTO, userSkillDTO, userLanguageDTO, userImageDTO);
                userDataModel.UserAddressID = (userAddressDTO != null) ? userAddressDTO.UserAddressID : 0;
                userDataModel.AddressID = (userAddressDTO != null) ? userAddressDTO.AddressID : 0;
                userDataModel.UserPhoneID = (userPhoneDTO != null) ? userPhoneDTO.UserPhoneID : 0;
                userDataModel.PhoneID = (userPhoneDTO != null) ? userPhoneDTO.PhoneID : 0;
                userDataModel.UserEmailID = (userEmailDTO != null) ? userEmailDTO.UserEmailID : 0;
                userDataModel.EmailID = (userEmailDTO != null) ? userEmailDTO.EmailID : 0;
            }
            return userDataModel;
        }

        public List<UserDataModel> Get()
        {
            List<UserDataModel> userDataModels = new List<UserDataModel>();

            List<UserDTO> userDTOs = usersBL.Get();

            userDataModels = userDTOs.Select(userdto => Get(userdto)).ToList();

            if (userDataModels != null)
                foreach (var userDataModel in userDataModels)
                {
                    if (userDataModel.ExprienceModal != null)
                        foreach (var exprience in userDataModel.ExprienceModal)
                        {
                            exprience.Business.Services = new ServiceBL().Get().Where(p => p.BusinessID == exprience.BusinessID).ToList();
                        }
                }

            return userDataModels;
        }

        public List<BusinessDTO> GetUsersWiseCompany(int id)
        {
            List<BusinessDTO> businessDTO = new List<BusinessDTO>();
            if (id > 0)
            {
                UserDTO userDTO = usersBL.Get(id);

                if (userDTO != null)
                {
                    var user = Get(userDTO);
                    foreach (var item in new BusinessUserMapBL().Get().Where(q => q.UserID == user.UserID).Select(l => l.BusinessID))
                    {
                        businessDTO.Add(new BusinessBL().Get(item));
                    }
                }
            }
            return businessDTO;
        }

        public UserDataModel Create(UserDataModel dataModel)
        {
            if (dataModel != null)
            {
                UserDTO userDTO = new UserDTO();
                UserAccountDTO userAccountDTO = new UserAccountDTO();
                PhoneDTO phoneDTO = new PhoneDTO();
                EmailDTO emailDTO = new EmailDTO();
                AddressDTO addressDTO = new AddressDTO();
                ExperienceDTO exprienceDTO = new ExperienceDTO();
                AchievementDTO achievementDTO = new AchievementDTO();
                EducationDTO educationDTO = new EducationDTO();
                SkillDTO skillDTO = new SkillDTO();
                LanguageDTO language = new LanguageDTO();

                userDTO = UserDataModelAssembler.ToUserDTO(dataModel);
                userAccountDTO = UserDataModelAssembler.ToUserAccountDTO(dataModel);
                phoneDTO = UserDataModelAssembler.ToPhoneDTO(dataModel);
                emailDTO = UserDataModelAssembler.ToEmailDTO(dataModel);
                addressDTO = UserDataModelAssembler.ToAddressDTO(dataModel);

                if (userDTO != null)
                {
                    userDTO = usersBL.Create(userDTO);
                }
                dataModel = UserDataModelAssembler.ToDataModel(userDTO, userAccountDTO, addressDTO, phoneDTO, emailDTO, null, null, null, null, null, null);
                userAccountDTO = UserDataModelAssembler.ToUserAccountDTO(dataModel);
                if (userAccountDTO != null)
                {
                    userAccountDTO = AccountBL.Create(userAccountDTO);
                }
                addressDTO = UserDataModelAssembler.ToAddressDTO(dataModel);
                if (addressDTO != null)
                {
                    addressDTO = AddressBL.Create(addressDTO);
                }
                dataModel = UserDataModelAssembler.ToDataModel(userDTO, userAccountDTO, addressDTO, phoneDTO, emailDTO, null, null, null, null, null, null);
                new UserAddressBL().Create(new UserAddressDTO()
                {
                    UserID = dataModel.UserID,
                    AddressID = dataModel.UserAddressID,
                    IsPrimary = true
                });
                dataModel = UserDataModelAssembler.ToDataModel(userDTO, userAccountDTO, addressDTO, phoneDTO, emailDTO, null, null, null, null, null, null);
                phoneDTO = UserDataModelAssembler.ToPhoneDTO(dataModel);
                if (phoneDTO != null)
                {
                    phoneDTO.AddressbookID = addressDTO.AddressID;
                    phoneDTO = phonesBL.Create(phoneDTO);
                }
                dataModel = UserDataModelAssembler.ToDataModel(userDTO, userAccountDTO, addressDTO, phoneDTO, emailDTO, null, null, null, null, null, null);
                new UserPhoneBL().Create(new UserPhoneDTO()
                {
                    UserID = dataModel.UserID,
                    PhoneID = dataModel.UserPhoneID,
                    IsPrimary = true
                });
                emailDTO = UserDataModelAssembler.ToEmailDTO(dataModel);
                if (emailDTO != null)
                {
                    emailDTO = EmailsBL.Create(emailDTO);
                }
                dataModel = UserDataModelAssembler.ToDataModel(userDTO, userAccountDTO, addressDTO, phoneDTO, emailDTO, null, null, null, null, null, null);
                new UserEmailBL().Create(new UserEmailDTO()
                {
                    UserID = dataModel.UserID,
                    EmailID = dataModel.UserEmailID,
                    IsPrimary = true
                });
            }
            return dataModel;
        }

        public UserDataModel Update(UserDataModel dataModel)
        {
            if (dataModel != null)
            {
                UserDTO userDTO = new UserDTO();
                UserAccountDTO userAccountDTO = new UserAccountDTO();
                PhoneDTO phoneDTO = new PhoneDTO();
                EmailDTO emailDTO = new EmailDTO();
                AddressDTO addressDTO = new AddressDTO();

                userDTO = UserDataModelAssembler.ToUserDTO(dataModel);
                userAccountDTO = UserDataModelAssembler.ToUserAccountDTO(dataModel);
                phoneDTO = UserDataModelAssembler.ToPhoneDTO(dataModel);
                emailDTO = UserDataModelAssembler.ToEmailDTO(dataModel);
                addressDTO = UserDataModelAssembler.ToAddressDTO(dataModel);

                if (userDTO != null)
                {
                    userDTO = usersBL.Update(userDTO);
                }
                if (userAccountDTO != null)
                {
                    userAccountDTO = AccountBL.Update(userAccountDTO);
                }
                if (phoneDTO != null)
                {
                    phoneDTO = phonesBL.Update(phoneDTO);
                }
                if (emailDTO != null)
                {
                    EmailsBL.Update(emailDTO);
                }
                if (addressDTO != null)
                {
                    AddressBL.Update(addressDTO);
                }
            }

            return dataModel;
        }


        public ChangePassword ChangePassword(ChangePassword dataModel)
        {
            if (dataModel != null)
            {
                UserAccountDTO userAccountDTO = new UserAccountDTO();
                userAccountDTO = UserDataModelAssembler.ToUserChnagePasswordDTO(dataModel);

                if (userAccountDTO != null)
                {
                    userAccountDTO = AccountBL.Update(userAccountDTO);
                }
            }

            return dataModel;
        }

        public UserDataModel UpdateUserImage(UserDataModel dataModel)
        {
            if (dataModel != null)
            {
                ImageDTO imageDTO = new ImageDTO();
                UserImageDTO userImageDTO = new UserImageDTO();

                imageDTO = UserDataModelAssembler.ToImageDTO(dataModel);
                userImageDTO = UserDataModelAssembler.ToUserImageDTO(dataModel);

                if (CheckUserImageExist(dataModel.UserID))
                {
                    if (imageDTO != null)
                    {
                        imageDTO = imageBL.Update(imageDTO);
                    }
                }
                else
                {
                    if (imageDTO != null)
                    {
                        imageDTO = imageBL.Create(imageDTO);
                    }
                    if (userImageDTO != null)
                    {
                        userImageDTO.ImageID = imageDTO.ImageID;
                        userImageDTO = userImageBL.Create(userImageDTO);
                    }
                }
            }

            return dataModel;
        }

        public bool Delete(int id)
        {
            return AccountBL.Delete(id);
        }

        private UserAccountBL AccountBL
        {
            get
            {
                if (_AccountBL == null) _AccountBL = new UserAccountBL();
                return _AccountBL;
            }
        }

        private UsersBL usersBL
        {
            get
            {
                if (_UsersBL == null) _UsersBL = new UsersBL();
                return _UsersBL;
            }
        }

        private AddressBL AddressBL
        {
            get
            {
                if (_AddressBL == null) _AddressBL = new AddressBL();
                return _AddressBL;
            }
        }

        private EmailsBL EmailsBL
        {
            get
            {
                if (_EmailsBL == null) _EmailsBL = new EmailsBL();
                return _EmailsBL;
            }
        }

        private PhonesBL phonesBL
        {
            get
            {
                if (_PhonesBL == null) _PhonesBL = new PhonesBL();
                return _PhonesBL;
            }
        }

        private ImageBL imageBL
        {
            get
            {
                if (_ImageBL == null) _ImageBL = new ImageBL();
                return _ImageBL;
            }
        }

        private UserImageBL userImageBL
        {
            get
            {
                if (_UserImageBL == null) _UserImageBL = new UserImageBL();
                return _UserImageBL;
            }
        }
        private AddressWorkflows addressWorkflows
        {
            get
            {
                if (_AddressWorkflows == null) _AddressWorkflows = new AddressWorkflows();
                return _AddressWorkflows;
            }
        }

        public void Dispose()
        {
            _AccountBL.Dispose();
            _AddressBL.Dispose();
            _AddressWorkflows.Dispose();
            _EmailsBL.Dispose();
            _PhonesBL.Dispose();
            _UsersBL.Dispose();
        }

        public bool ActivateUser(int UserID)
        {
            return AccountBL.ActivateUser(UserID);
        }

        public bool CheckUserImageExist(int UserId)
        {
            return userImageBL.CheckUserPrimaryImageExists(UserId);
        }

        public UserAccountDTO GetUserAccountInfoByUserID(int UserID)
        {
            return AccountBL.GetByUserID(UserID);
        }

    }
}
