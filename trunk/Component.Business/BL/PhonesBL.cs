using System;
using JobsInABA.DAL.Repositories;
using JobsInABA.DAL.Entities;
using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;

namespace JobsInABA.BL
{
    public class PhonesBL : IDisposable
    {
        PhonesRepo _PhoneRepo;

        private PhonesRepo phoneRepo
        {
            get
            {
                if (_PhoneRepo == null) _PhoneRepo = new PhonesRepo();
                return _PhoneRepo;
            }
        }

        public PhoneDTO Get(int id)
        {
            PhoneDTO oPhoneDTO = null;
            if (id > 0)
            {
                Phone oPhone = phoneRepo.GetPhoneByID(id);
                if (oPhone != null)
                {
                    oPhoneDTO = PhoneAssembler.ToDTO(oPhone);
                    if (oPhone.TypeCode != null) oPhoneDTO.TypeCode = TypeCodeAssembler.ToDTO(oPhone.TypeCode);
                    if (oPhone.TypeCode != null && oPhone.TypeCode.ClassType != null) oPhoneDTO.TypeCode.ClassType = ClassTypeAssembler.ToDTO(oPhone.TypeCode.ClassType);
                }

            }

            return oPhoneDTO;
        }

        public PhoneDTO Create(PhoneDTO modelDTO)
        {
            if (modelDTO != null)
            {
                return PhoneAssembler.ToDTO(phoneRepo.CreatePhone(PhoneAssembler.ToEntity(modelDTO)));
            }

            return null;
        }

        public PhoneDTO Update(PhoneDTO modelDTO)
        {
            PhoneDTO returnPhone = null;
            if (modelDTO != null && modelDTO.PhoneID > 0)
            {
                returnPhone = PhoneAssembler.ToDTO(phoneRepo.UpdatePhone(PhoneAssembler.ToEntity(modelDTO)));
            }

            return returnPhone;
        }

        public bool Delete(int id)
        {

            Boolean isDeleted = false;

            if (id > 0)
            {
                isDeleted = phoneRepo.DeletePhone(id);
            }

            return isDeleted;
        }

        public void Dispose()
        {
            _PhoneRepo.Dispose();
        }
    }
}
