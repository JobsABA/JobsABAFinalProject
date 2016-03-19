using System;
using System.Collections.Generic;
using JobsInABA.DAL.Repositories;
using JobsInABA.DAL.Entities;
using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;

namespace JobsInABA.BL
{
    public class AchievementBL : IDisposable
    {
        AchievementsRepo _AchievementsRepo;

        private AchievementsRepo achievementsRepo
        {
            get
            {
                if (_AchievementsRepo == null) _AchievementsRepo = new AchievementsRepo();
                return _AchievementsRepo;
            }
        }

        public List<AchievementDTO> Get()
        {
            IEnumerable<Achievement> oAchievement = achievementsRepo.Get();
            return AchievementAssembler.ToDTOs(oAchievement);
        }

        public AchievementDTO Get(int id)
        {
            AchievementDTO oAchievementDTO = null;
            if (id > 0)
            {
                Achievement oAchievement = achievementsRepo.Get(id);
                if (oAchievement != null)
                {
                    oAchievementDTO = AchievementAssembler.ToDTO(oAchievement);
                }
            }

            return oAchievementDTO;
        }

        public AchievementDTO Create(AchievementDTO modelDTO)
        {
            if (modelDTO != null)
            {
                return AchievementAssembler.ToDTO(achievementsRepo.Create(AchievementAssembler.ToEntity(modelDTO)));
            }

            return null;
        }

        public AchievementDTO Update(AchievementDTO modelDTO)
        {
            AchievementDTO returnAchievement = null;
            if (modelDTO != null && modelDTO.AchievementID > 0)
            {
                achievementsRepo.Update(0, AchievementAssembler.ToEntity(modelDTO));
                returnAchievement = modelDTO;
            }

            return returnAchievement;
        }

        public bool Delete(int id)
        {

            Boolean isDeleted = false;

            if (id > 0)
            {
                isDeleted = (achievementsRepo.Delete(id) == null) ? true : false;
            }

            return isDeleted;
        }

        public void Dispose()
        {
            _AchievementsRepo.Dispose();
        }
    }
}