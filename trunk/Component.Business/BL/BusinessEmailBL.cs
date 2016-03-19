using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;
using JobsInABA.DAL.Entities;
using JobsInABA.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace JobsInABA.BL
{
    public class BusinessEmailBL : IDisposable
    {
        BusinessEmailsRepo _BusinessEmailsRepos;

        private BusinessEmailsRepo businessEmailsRepos
        {
            get
            {
                if (_BusinessEmailsRepos == null) _BusinessEmailsRepos = new BusinessEmailsRepo();
                return _BusinessEmailsRepos;
            }
        }

        public IEnumerable<BusinessEmailDTO> Get()
        {
            IEnumerable<BusinessEmailDTO> oBusinessEmails = businessEmailsRepos.GetBusinessEmails().ToDTOs();
            return oBusinessEmails;
        }

        public BusinessEmailDTO Get(int id)
        {
            BusinessEmailDTO oBusinessEmailsDTO = null;
            if (id > 0)
            {
                BusinessEmail oBusinessEmails = businessEmailsRepos.GetBusinessEmail(id);
            }

            return oBusinessEmailsDTO;
        }

        public BusinessEmailDTO Create(BusinessEmailDTO modelDTO)
        {
            if (modelDTO != null)
            {
                return BusinessEmailAssembler.ToDTO(businessEmailsRepos.CreateBusinessEmail(BusinessEmailAssembler.ToEntity(modelDTO)));
            }

            return null;
        }

        public BusinessEmailDTO Update(BusinessEmailDTO modelDTO)
        {
            BusinessEmailDTO returnEmails = null;
            if (modelDTO != null && modelDTO.EmailID > 0)
            {
                businessEmailsRepos.UpdateBusinessEmail(0, BusinessEmailAssembler.ToEntity(modelDTO));
                returnEmails = modelDTO;
            }

            return returnEmails;
        }

        public bool Delete(int id)
        {
            Boolean isDeleted = false;

            if (id > 0)
            {
                try
                {
                    businessEmailsRepos.DeleteBusinessEmail(id);
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
            _BusinessEmailsRepos.Dispose();
        }
    }
}
