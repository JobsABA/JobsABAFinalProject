using System.Collections.Generic;
using System.Linq;
using JobsInABA.BL;
using JobsInABA.Workflows.Models;
using JobsInABA.Workflows.Models.Assemblers;
using JobsInABA.BL.DTOs;
using System;
using JobsInABA.DAL.Entities;

namespace JobsInABA.Workflows
{
    public class BusinessWorkflows : IDisposable
    {
        BusinessBL _BusinessBL;
        AddressBL _AddressBL;
        EmailsBL _EmailsBL;
        PhonesBL _PhonesBL;
        BusinessImageBL _BusinessImageBL;
        ImageBL _ImageBL;
        public BusinessDataModel Get(int id)
        {
            BusinessDataModel businessDataModel = null;
            if (id > 0)
            {
                BusinessDTO businessDTO = businessBL.Get(id);

                if (businessDTO != null)
                {
                    businessDataModel = Get(businessDTO);
                    if (businessDataModel != null)
                        businessDataModel.BusinessServices = new ServiceBL().Get().Where(p => p.BusinessID == businessDataModel.BusinessID).ToList();

                    var businessUsers = new BusinessUserMapBL().Get().Where(p => p.BusinessID == id && p.IsOwner == true).FirstOrDefault();
                    if (businessUsers != null)
                    {
                        businessDataModel.Owner = new UsersBL().Get(businessUsers.UserID);
                    }
                }
            }
            return businessDataModel;
        }

        public BusinessDataModel Get(BusinessDTO modelDTO)
        {
            BusinessDataModel BusinessDataModel = null;
            if (modelDTO != null)
            {
                //List<BusinessAddressDTO> BusinessAddressDTO = (modelDTO.BusinessAddresses != null) ? modelDTO.BusinessAddresses.Select(p => p) : null;
                //AddressDTO oPrimaryAddressDTO = (BusinessAddressDTO != null) ? BusinessAddressDTO.Addres : null;

                List<AddressDTO> oPrimaryAddressDTO = (modelDTO.BusinessAddresses != null) ? modelDTO.BusinessAddresses.Where(p => p.BusinessID == modelDTO.BusinessID).Select(p => p.Addres).ToList() : null;
                List<ServiceDTO> servicesList = (modelDTO.Services != null) ? modelDTO.Services.Where(p => p.BusinessID == modelDTO.BusinessID).ToList() : null;
                List<AchievementDTO> oPrimaryAchievementDTO = (modelDTO.Achievements != null) ? modelDTO.Achievements.Where(p => p.BusinessID == modelDTO.BusinessID).Select(p => p).ToList() : null;

                BusinessPhoneDTO BusinessPhoneDTO = (modelDTO.BusinessPhones != null) ? modelDTO.BusinessPhones.Where(o => o.IsPrimary).FirstOrDefault() : null;
                PhoneDTO oPrimaryPhoneDTO = (BusinessPhoneDTO != null) ? BusinessPhoneDTO.Phone : null;

                //BusinessImageDTO BusinessImageDTO = (modelDTO.BusinessImages != null) ? modelDTO.BusinessImages.Where(o => o.IsPrimary).FirstOrDefault() : null;
                //ImageDTO oPrimaryImageDTO = (BusinessImageDTO != null) ? BusinessImageDTO.Image : null;

                ImageDTO oPrimaryImageDTO = (modelDTO.BusinessImages != null) ? modelDTO.BusinessImages.Where(o => o.IsPrimary).Select(p => p.Image).FirstOrDefault() : null;

                BusinessEmailDTO BusinessEmailDTO = (modelDTO.BusinessEmails != null) ? modelDTO.BusinessEmails.Where(o => o.IsPrimary).FirstOrDefault() : null;
                EmailDTO oPrimaryEmailDTO = (BusinessEmailDTO != null) ? BusinessEmailDTO.Email : null;

                BusinessDataModel = BusinessDataModelAssembler.ToDataModel(modelDTO, oPrimaryAddressDTO, oPrimaryPhoneDTO, oPrimaryEmailDTO, oPrimaryImageDTO, oPrimaryAchievementDTO, null, servicesList);
                BusinessDataModel.PrimaryAddressID = (modelDTO.BusinessAddresses != null) ? modelDTO.BusinessAddresses.FirstOrDefault(p => p.IsPrimary == true).AddressID : 0;
                //BusinessDataModel.BusinessAddressID = (BusinessAddressDTO != null) ? BusinessAddressDTO.BusinessAddressID : 0;
                BusinessDataModel.BusinessPhoneID = (BusinessPhoneDTO != null) ? BusinessPhoneDTO.BusinessPhoneID : 0;
                BusinessDataModel.BusinessEmailID = (BusinessEmailDTO != null) ? BusinessEmailDTO.BusinessEmailID : 0;
            }
            return BusinessDataModel;
        }

