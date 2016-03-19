using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;
using JobsInABA.DAL.Entities;
using JobsInABA.DAL.Repositories;
using System;

namespace JobsInABA.BL
{
    public class JobApplicationBL : IDisposable
    {
        JobApplicationsRepo _JobApplicationRepos;

        private JobApplicationsRepo jobApplicationRepos
        {
            get
            {
                if (_JobApplicationRepos == null) _JobApplicationRepos = new JobApplicationsRepo();
                return _JobApplicationRepos;
            }
        }

        public JobApplicationDTO Get(int id)
        {
            JobApplicationDTO oJobApplicationDTO = null;
            if (id > 0)
            {
                JobApplication oJobApplication = jobApplicationRepos.GetJobApplication(id);
            }

            return oJobApplicationDTO;
        }

        public JobApplicationDTO Create(JobApplicationDTO modelDTO)
        {
            if (modelDTO != null)
            {
                return JobApplicationAssembler.ToDTO(jobApplicationRepos.CreateJobApplication(JobApplicationAssembler.ToEntity(modelDTO)));
            }

            return null;
        }

        public JobApplicationDTO Update(JobApplicationDTO modelDTO)
        {
            JobApplicationDTO returnUserMap = null;
            if (modelDTO != null && modelDTO.JobApplicationID > 0)
            {
                jobApplicationRepos.UpdateJobApplication(0, JobApplicationAssembler.ToEntity(modelDTO));
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
                    jobApplicationRepos.DeleteJobApplication(id);
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
            _JobApplicationRepos.Dispose();
        }
    }
}