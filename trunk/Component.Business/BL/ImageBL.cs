using System;
using System.Collections.Generic;
using JobsInABA.DAL.Repositories;
using JobsInABA.DAL.Entities;
using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;

namespace JobsInABA.BL
{
    public class ImageBL : IDisposable
    {
        ImagesRepo _ImagesRepo;

        private ImagesRepo ImagesRepo
        {
            get
            {
                if (_ImagesRepo == null) _ImagesRepo = new ImagesRepo();
                return _ImagesRepo;
            }
        }

        public List<ImageDTO> Get()
        {
            IEnumerable<Image> oImage = ImagesRepo.Get();
            return ImageAssembler.ToDTOs(oImage);
        }

        public ImageDTO Get(int id)
        {
            ImageDTO oImageDTO = null;
            if (id > 0)
            {
                Image oImage = ImagesRepo.Get(id);
                if (oImage != null)
                {
                    oImageDTO = ImageAssembler.ToDTO(oImage);
                }
            }

            return oImageDTO;
        }

        public ImageDTO Create(ImageDTO modelDTO)
        {
            if (modelDTO != null)
            {
                return ImageAssembler.ToDTO(ImagesRepo.Create(ImageAssembler.ToEntity(modelDTO)));
            }

            return null;
        }

        public ImageDTO Update(ImageDTO modelDTO)
        {
            ImageDTO returnImage = null;
            if (modelDTO != null && modelDTO.ImageID > 0)
            {
                ImagesRepo.Update(0, ImageAssembler.ToEntity(modelDTO));
                returnImage = modelDTO;
            }

            return returnImage;
        }

        public bool Delete(int id)
        {

            Boolean isDeleted = false;

            if (id > 0)
            {
                isDeleted = (ImagesRepo.Delete(id) == null) ? true : false;
            }

            return isDeleted;
        }

        public void Dispose()
        {
            _ImagesRepo.Dispose();
        }
    }
}