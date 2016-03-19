using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;
using JobsInABA.DAL.Entities;
using JobsInABA.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace JobsInABA.BL
{
    public class EducationBL : IDisposable
    {
        EducationsRepo _EducationsRepo;

        private EducationsRepo EducationsRepo
        {
            get
            {
                if (_EducationsRepo == null) _EducationsRepo = new EducationsRepo();
                return _EducationsRepo;
            }
        }

        public List<EducationDTO> Get()
        {
            IEnumerable<Education> oEducation = EducationsRepo.Get();
            return EducationAssembler.ToDTOs(oEducation);
        }

        public EducationDTO Get(int id)
        {
            EducationDTO oEducationDTO = null;
            if (id > 0)
            {
                Education oEducation = EducationsRepo.Get(id);
                if (oEducation != null)
                {
                    oEducationDTO = EducationAssembler.ToDTO(oEducation);
                }
            }

            return oEducationDTO;
        }

        public EducationDTO Create(EducationDTO modelDTO)
        {
            if (modelDTO != null)
            {
                return EducationAssembler.ToDTO(EducationsRepo.Create(EducationAssembler.ToEntity(modelDTO)));
            }

            return null;
        }

        public EducationDTO Update(EducationDTO modelDTO)
        {
            EducationDTO returnEducation = null;
            if (modelDTO != null && modelDTO.EducationID > 0)
            {
                EducationsRepo.Update(0, EducationAssembler.ToEntity(modelDTO));
                returnEducation = modelDTO;
            }

            return returnEducation;
        }

        public bool Delete(int id)
        {

            Boolean isDeleted = false;

            if (id > 0)
            {
                isDeleted = (EducationsRepo.Delete(id) == null) ? true : false;
            }

            return isDeleted;
        }

        public void Dispose()
        {
            _EducationsRepo.Dispose();
        }
    }
}