using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;
using JobsInABA.DAL.Repositories;
using System;

namespace JobsInABA.BL
{
    public class BusinessAddressBL : IDisposable
    {
        BusinessAddressesRepo _BusinessAddressesRepo;

        private BusinessAddressesRepo businessAddressesRepo
        {
            get
            {
                if (_BusinessAddressesRepo == null) _BusinessAddressesRepo = new BusinessAddressesRepo();
                return _BusinessAddressesRepo;
            }
        }

        public BusinessAddressDTO Get(int id)
        {
            BusinessAddressDTO businessAddressDTO = null;
            if (id > 0)
            {
                businessAddressDTO = BusinessAddressAssembler.ToDTO(businessAddressesRepo.GetBusinessAddress(id));
            }

            return businessAddressDTO;
        }

        public BusinessAddressDTO Create(BusinessAddressDTO modelDTO)
        {
            if (modelDTO != null)
            {
                return BusinessAddressAssembler.ToDTO(businessAddressesRepo.CreateBusinessAddress(BusinessAddressAssembler.ToEntity(modelDTO)));
            }

            return null;
        }

        public BusinessAddressDTO Update(BusinessAddressDTO modelDTO)
        {
            BusinessAddressDTO returnAddress = null;
            if (modelDTO != null && modelDTO.AddressID > 0)
            {
                businessAddressesRepo.UpdateBusinessAddress(0, BusinessAddressAssembler.ToEntity(modelDTO));
                returnAddress = modelDTO;
            }

            return returnAddress;
        }

        public bool Delete(int id)
        {
            Boolean isDeleted = false;

            if (id > 0)
            {
                try
                {
                    businessAddressesRepo.DeleteBusinessAddress(id);
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
            _BusinessAddressesRepo.Dispose();
        }
    }
}
