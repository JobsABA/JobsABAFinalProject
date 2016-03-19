using System;
using System.Collections.Generic;
using System.Linq;
using JobsInABA.DAL.Repositories;
using JobsInABA.DAL.Entities;
using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;

namespace JobsInABA.BL
{
    public class UsersBL : IDisposable
    {
        UsersRepo _UsersRepo;

        private UsersRepo usersRepo
        {
            get
            {
                if (_UsersRepo == null) _UsersRepo = new UsersRepo();
                return _UsersRepo;
            }
        }


        public UserDTO CanLogIn(string username, string password)
        {
            int? userId = usersRepo.CanLogIn(username, password);
            if (userId.HasValue)
            {
                var user = usersRepo.GetUserByID(userId.Value);
                return user.ToDTO();
            }
            return null;
        }

        public UserDTO Get(int id)
        {

            UserDTO userDTO = null;
            if (id > 0)
            {
                User oUser = usersRepo.GetUserByID(id);
                if (oUser != null)
                {
                    userDTO = UserAssembler.ToDTO(oUser);
                }
            }
            return userDTO;
        }

        public List<UserDTO> Get()
        {
            List<UserDTO> userDTO = new List<UserDTO>();
            List<User> oUsers = usersRepo.GetUsers().ToList();
            if (oUsers != null && oUsers.Count > 0)
            {
                userDTO = UserAssembler.ToDTOs(oUsers);
            }
            return userDTO;
        }

        public List<UserDTO> GetUsersBySearch(string searchText, int from, int to)
        {
            return UserAssembler.ToDTOs(usersRepo.GetUsersBySearch(searchText, from, to));
        }

        public UserDTO Create(UserDTO modelDTO)
        {
            if (modelDTO != null)
            {
                User oUser = UserAssembler.ToEntity(modelDTO);
                return UserAssembler.ToDTO(usersRepo.CreateUser(oUser));
            }
            return null;
        }

        public UserDTO Update(UserDTO modelDTO)
        {
            UserDTO returnUser = null;
            if (modelDTO != null && modelDTO.UserID > 0)
            {
                usersRepo.UpdateUser(UserAssembler.ToEntity(modelDTO));
                returnUser = modelDTO;
            }
            return returnUser;
        }


        public bool Delete(int id)
        {
            Boolean isDeleted = false;
            if (id > 0)
            {
                isDeleted = usersRepo.DeleteUser(id);
            }
            return isDeleted;
        }

        public void Dispose()
        {
            _UsersRepo.Dispose();
        }
    }
}
