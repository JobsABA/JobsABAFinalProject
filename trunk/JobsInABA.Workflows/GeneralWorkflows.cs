using JobsInABA.BL;
using JobsInABA.BL.DTOs;
using System.Linq;
using JobsInABA.DAL.Repositories;
using System.Collections.Generic;

namespace JobsInABA.Workflows
{
    public class AddressWorkflows : AddressBL { }
    public class AchievementsWorkflows : AchievementBL
    {
        public List<AchievementDTO> GetAchievement()
        {
            var AchievementDTOs = new AchievementBL().Get();
            if (AchievementDTOs != null)
                foreach (var item in AchievementDTOs)
                {
                    if (item.UserID.HasValue)
                        item.User = new UsersBL().Get(item.UserID.Value);
                }
            return AchievementDTOs.ToList();
        }
        public AchievementDTO GetAchievement(int id)
        {
            return GetAchievement().FirstOrDefault(p => p.AchievementID == id);
        }
    }
    public class BusinessEmailsWorkflows : BusinessEmailBL { }

    public class BusinessImagesWorkflows : BusinessImageBL { }
    public class BusinessPhonesWorkflows : BusinessPhoneBL { }
    public class BusinessUserMapsWorkflows : BusinessUserMapBL { }
    public class BusinessAddressesWorkflows : BusinessAddressBL { }
    public class CountriesWorkflows : CountryBL { }
    public class EducationsWorkflows : EducationBL
    {
        public IEnumerable<EducationDTO> GetEducations()
        {
            var DTOs = new EducationBL().Get();
            if (DTOs != null)
            {
                foreach (var DTO in DTOs)
                {
                    if (DTO.User != null)
                    {
                        DTO.User = new UsersBL().Get(DTO.UserID);
                    }
                }
            }
            return DTOs.ToList();
        }

        public EducationDTO GetEducations(int id)
        {
            return GetEducations().FirstOrDefault(p => p.EducationID == id);
        }
    }
    public class EmailsWorkflows : EmailsBL { }
    public class ExperiencesWorkflows : ExperienceBL
    {
        public IEnumerable<ExperienceDTO> GetExperiences()
        {
            var DTOs = new ExperienceBL().Get();
            if (DTOs != null)
            {
                foreach (var DTO in DTOs)
                {
                    if (DTO.User != null)
                    {
                        DTO.User = new UsersBL().Get(DTO.UserID);
                    }
                    if (DTO.Business != null)
                    {
                        DTO.Business = new BusinessBL().Get(DTO.BusinessID);
                    }
                }
            }
            return DTOs.ToList();
        }

        public ExperienceDTO GetExperiences(int id)
        {
            return GetExperiences().FirstOrDefault(p => p.ExperienceID == id);
        }
    }
    public class JobApplicationsWorkflows : JobApplicationBL
    {

    }
    public class JobApplicationStatesWorkflows : JobApplicationStateBL { }
    public class JobWorkflows : JobBL
    {
        public List<JobDTO> GetJobs()
        {
            var JobDTOs = new JobBL().Get();
            if (JobDTOs != null)
            {
                foreach (var JobDTO in JobDTOs)
                {
                    if (JobDTO.JobApplications != null)
                    {
                        foreach (var JobApplication in JobDTO.JobApplications)
                        {
                            JobApplication.User = new UsersBL().Get(JobApplication.ApplicantUserID);
                        }
                    }
                    //var businessUsers = new BusinessUserMapBL().Get().Where(p => p.BusinessID == JobDTO.Business.BusinessID);
                    //if (businessUsers != null)
                    //{
                    //    if (businessUsers.Count(p => p.IsOwner == true) > 0)
                    //        JobDTO.Business.User = new UsersBL().Get(businessUsers.FirstOrDefault(p => p.IsOwner == true).UserID);
                    //}
                }
            }
            return JobDTOs.ToList();
        }
        public JobDTO GetJobs(int id)
        {
            return GetJobs().FirstOrDefault(p => p.JobID == id);
        }
    }
    public class LanguagesWorkflows : LanguageBL
    {
        public IEnumerable<LanguageDTO> GetLanguages()
        {
            var DTOs = new LanguageBL().Get();
            if (DTOs != null)
            {
                foreach (var DTO in DTOs)
                {
                    if (DTO.User != null)
                    {
                        DTO.User = new UsersBL().Get(DTO.UserID);
                    }
                }
            }
            return DTOs.ToList();
        }

        public LanguageDTO GetLanguages(int id)
        {
            return GetLanguages().FirstOrDefault(p => p.LanguageID == id);
        }
    }
    public class PhonesWorkflows : PhonesBL { }
    public class ServicesWorkflows : ServiceBL { }
    public class UserAccountWorkflows : UserAccountBL { }
    public class SkillsWorkflows : SkillBL
    {
        public IEnumerable<SkillDTO> GetSkills()
        {
            var DTOs = new SkillBL().Get();
            if (DTOs != null)
            {
                foreach (var DTO in DTOs)
                {
                    if (DTO.User != null)
                    {
                        DTO.User = new UsersBL().Get(DTO.UserID);
                    }
                }
            }
            return DTOs.ToList();
        }

        public SkillDTO GetSkills(int id)
        {
            return GetSkills().FirstOrDefault(p => p.SkillID == id);
        }
    }

    public class UserAddressesWorkflows : UserAddressBL { }
    public class UserEmailsWorkflows : UserEmailBL { }
    public class UserImagesWorkflows : UserImageBL { }
    public class UserPhonesWorkflows : UserPhoneBL { }
}
