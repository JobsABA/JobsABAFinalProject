using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;
using JobsInABA.DAL.Entities;
using JobsInABA.DAL.Repositories;
using System;

namespace JobsInABA.BL
{
    public class BusinessPhoneBL : IDisposable
    {
        BusinessPhonesRepo _BusinessPhoneRepos;

        private BusinessPhonesRepo businessPhoneRepos
        {
            get
            {
                if (_BusinessPhoneRepos == null) _BusinessPhoneRepos = new BusinessPhonesRepo();
                return _BusinessPhoneRepos;
            }
        }

        public BusinessPhoneDTO Get(int id)
        {
            BusinessPhoneDTO oBusinessPhoneDTO = null;
            if (id > 0)
            {
                BusinessPhone oBusinessPhone = businessPhoneRepos.GetBusinessPhone(id);
            }

            return oBusinessPhoneDTO;
        }

        public BusinessPhoneDTO Create(BusinessPhoneDTO modelDTO)
        {
            if (modelDTO != null)
            {
                return BusinessPhoneAssembler.ToDTO(businessPhoneRepos.CreateBusinessPhone(BusinessPhoneAssembler.ToEntity(modelDTO)));
            }

            return null;
        }

        public BusinessPhoneDTO Update(BusinessPhoneDTO modelDTO)
        {
            BusinessPhoneDTO returnPhone = null;
            if (modelDTO != null && modelDTO.PhoneID > 0)
            {
                businessPhoneRepos.UpdateBusinessPhone(0, BusinessPhoneAssembler.ToEntity(modelDTO));
                returnPhone = modelDTO;
            }

            return returnPhone;
        }

        public bool Delete(int id)
        {
            Boolean isDeleted = false;

            if (id > 0)
            {
                try
                {
                    businessPhoneRepos.DeleteBusinessPhone(id);
                }
                catch
                {
                    return false;
                }
            }
            return isDeleted;
        }

        public void Dispose()
        {
            //_BusinessPhoneRepos.Dis
        }
    }
}
