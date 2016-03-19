using JobsInABA.BL.DTOs;
namespace JobsInABA.Workflows.Models.Assemblers
{
    class JobDataModelAssembler
    {
        public static JobDataModel ToDataModel(JobDTO jobDTO, JobApplicationDTO jobApplicationDTO, JobApplicationStateDTO jobApplicationStateDTO)
        {
            JobDataModel model = new JobDataModel();
            if (jobDTO != null)
            {
                model.JobID = jobDTO.JobID;
                model.BusinessID = jobDTO.BusinessID;
                model.Title = jobDTO.Title;
                model.Description = jobDTO.Description;
                model.JobTypeID = jobDTO.JobTypeID;
                model.IsActive = jobDTO.IsActive;
                model.IsDeleted = jobDTO.IsDeleted;
                model.StartDate = jobDTO.StartDate;
                model.EndDate = jobDTO.EndDate;
                model.insuser = jobDTO.insuser;
                model.insdt = jobDTO.insdt;
                model.upduser = jobDTO.upduser;
                model.upddt = jobDTO.upddt;
            }
            if (jobApplicationDTO != null)
            {
                model.JobApplicationID = jobApplicationDTO.JobApplicationID;
                model.ApplicantUserID = jobApplicationDTO.ApplicantUserID;
                model.ApplicationDate = jobApplicationDTO.ApplicationDate;

                model.JobApplicationStateID = jobApplicationStateDTO.JobApplicationStateID;
            }
            return model;
        }

        public static JobDTO ToJobDTO(JobDataModel datamodel)
        {
            JobDTO dto = new JobDTO();
            if (datamodel != null)
            {
                dto.JobID = datamodel.JobID;
                dto.BusinessID = datamodel.BusinessID;
                dto.Title = datamodel.Title;
                dto.Description = datamodel.Description;
                dto.JobTypeID = datamodel.JobTypeID;
                dto.IsActive = datamodel.IsActive;
                dto.IsDeleted = datamodel.IsDeleted;
                dto.StartDate = datamodel.StartDate;
                dto.EndDate = datamodel.EndDate;
                dto.insuser = datamodel.insuser;
                dto.insdt = datamodel.insdt;
                dto.upduser = datamodel.upduser;
                dto.upddt = datamodel.upddt;
            }
            return dto;
        }

        public static JobApplicationDTO TojobApplicationDTO(JobDataModel datamodel)
        {
            JobApplicationDTO dto = new JobApplicationDTO();
            if (datamodel != null)
            {
                dto.JobApplicationID = datamodel.JobApplicationID;
                dto.ApplicantUserID = datamodel.ApplicantUserID;
                dto.ApplicationDate = datamodel.ApplicationDate;
                dto.JobID = datamodel.JobID;
            }
            return dto;
        }

        public static JobApplicationStateDTO ToJobApplicationStateDTO(JobDataModel datamodel)
        {
            JobApplicationStateDTO dto = new JobApplicationStateDTO();
            if (datamodel != null)
            {
                dto.JobApplicationStatusID = datamodel.JobApplicationStatusID;
                dto.JobApplicationStateID = datamodel.JobApplicationStateID;
                dto.insdt = datamodel.JobApplicationinsdt;
                dto.insuser = datamodel.JobApplicationinsuser;
                dto.JobApplicationID = datamodel.JobApplicationID;
            }
            return dto;
        }
    }
}
