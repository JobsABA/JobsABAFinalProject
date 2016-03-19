using JobsInABA.DAL.Repositories;
using JobsInABA.DAL.Entities;
using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;
using System;
using System.Collections.Generic;

namespace JobsInABA.BL
{
    public class UserEmailBL : IDisposable
    {
        UserEmailsRepo _UserEmailRepo;

        private UserEmailsRepo userEmailRepo
        {
            get
            {
                if (_UserEmailRepo == null) _UserEmailRepo = new UserEmailsRepo();
                return _UserEmailRepo;
            }
        }

        public IEnumerable<UserEmailDTO> Get()
        {
            IEnumerable<UserEmailDTO> userEmail = userEmailRepo.GetUserEmails().ToDTOs();
            return userEmail;
        }

        public UserEmailDTO Get(int id)
        {
            UserEmailDTO userEmailDTO = null;
            if (id > 0)
            {
                userEmailDTO = userEmailRepo.GetUserEmail(id).ToDTO();
            }

            return userEmailDTO;
        }

        public UserEmailDTO Create(UserEmailDTO modelDTO)
        {
            if (modelDTO != null)
            {
                return UserEmailAssembler.ToDTO(userEmailRepo.CreateUserEmail(UserEmailAssembler.ToEntity(modelDTO)));
            }

            return null;
        }

        public UserEmailDTO Update(UserEmailDTO modelDTO)
        {
            UserEmailDTO returnUserEmail = null;
            if (modelDTO != null && modelDTO.EmailID > 0)
            {
                userEmailRepo.UpdateUserEmail(0, UserEmailAssembler.ToEntity(modelDTO));
                returnUserEmail = modelDTO;
            }

            return returnUserEmail;
        }

        public bool Delete(int id)
        {
            try
            {
                userEmailRepo.DeleteUserEmail(id);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void Dispose()
        {
            _UserEmailRepo.Dispose();
        }
    }
}
