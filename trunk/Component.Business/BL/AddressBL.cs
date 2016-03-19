using System;
using System.Collections.Generic;
using JobsInABA.DAL.Repositories;
using JobsInABA.DAL.Entities;
using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;

namespace JobsInABA.BL
{
    public class AddressBL : IDisposable
    {
        AddressRepo _AddressRepo;

        private AddressRepo addressRepo
        {
            get
            {
                if (_AddressRepo == null) _AddressRepo = new AddressRepo();
                return _AddressRepo;
            }
        }

        public List<AddressDTO> Get()
        {
            IEnumerable<Address> oAddress = addressRepo.GetAddress();
            return AddressAssembler.ToDTOs(oAddress);
        }

        public AddressDTO Get(int id)
        {
            AddressDTO oAddressDTO = null;
            if (id > 0)
            {
                Address oAddress = addressRepo.GetAddressByID(id);
                if (oAddress != null)
                {
                    oAddressDTO = AddressAssembler.ToDTO(oAddress);
                    if (oAddress.Country != null) oAddressDTO.Country = CountryAssembler.ToDTO(oAddress.Country);
                    if (oAddress.TypeCode != null) oAddressDTO.TypeCode = TypeCodeAssembler.ToDTO(oAddress.TypeCode);
                    if (oAddress.TypeCode != null && oAddress.TypeCode.ClassType != null) oAddressDTO.TypeCode.ClassType = ClassTypeAssembler.ToDTO(oAddress.TypeCode.ClassType);
                }

            }

            return oAddressDTO;
        }

        public AddressDTO Create(AddressDTO modelDTO)
        {
            if (modelDTO != null)
            {
                return AddressAssembler.ToDTO(addressRepo.CreateAddress(AddressAssembler.ToEntity(modelDTO)));
            }

            return null;
        }

        public AddressDTO Update(AddressDTO modelDTO)
        {
            AddressDTO returnAddress = null;
            if (modelDTO != null && modelDTO.AddressID > 0)
            {
                addressRepo.UpdateAddress(AddressAssembler.ToEntity(modelDTO));
                returnAddress = modelDTO;
            }

            return returnAddress;
        }

        public bool Delete(int id)
        {

            Boolean isDeleted = false;

            if (id > 0)
            {
                isDeleted = addressRepo.DeleteAddress(id);
            }

            return isDeleted;
        }

        public void Dispose()
        {
            //_AddressRepo.Dispose();
        }
    }
}
