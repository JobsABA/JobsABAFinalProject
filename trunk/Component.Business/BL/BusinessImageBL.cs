using System;
using System.Collections.Generic;
using JobsInABA.DAL.Repositories;
using JobsInABA.DAL.Entities;
using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;

namespace JobsInABA.BL
{
    public class BusinessImageBL : IDisposable
    {
        BusinessImagesRepo _BusinessImagesRepo;

        private BusinessImagesRepo BusinessImagesRepo
        {
            get
            {
                if (_BusinessImagesRepo == null) _BusinessImagesRepo = new BusinessImagesRepo();
                return _BusinessImagesRepo;
            }
        }

        public List<BusinessImageDTO> Get()
        {
            IEnumerable<BusinessImage> oBusinessImage = BusinessImagesRepo.Get();
            return BusinessImageAssembler.ToDTOs(oBusinessImage);
        }

        public BusinessImageDTO Get(int id)
        {
            BusinessImageDTO oBusinessImageDTO = null;
            if (id > 0)
            {
                BusinessImage oBusinessImage = BusinessImagesRepo.Get(id);
                if (oBusinessImage != null)
                {
                    oBusinessImageDTO = BusinessImageAssembler.ToDTO(oBusinessImage);
                }
            }

            return oBusinessImageDTO;
        }

        public BusinessImageDTO Create(BusinessImageDTO modelDTO)
        {
            if (modelDTO != null)
            {
                return BusinessImageAssembler.ToDTO(BusinessImagesRepo.Create(BusinessImageAssembler.ToEntity(modelDTO)));
            }

            return null;
        }

        public BusinessImageDTO Update(BusinessImageDTO modelDTO)
        {
            BusinessImageDTO returnBusinessImage = null;
            if (modelDTO != null && modelDTO.BusinessImageID > 0)
            {
                BusinessImagesRepo.Update(0, BusinessImageAssembler.ToEntity(modelDTO));
                returnBusinessImage = modelDTO;
            }

            return returnBusinessImage;
        }

        public bool Delete(int id)
        {

            Boolean isDeleted = false;

            if (id > 0)
            {
                isDeleted = (BusinessImagesRepo.Delete(id) == null) ? true : false;
            }

            return isDeleted;
        }

        public void Dispose()
        {
            _BusinessImagesRepo.Dispose();
        }

        public bool CheckBusinessPrimaryImageExists(int businessID)
        {
            return BusinessImagesRepo.BusinessPrimaryImageExists(businessID);
        }
    }
}