        public IEnumerable<BusinessDataModel> Get()
        {
            List<BusinessDTO> businessDTOs = businessBL.Get();
            List<BusinessDataModel> businessDataModels = businessDTOs.Select(businessdto => Get(businessdto)).ToList();
            return businessDataModels;

            //var Users = new UsersBL().Get();
            //if (businessDataModels != null)
            //{
            //    foreach (var item in businessDataModels.ToList())
            //    {
            //        item.BusinessServices = new ServiceBL().Get().Where(p => p.BusinessID == item.BusinessID).ToList();
            //        if (Users != null)
            //            foreach (var User in Users)
            //            {
            //                if (User.Experiences != null)
            //                    foreach (var Experience in User.Experiences)
            //                    {
            //                        if (Experience.BusinessID == item.BusinessID)
            //                        {
            //                            item.Employee.Add(User);
            //                        }
            //                    }
            //            }
            //        var businessUsers = new BusinessUserMapBL().Get().Where(p => p.BusinessID == item.BusinessID).ToList();
            //        if (businessUsers != null || businessUsers.Count > 0)
            //        {
            //            if (businessUsers.Count(p => p.IsOwner == true) > 0)
            //            {
            //                var userId = businessUsers.FirstOrDefault(p => p.IsOwner == true).UserID;
            //                if (userId != 0 || userId != null)
            //                    item.Owner = new UsersBL().Get(userId);
            //            }
            //        }
            //        item.Count = businessDataModels.ToList().Count;
            //    }
            //}
            //var businessDataModelsList = businessDataModels.ToList();
            //return businessDataModelsList;
        }

