using System.Collections.Generic;
using System.Linq;
using JobsInABA.BL;
using JobsInABA.Workflows.Models;
using JobsInABA.Workflows.Models.Assemblers;
using JobsInABA.BL.DTOs;

namespace JobsInABA.Workflows
{
    public class JobWorkflows
    {
        JobBL _JobsBL;
        JobApplicationBL _JobApplicationBL;
        JobApplicationStateBL _JobApplicationStateBL;

        public JobDTO Get(int id)
        {
            JobDTO model = new JobDTO();
            if (id > 0)
            {
                JobDTO jobDTO = jobsBL.Get(id);

                if (jobDTO != null)
                {
                    model = Get(jobDTO);
                }
            }

            return model;
        }

        public JobDTO Get(JobDTO modelDTO)
        {
            JobDTO oJobDTO = null;
            if (modelDTO != null)
            {
                oJobDTO = jobsBL.Get(modelDTO.JobID);
            }
            return oJobDTO;
        }

        public List<JobDTO> Get()
        {
            List<JobDTO> oJobDTOs = new List<JobDTO>();

            List<JobDTO> jobDTOs = jobsBL.Get().ToList();

            oJobDTOs = jobDTOs.Select(Jobdto => Get(Jobdto)).ToList();

            return oJobDTOs;
        }

        public JobDTO Create(JobDTO dataModel)
        {
            if (dataModel != null)
            {
                JobDTO jobDTO = new JobDTO();
                JobApplicationDTO jobApplicationDTO = new JobApplicationDTO();
                JobApplicationStateDTO jobApplicationStateDTO = new JobApplicationStateDTO();

                jobDTO = JobDTOAssembler.ToJobDTO(dataModel);
                jobApplicationDTO = JobDTOAssembler.TojobApplicationDTO(dataModel);
                jobApplicationStateDTO = JobDTOAssembler.ToJobApplicationStateDTO(dataModel);

                if (jobDTO != null)
                {
                    jobDTO = jobsBL.Create(jobDTO);
                }
                dataModel = JobDTOAssembler.ToDataModel(jobDTO, jobApplicationDTO, jobApplicationStateDTO);
                jobApplicationDTO = JobDTOAssembler.TojobApplicationDTO(dataModel);
                if (jobApplicationDTO != null)
                {
                    jobApplicationDTO = jobApplicationBL.Create(jobApplicationDTO);
                }
                dataModel = JobDTOAssembler.ToDataModel(jobDTO, jobApplicationDTO, jobApplicationStateDTO);
                jobApplicationStateDTO = JobDTOAssembler.ToJobApplicationStateDTO(dataModel);
                if (jobApplicationStateDTO != null)
                {
                    jobApplicationStateDTO = jobApplicationStateBL.Create(jobApplicationStateDTO);
                }
            }

            return dataModel;
        }

        public JobDTO Update(JobDTO dataModel)
        {
            if (dataModel != null)
            {
                JobDTO jobDTO = new JobDTO();

                jobDTO = JobDTOAssembler.ToJobDTO(dataModel);

                if (jobDTO != null)
                {
                    jobDTO = jobsBL.Update(jobDTO);
                }
            }

            return dataModel;
        }

        public bool Delete(int id)
        {
            return jobsBL.Delete(id);
        }

        private JobBL jobsBL
        {
            get
            {
                if (_JobsBL == null) _JobsBL = new JobBL();
                return _JobsBL;
            }
        }

        private JobApplicationBL jobApplicationBL
        {
            get
            {
                if (_JobApplicationBL == null) _JobApplicationBL = new JobApplicationBL();
                return _JobApplicationBL;
            }
        }

        private JobApplicationStateBL jobApplicationStateBL
        {
            get
            {
                if (_JobApplicationStateBL == null) _JobApplicationStateBL = new JobApplicationStateBL();
                return _JobApplicationStateBL;
            }
        }
    }
}
