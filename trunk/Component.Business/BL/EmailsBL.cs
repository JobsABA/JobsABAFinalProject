using System;
using JobsInABA.DAL.Repositories;
using JobsInABA.DAL.Entities;
using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;

namespace JobsInABA.BL
{
    public class EmailsBL : IDisposable
    {
        EmailsRepo _EmailRepo;

        private EmailsRepo emailRepo
        {
            get
            {
                if (_EmailRepo == null) _EmailRepo = new EmailsRepo();
                return _EmailRepo;
            }
        }

        public EmailDTO Get(int id)
        {
            EmailDTO emailDTO = null;
            if (id > 0)
            {
                Email oEmail = emailRepo.GetEmailByID(id);
                if (oEmail != null)
                {
                    emailDTO = EmailAssembler.ToDTO(oEmail);
                    if (oEmail.TypeCode != null) emailDTO.TypeCode = TypeCodeAssembler.ToDTO(oEmail.TypeCode);
                    if (oEmail.TypeCode != null && oEmail.TypeCode.ClassType != null) emailDTO.TypeCode.ClassType = ClassTypeAssembler.ToDTO(oEmail.TypeCode.ClassType);
                }

            }

            return emailDTO;
        }

        public EmailDTO Create(EmailDTO modelDTO)
        {
            if (modelDTO != null)
            {
                return EmailAssembler.ToDTO(emailRepo.CreateEmail(EmailAssembler.ToEntity(modelDTO)));
            }

            return null;
        }

        public EmailDTO Update(EmailDTO modelDTO)
        {
            EmailDTO returnEmail = null;
            if (modelDTO != null && modelDTO.EmailID > 0)
            {
                emailRepo.UpdateEmail(EmailAssembler.ToEntity(modelDTO));
                returnEmail = modelDTO;
            }

            return returnEmail;
        }

        public bool Delete(int id)
        {

            Boolean isDeleted = false;

            if (id > 0)
            {
                isDeleted = emailRepo.DeleteEmail(id);
            }

            return isDeleted;
        }

        public void Dispose()
        {
            _EmailRepo.Dispose();
        }
    }
}
