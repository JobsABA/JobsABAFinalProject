using JobsInABA.DAL.Repositories;
using JobsInABA.DAL.Entities;
using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;
using System;
using System.Collections.Generic;

namespace JobsInABA.BL
{
    public class UserPhoneBL : IDisposable
    {
        UserPhonesRepo _UserPhoneRepo;

        private UserPhonesRepo userPhoneRepo
        {
            get
            {
                if (_UserPhoneRepo == null) _UserPhoneRepo = new UserPhonesRepo();
                return _UserPhoneRepo;
            }
        }

        public IEnumerable<UserPhoneDTO> Get()
        {
            IEnumerable<UserPhoneDTO> userPhone = userPhoneRepo.GetUserPhones().ToDTOs();
            return userPhone;
        }


        public UserPhoneDTO Get(int id)
        {
            UserPhoneDTO userPhoneDTO = null;
            if (id > 0)
            {
                userPhoneDTO = userPhoneRepo.GetUserPhone(id).ToDTO();
            }

            return userPhoneDTO;
        }

        public UserPhoneDTO Create(UserPhoneDTO modelDTO)
        {
            if (modelDTO != null)
            {
                return UserPhoneAssembler.ToDTO(userPhoneRepo.CreateUserPhone(UserPhoneAssembler.ToEntity(modelDTO)));
            }

            return null;
        }

        public UserPhoneDTO Update(UserPhoneDTO modelDTO)
        {
            UserPhoneDTO returnUserPhone = null;
            if (modelDTO != null && modelDTO.UserPhoneID > 0)
            {
                userPhoneRepo.UpdateUserPhone(0, UserPhoneAssembler.ToEntity(modelDTO));
                returnUserPhone = modelDTO;
            }

            return returnUserPhone;
        }

        public bool Delete(int id)
        {
            try
            {
                userPhoneRepo.DeleteUserPhone(id);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void Dispose()
        {
            _UserPhoneRepo.Dispose();
        }
    }
}
