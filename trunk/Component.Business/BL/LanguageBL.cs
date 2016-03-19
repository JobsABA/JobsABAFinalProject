using System;
using System.Collections.Generic;
using JobsInABA.DAL.Repositories;
using JobsInABA.DAL.Entities;
using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;

namespace JobsInABA.BL
{
    public class LanguageBL : IDisposable
    {
        LanguagesRepo _LanguagesRepo;

        private LanguagesRepo LanguagesRepo
        {
            get
            {
                if (_LanguagesRepo == null) _LanguagesRepo = new LanguagesRepo();
                return _LanguagesRepo;
            }
        }

        public List<LanguageDTO> Get()
        {
            IEnumerable<Language> oLanguage = LanguagesRepo.Get();
            return LanguageAssembler.ToDTOs(oLanguage);
        }

        public LanguageDTO Get(int id)
        {
            LanguageDTO oLanguageDTO = null;
            if (id > 0)
            {
                Language oLanguage = LanguagesRepo.Get(id);
                if (oLanguage != null)
                {
                    oLanguageDTO = LanguageAssembler.ToDTO(oLanguage);
                }
            }

            return oLanguageDTO;
        }

        public LanguageDTO Create(LanguageDTO modelDTO)
        {
            if (modelDTO != null)
            {
                return LanguageAssembler.ToDTO(LanguagesRepo.Create(LanguageAssembler.ToEntity(modelDTO)));
            }

            return null;
        }

        public LanguageDTO Update(LanguageDTO modelDTO)
        {
            LanguageDTO returnLanguage = null;
            if (modelDTO != null && modelDTO.LanguageID > 0)
            {
                LanguagesRepo.Update(0, LanguageAssembler.ToEntity(modelDTO));
                returnLanguage = modelDTO;
            }

            return returnLanguage;
        }

        public bool Delete(int id)
        {

            Boolean isDeleted = false;

            if (id > 0)
            {
                isDeleted = (LanguagesRepo.Delete(id) == null) ? true : false;
            }

            return isDeleted;
        }

        public void Dispose()
        {
            _LanguagesRepo.Dispose();
        }
    }
}