        public BusinessDataModel Create(BusinessDataModel dataModel)
        {
            if (dataModel != null)
            {
                BusinessDTO businessDTO = new BusinessDTO();
                List<AddressDTO> addressDTO = new List<AddressDTO>();
                PhoneDTO phoneDTO = new PhoneDTO();
                EmailDTO emailDTO = new EmailDTO();
                BusinessUserMapDTO businessUserMapDTO = new BusinessUserMapDTO();

                businessDTO = BusinessDataModelAssembler.ToBusinessDTO(dataModel);
                phoneDTO = BusinessDataModelAssembler.ToPhoneDTO(dataModel);
                emailDTO = BusinessDataModelAssembler.ToEmailDTO(dataModel);
                addressDTO = BusinessDataModelAssembler.ToAddressDTO(dataModel);
                businessUserMapDTO = BusinessDataModelAssembler.ToBusinessUserMapDTO(dataModel);

                if (businessDTO != null)
                {
                    businessDTO = businessBL.Create(businessDTO);
                }
                dataModel = BusinessDataModelAssembler.ToDataModel(businessDTO, addressDTO, phoneDTO, emailDTO, null, null, businessUserMapDTO, null);
                if (dataModel.BusinessUserId != 0)
                {
                    new BusinessUserMapBL().Create(new BusinessUserMapDTO()
                    {
                        BusinessID = dataModel.BusinessID,
                        UserID = dataModel.BusinessUserId,
                        BusinessUserTypeID = dataModel.BusinessUserMapTypeCodeId,
                        IsOwner = true
                    });
                }

                addressDTO = BusinessDataModelAssembler.ToAddressDTO(dataModel);
                if (addressDTO != null)
                {
                    List<AddressDTO> addressList = new List<AddressDTO>();
                    //addressDTO = addressDTO.Select(p => addressBL.Create(p)).ToList();
                    foreach (var item in addressDTO)
                    {
                        addressList.Add(addressBL.Create(item));
                    }

                    addressDTO = addressList;
                }
                dataModel = BusinessDataModelAssembler.ToDataModel(businessDTO, addressDTO, phoneDTO, emailDTO, null, null, businessUserMapDTO, null);
                if (dataModel.Addresses.Count() != 0)
                {
                    new BusinessAddressBL().Create(new BusinessAddressDTO()
                    {
                        BusinessID = dataModel.BusinessID,
                        AddressID = dataModel.Addresses.FirstOrDefault().AddressID,
                        IsPrimary = true
                    });
                }

                if (addressDTO.Count != 0)
                {
                    phoneDTO = BusinessDataModelAssembler.ToPhoneDTO(dataModel);
                    if (phoneDTO != null)
                    {
                        phoneDTO.AddressbookID = addressDTO.FirstOrDefault().AddressID;
                        phoneDTO = phonesBL.Create(phoneDTO);
                    }
                    dataModel = BusinessDataModelAssembler.ToDataModel(businessDTO, addressDTO, phoneDTO, emailDTO, null, null, businessUserMapDTO, null);
                    new BusinessPhoneBL().Create(new BusinessPhoneDTO()
                    {
                        BusinessID = dataModel.BusinessID,
                        PhoneID = dataModel.BusinessPhoneID,
                        IsPrimary = true
                    });
                }
                
                dataModel = BusinessDataModelAssembler.ToDataModel(businessDTO, addressDTO, phoneDTO, emailDTO, null, null, businessUserMapDTO, null);
                emailDTO = BusinessDataModelAssembler.ToEmailDTO(dataModel);
                if (emailDTO != null)
                {
                    emailDTO = emailsBL.Create(emailDTO);
                }
                dataModel = BusinessDataModelAssembler.ToDataModel(businessDTO, addressDTO, phoneDTO, emailDTO, null, null, businessUserMapDTO, null);
                new BusinessEmailBL().Create(new BusinessEmailDTO()
                {
                    BusinessID = dataModel.BusinessID,
                    EmailID = dataModel.BusinessEmailID,
                    IsPrimary = true
                });
                dataModel = BusinessDataModelAssembler.ToDataModel(businessDTO, addressDTO, phoneDTO, emailDTO, null, null, businessUserMapDTO, null);
            }

            return dataModel;
        }

        public BusinessDataModel Update(BusinessDataModel dataModel)
        {
            if (dataModel != null)
            {
                BusinessDTO businessDTO = new BusinessDTO();
                List<AddressDTO> addressDTO = new List<AddressDTO>();
                PhoneDTO phoneDTO = new PhoneDTO();
                EmailDTO emailDTO = new EmailDTO();
                BusinessUserMapDTO businessUserMapDTO = new BusinessUserMapDTO();

                businessDTO = BusinessDataModelAssembler.ToBusinessDTO(dataModel);
                phoneDTO = BusinessDataModelAssembler.ToPhoneDTO(dataModel);
                emailDTO = BusinessDataModelAssembler.ToEmailDTO(dataModel);
                addressDTO = BusinessDataModelAssembler.ToAddressDTO(dataModel);
                businessUserMapDTO = BusinessDataModelAssembler.ToBusinessUserMapDTO(dataModel);

                if (businessDTO != null)
                {
                    businessDTO = businessBL.Update(businessDTO);
                }
                dataModel = BusinessDataModelAssembler.ToDataModel(businessDTO, addressDTO, phoneDTO, emailDTO, null, null, businessUserMapDTO, null);

               
                if (phoneDTO != null)
                {
                    phoneDTO = phonesBL.Update(phoneDTO);
                }
                new BusinessPhoneBL().Update(new BusinessPhoneDTO()
                {
                    BusinessID = dataModel.BusinessID,
                    BusinessPhoneID = dataModel.BusinessPhoneID,
                    IsPrimary = true
                });
                dataModel = BusinessDataModelAssembler.ToDataModel(businessDTO, addressDTO, phoneDTO, emailDTO, null, null, businessUserMapDTO, null);
                if (emailDTO != null)
                {
                    emailDTO = emailsBL.Update(emailDTO);
                }
                new BusinessEmailBL().Update(new BusinessEmailDTO()
                {
                    BusinessID = dataModel.BusinessID,
                    BusinessEmailID = dataModel.BusinessEmailID,
                    IsPrimary = true
                });
                dataModel = BusinessDataModelAssembler.ToDataModel(businessDTO, addressDTO, phoneDTO, emailDTO, null, null, businessUserMapDTO, null);
                if (addressDTO != null)
                {
                    addressDTO = addressDTO.Select(p => addressBL.Update(p)).ToList();
                }
                dataModel = BusinessDataModelAssembler.ToDataModel(businessDTO, addressDTO, phoneDTO, emailDTO, null, null, businessUserMapDTO, null);
                new BusinessAddressBL().Update(new BusinessAddressDTO()
                {
                    BusinessID = dataModel.BusinessID,
                    BusinessAddressID = dataModel.BusinessAddressID,
                    IsPrimary = true
                });
                

            }

            return dataModel;
        }

