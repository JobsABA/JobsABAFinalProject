using System;
using System.Collections.Generic;
using JobsInABA.DAL.Repositories;
using JobsInABA.DAL.Entities;
using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;

namespace JobsInABA.BL
{
    public class BusinessBL : IDisposable
    {
        BusinessRepo _BusinessRepo;
        private BusinessRepo businessRepo
        {
            get
            {
                if (_BusinessRepo == null) _BusinessRepo = new BusinessRepo();
                return _BusinessRepo;
            }
        }

        public List<BusinessDTO> Get()
        {
            return BusinessAssembler.ToDTOs(businessRepo.GetBusinesss());
        }

        public BusinessDTO Get(int id)
        {
            BusinessDTO oBusinessDTO = null;
            if (id > 0)
            {
                Business oBusiness = businessRepo.GetBusinessByID(id);
                if (oBusiness != null) oBusinessDTO = BusinessAssembler.ToDTO(oBusiness);
            }

            return oBusinessDTO;
        }



        public BusinessDTO Create(BusinessDTO modelDTO)
        {
            if (modelDTO != null)
            {
                return BusinessAssembler.ToDTO(businessRepo.CreateBusiness(BusinessAssembler.ToEntity(modelDTO)));
            }

            return null;
        }

        public BusinessDTO Update(BusinessDTO modelDTO)
        {
            BusinessDTO returnBusiness = null;
            if (modelDTO != null && modelDTO.BusinessID > 0)
            {
                businessRepo.UpdateBusiness(BusinessAssembler.ToEntity(modelDTO));
                returnBusiness = modelDTO;
            }

            return returnBusiness;
        }

        public bool Delete(int id)
        {

            Boolean isDeleted = false;

            if (id > 0)
            {
                isDeleted = businessRepo.DeleteBusiness(id);
            }

            return isDeleted;
        }

        public void Dispose()
        {
            _BusinessRepo.Dispose();
        }

        public List<BusinessDTO> GetBusinessesBySearch(string companyname, string city, int? from, int? to, out int count)
        {
            var businessesBySearch = businessRepo.GetBusinessesBySearch(companyname, city, from, to, out count);
            return BusinessAssembler.ToDTOs(businessesBySearch);
        }



        public List<Business> GetBusinessesNameID()
        {
            return businessRepo.GetBusinessesNameID();
        }
    }
}
