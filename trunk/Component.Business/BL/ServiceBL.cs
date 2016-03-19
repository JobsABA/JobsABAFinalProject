using System;
using System.Collections.Generic;
using JobsInABA.DAL.Repositories;
using JobsInABA.DAL.Entities;
using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;

namespace JobsInABA.BL
{
    public class ServiceBL : IDisposable
    {
        ServicesRepo _ServicesRepo;

        private ServicesRepo ServicesRepo
        {
            get
            {
                if (_ServicesRepo == null) _ServicesRepo = new ServicesRepo();
                return _ServicesRepo;
            }
        }

        public List<ServiceDTO> Get()
        {
            IEnumerable<Service> oService = ServicesRepo.Get();
            return ServiceAssembler.ToDTOs(oService);
        }

        public ServiceDTO Get(int id)
        {
            ServiceDTO oServiceDTO = null;
            if (id > 0)
            {
                Service oService = ServicesRepo.Get(id);
                if (oService != null)
                {
                    oServiceDTO = ServiceAssembler.ToDTO(oService);
                }
            }

            return oServiceDTO;
        }

        public ServiceDTO Create(ServiceDTO modelDTO)
        {
            if (modelDTO != null)
            {
                return ServiceAssembler.ToDTO(ServicesRepo.Create(ServiceAssembler.ToEntity(modelDTO)));
            }

            return null;
        }

        public ServiceDTO Update(ServiceDTO modelDTO)
        {
            ServiceDTO returnService = null;
            if (modelDTO != null && modelDTO.ServiceID > 0)
            {
                ServicesRepo.Update(0, ServiceAssembler.ToEntity(modelDTO));
                returnService = modelDTO;
            }

            return returnService;
        }

        public bool Delete(int id)
        {

            Boolean isDeleted = false;

            if (id > 0)
            {
                isDeleted = (ServicesRepo.Delete(id) == null) ? true : false;
            }

            return isDeleted;
        }

        public void Dispose()
        {
            _ServicesRepo.Dispose();
        }
    }
}