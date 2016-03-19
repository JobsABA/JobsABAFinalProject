using JobsInABA.DAL.Repositories;
using JobsInABA.DAL.Entities;
using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;
using System;
using System.Collections.Generic;

namespace JobsInABA.BL
{
    public class UserAddressBL : IDisposable
    {
        UserAddressesRepo _UserAddressRepo;

        private UserAddressesRepo userAddressRepo
        {
            get
            {
                if (_UserAddressRepo == null) _UserAddressRepo = new UserAddressesRepo();
                return _UserAddressRepo;
            }
        }

        public IEnumerable<UserAddressDTO> Get()
        {
            IEnumerable<UserAddressDTO> oUserAddress = userAddressRepo.GetUserAddresses().ToDTOs();
            return oUserAddress;
        }

        public UserAddressDTO Get(int id)
        {
            UserAddressDTO oUserAddressDTO = null;
            if (id > 0)
            {
                oUserAddressDTO = userAddressRepo.GetUserAddress(id).ToDTO();
            }

            return oUserAddressDTO;
        }

        public UserAddressDTO Create(UserAddressDTO modelDTO)
        {
            if (modelDTO != null)
            {
                return UserAddressAssembler.ToDTO(userAddressRepo.CreateUserAddress(UserAddressAssembler.ToEntity(modelDTO)));
            }

            return null;
        }

        public UserAddressDTO Update(UserAddressDTO modelDTO)
        {
            UserAddressDTO returnUserAddress = null;
            if (modelDTO != null && modelDTO.UserAddressID > 0)
            {
                userAddressRepo.UpdateUserAddress(0, UserAddressAssembler.ToEntity(modelDTO));
                returnUserAddress = modelDTO;
            }

            return returnUserAddress;
        }

        public bool Delete(int id)
        {
            try
            {
                userAddressRepo.DeleteUserAddress(id);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void Dispose()
        {
            _UserAddressRepo.Dispose();
        }
    }
}