        public bool Delete(int id)
        {
            return businessBL.Delete(id);
        }

        private BusinessBL businessBL
        {
            get
            {
                if (_BusinessBL == null) _BusinessBL = new BusinessBL();
                return _BusinessBL;
            }
        }

        private AddressBL addressBL
        {
            get
            {
                if (_AddressBL == null) _AddressBL = new AddressBL();
                return _AddressBL;
            }
        }

        private EmailsBL emailsBL
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

        private BusinessImageBL businessImageBL
        {
            get
            {
                if (_BusinessImageBL == null) _BusinessImageBL = new BusinessImageBL();
                return _BusinessImageBL;
            }
        }
        public void Dispose()
        {
            _BusinessBL.Dispose();
            _AddressBL.Dispose();
            _EmailsBL.Dispose();
            _PhonesBL.Dispose();
        }

        public IList<BusinessDataModel> GetBusinessesBySearch(string companyname, string city, int? from, int? to)
        {
            List<BusinessDataModel> businessDataModels = new List<BusinessDataModel>();
            int count = 0;
            List<BusinessDTO> businessDTOs = businessBL.GetBusinessesBySearch(companyname, city, from, to, out count);
            businessDataModels = businessDTOs.Select(userdto => Get(userdto)).ToList();
            if (businessDataModels != null)
                foreach (var item in businessDataModels)
                {
                    item.Count = count;
                    //var businessUsers = new BusinessUserMapBL().Get().Where(p => p.BusinessID == item.BusinessID);
                    //if (businessUsers != null)
                    //{
                    //    if (businessUsers.Count(p => p.IsOwner == true) >= 0)
                    //        item.Owner = new UsersBL().Get(businessUsers.FirstOrDefault(p => p.IsOwner == true).UserID);
                    //}
                }
            return businessDataModels;
        }

        public List<Business> GetBusinessesNameID()
        {
            return businessBL.GetBusinessesNameID();
        }

        public BusinessDataModel UpdateBusinessImage(BusinessDataModel dataModel)
        {
            if (dataModel != null)
            {
                ImageDTO imageDTO = new ImageDTO();
                BusinessImageDTO businessImageDTO = new BusinessImageDTO();

                imageDTO = BusinessDataModelAssembler.ToImageDTO(dataModel);
                businessImageDTO = BusinessDataModelAssembler.ToBusinessImageDTO(dataModel);

                if (CheckBusinessImageExist(dataModel.BusinessID))
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
                    if (businessImageDTO != null)
                    {
                        businessImageDTO.ImageID = imageDTO.ImageID;
                        businessImageDTO = businessImageBL.Create(businessImageDTO);
                    }
                }
            }

            return dataModel;
        }

        public bool CheckBusinessImageExist(int businessID)
        {
            return businessImageBL.CheckBusinessPrimaryImageExists(businessID);
        }
    }
}
