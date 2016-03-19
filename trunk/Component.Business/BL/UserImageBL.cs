using System;
using System.Collections.Generic;
using JobsInABA.DAL.Repositories;
using JobsInABA.DAL.Entities;
using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;

namespace JobsInABA.BL
{
    public class UserImageBL : IDisposable
    {
        UserImagesRepo _UserImagesRepo;

        private UserImagesRepo UserImagesRepo
        {
            get
            {
                if (_UserImagesRepo == null) _UserImagesRepo = new UserImagesRepo();
                return _UserImagesRepo;
            }
        }

        public List<UserImageDTO> Get()
        {
            IEnumerable<UserImage> oUserImage = UserImagesRepo.Get();
            return UserImageAssembler.ToDTOs(oUserImage);
        }

        public UserImageDTO Get(int id)
        {
            UserImageDTO oUserImageDTO = new UserImageDTO();
            if (id > 0)
            {
                UserImage oUserImage = UserImagesRepo.Get(id);
                if (oUserImage != null)
                {
                    oUserImageDTO = UserImageAssembler.ToDTO(oUserImage);
                }
            }

            return oUserImageDTO;
        }

        public UserImageDTO Create(UserImageDTO modelDTO)
        {
            if (modelDTO != null)
            {
                return UserImageAssembler.ToDTO(UserImagesRepo.Create(UserImageAssembler.ToEntity(modelDTO)));
            }

            return null;
        }

        public UserImageDTO Update(UserImageDTO modelDTO)
        {
            UserImageDTO returnUserImage = null;
            if (modelDTO != null && modelDTO.UserImageID > 0)
            {
                UserImagesRepo.Update(0, UserImageAssembler.ToEntity(modelDTO));
                returnUserImage = modelDTO;
            }

            return returnUserImage;
        }

        public bool Delete(int id)
        {

            Boolean isDeleted = false;

            if (id > 0)
            {
                isDeleted = (UserImagesRepo.Delete(id) == null) ? true : false;
            }

            return isDeleted;
        }

        public bool CheckUserImageExist(int userid)
        {
            return UserImagesRepo.UserImageExists(userid);
        }

        public bool CheckUserPrimaryImageExists(int userid)
        {
            return UserImagesRepo.UserPrimaryImageExists(userid);
        }
        
        public void Dispose()
        {
            _UserImagesRepo.Dispose();
        }
    }
}