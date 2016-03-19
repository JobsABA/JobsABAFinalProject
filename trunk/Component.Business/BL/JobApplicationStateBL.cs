using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;
using JobsInABA.DAL.Entities;
using JobsInABA.DAL.Repositories;
using System;

namespace JobsInABA.BL
{
    public class JobApplicationStateBL : IDisposable
    {
        JobApplicationStatesRepo _JobApplicationStateRepos;

        private JobApplicationStatesRepo jobApplicationStateRepos
        {
            get
            {
                if (_JobApplicationStateRepos == null) _JobApplicationStateRepos = new JobApplicationStatesRepo();
                return _JobApplicationStateRepos;
            }
        }

        public JobApplicationStateDTO Get(int id)
        {
            JobApplicationStateDTO oJobApplicationStateDTO = null;
            if (id > 0)
            {
                JobApplicationState oJobApplicationState = jobApplicationStateRepos.GetJobApplicationState(id);
            }

            return oJobApplicationStateDTO;
        }

        public JobApplicationStateDTO Create(JobApplicationStateDTO modelDTO)
        {
            if (modelDTO != null)
            {
                return JobApplicationStateAssembler.ToDTO(jobApplicationStateRepos.CreateJobApplicationState(JobApplicationStateAssembler.ToEntity(modelDTO)));
            }

            return null;
        }

        public JobApplicationStateDTO Update(JobApplicationStateDTO modelDTO)
        {
            JobApplicationStateDTO returnUserMap = null;
            if (modelDTO != null && modelDTO.JobApplicationStateID > 0)
            {
                jobApplicationStateRepos.UpdateJobApplicationState(0, JobApplicationStateAssembler.ToEntity(modelDTO));
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
                    jobApplicationStateRepos.DeleteJobApplicationState(id);
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
            _JobApplicationStateRepos.Dispose();
        }
    }
}