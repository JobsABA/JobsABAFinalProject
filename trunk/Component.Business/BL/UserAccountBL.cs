using System;
using JobsInABA.DAL.Repositories;
using JobsInABA.DAL.Entities;
using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;

namespace JobsInABA.BL
{
    public class UserAccountBL : IDisposable
    {
        UserAccountRepo _UserAccountRepo;

        private UserAccountRepo userAccountRepo
        {
            get
            {
                if (_UserAccountRepo == null) _UserAccountRepo = new UserAccountRepo();
                return _UserAccountRepo;
            }
        }

        public UserAccountDTO Get(int id)
        {
            UserAccountDTO oUserAccountDTO = null;
            if (id > 0)
            {
                UserAccount oUserAccount = userAccountRepo.GetUserAccountByID(id);
            }

            return oUserAccountDTO;
        }

        public UserAccountDTO GetByUserID(int UserID)
        {
            return UserAccountAssembler.ToDTO(userAccountRepo.GetUserAccountByUserID(UserID));
        }

        public UserAccountDTO Create(UserAccountDTO modelDTO)
        {
            if (modelDTO != null)
            {
                var userAccount = UserAccountAssembler.ToEntity(modelDTO);
                return UserAccountAssembler.ToDTO(userAccountRepo.CreateUserAccount(userAccount));
            }
            return null;
        }

        public UserAccountDTO Update(UserAccountDTO modelDTO)
        {
            UserAccountDTO returnUserAccount = null;
            if (modelDTO != null && (modelDTO.UserAccountID > 0 || modelDTO.UserName != null))
            {
                userAccountRepo.UpdateUserAccount(UserAccountAssembler.ToEntity(modelDTO));
                returnUserAccount = modelDTO;
            }

            return returnUserAccount;
        }

        public bool Delete(int id)
        {

            Boolean isDeleted = false;

            if (id > 0)
            {
                isDeleted = userAccountRepo.DeleteUserAccount(id);
            }

            return isDeleted;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool ActivateUser(int UserID)
        {
            return userAccountRepo.ActivateUser(UserID);
        }
    }
}
