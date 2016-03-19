using System;
using System.Collections.Generic;
using JobsInABA.DAL.Repositories;
using JobsInABA.DAL.Entities;
using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;

namespace JobsInABA.BL
{
    public class SkillBL : IDisposable
    {
        SkillsRepo _SkillsRepo;

        private SkillsRepo SkillsRepo
        {
            get
            {
                if (_SkillsRepo == null) _SkillsRepo = new SkillsRepo();
                return _SkillsRepo;
            }
        }

        public List<SkillDTO> Get()
        {
            IEnumerable<Skill> oSkill = SkillsRepo.Get();
            return SkillAssembler.ToDTOs(oSkill);
        }

        public SkillDTO Get(int id)
        {
            SkillDTO oSkillDTO = null;
            if (id > 0)
            {
                Skill oSkill = SkillsRepo.Get(id);
                if (oSkill != null)
                {
                    oSkillDTO = SkillAssembler.ToDTO(oSkill);
                }
            }

            return oSkillDTO;
        }

        public SkillDTO Create(SkillDTO modelDTO)
        {
            if (modelDTO != null)
            {
                return SkillAssembler.ToDTO(SkillsRepo.Create(SkillAssembler.ToEntity(modelDTO)));
            }

            return null;
        }

        public SkillDTO Update(SkillDTO modelDTO)
        {
            SkillDTO returnSkill = null;
            if (modelDTO != null && modelDTO.SkillID > 0)
            {
                SkillsRepo.Update(0, SkillAssembler.ToEntity(modelDTO));
                returnSkill = modelDTO;
            }

            return returnSkill;
        }

        public bool Delete(int id)
        {

            Boolean isDeleted = false;

            if (id > 0)
            {
                isDeleted = (SkillsRepo.Delete(id) == null) ? true : false;
            }

            return isDeleted;
        }

        public void Dispose()
        {
            _SkillsRepo.Dispose();
        }
    }
}