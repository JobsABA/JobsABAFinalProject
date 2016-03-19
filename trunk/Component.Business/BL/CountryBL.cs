using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;
using JobsInABA.DAL.Entities;
using JobsInABA.DAL.Repositories;
using System;

namespace JobsInABA.BL
{
    public class CountryBL : IDisposable
    {
        CountriesRepo _CountryRepos;

        private CountriesRepo countryRepos
        {
            get
            {
                if (_CountryRepos == null) _CountryRepos = new CountriesRepo();
                return _CountryRepos;
            }
        }

        public CountryDTO Get(int id)
        {
            CountryDTO oCountryDTO = null;
            if (id > 0)
            {
                Country oCountry = countryRepos.GetCountry(id);
            }

            return oCountryDTO;
        }

        public CountryDTO Create(CountryDTO modeDTO)
        {
            if (modeDTO != null)
            {
                return CountryAssembler.ToDTO(countryRepos.CreateCountry(CountryAssembler.ToEntity(modeDTO)));
            }

            return null;
        }

        public CountryDTO Update(CountryDTO modelDTO)
        {
            CountryDTO returnUserMap = null;
            if (modelDTO != null && modelDTO.CountryID > 0)
            {
                countryRepos.UpdateCountry(0, CountryAssembler.ToEntity(modelDTO));
                returnUserMap = modelDTO;
            }

            return returnUserMap;
        }

        public bool Delete(int id)
        {
            Boolean isDeleted = false;

            if (id > 0)
            {
                try
                {
                    countryRepos.DeleteCountry(id);
                }
                catch
                {
                    return false;
                }
            }
            return isDeleted;
        }

        public void Dispose()
        {
            _CountryRepos.Dispose();
        }
    }
}