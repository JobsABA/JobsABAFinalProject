using System;
using System.Collections.Generic;
using JobsInABA.DAL.Repositories;
using JobsInABA.DAL.Entities;
using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;

namespace JobsInABA.BL
{
    public class ExperienceBL : IDisposable
    {
        ExperiencesRepo _ExperiencesRepo;

        private ExperiencesRepo ExperiencesRepo
        {
            get
            {
                if (_ExperiencesRepo == null) _ExperiencesRepo = new ExperiencesRepo();
                return _ExperiencesRepo;
            }
        }

        public List<ExperienceDTO> Get()
        {
            IEnumerable<Experience> oExperience = ExperiencesRepo.Get();
            return ExperienceAssembler.ToDTOs(oExperience);
        }

        public ExperienceDTO Get(int id)
        {
            ExperienceDTO oExperienceDTO = null;
            if (id > 0)
            {
                Experience oExperience = ExperiencesRepo.Get(id);
                if (oExperience != null)
                {
                    oExperienceDTO = ExperienceAssembler.ToDTO(oExperience);
                }
            }

            return oExperienceDTO;
        }

        public ExperienceDTO Create(ExperienceDTO modelDTO)
        {
            if (modelDTO != null)
            {
                return ExperienceAssembler.ToDTO(ExperiencesRepo.Create(ExperienceAssembler.ToEntity(modelDTO)));
            }

            return null;
        }

        public ExperienceDTO Update(ExperienceDTO modelDTO)
        {
            ExperienceDTO returnExperience = null;
            if (modelDTO != null && modelDTO.ExperienceID > 0)
            {
                ExperiencesRepo.Update(0, ExperienceAssembler.ToEntity(modelDTO));
                returnExperience = modelDTO;
            }

            return returnExperience;
        }

        public bool Delete(int id)
        {

            Boolean isDeleted = false;

            if (id > 0)
            {
                isDeleted = (ExperiencesRepo.Delete(id) == null) ? true : false;
            }

            return isDeleted;
        }

        public void Dispose()
        {
            _ExperiencesRepo.Dispose();
        }
    }
}