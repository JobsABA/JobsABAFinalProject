using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;

using JobsInABA.DAL.Entities;
using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;

namespace JobsInABA.BL.DTOs.Assemblers
{
    public static partial class UserAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="UserDTO"/> converted from <see cref="User"/>.</param>
        static partial void OnDTO(this User entity, UserDTO dto) {

            if (entity.UserAddresses != null && entity.UserAddresses.Count > 0)
            {
                dto.UserAddresses = UserAddressAssembler.ToDTOs(entity.UserAddresses.ToList());
            }
            if (entity.UserEmails != null && entity.UserEmails.Count > 0)
            {
                dto.UserEmails = UserEmailAssembler.ToDTOs(entity.UserEmails);
            }
            if (entity.Experiences != null && entity.Experiences.Count > 0)
            {
                dto.Experiences = ExperienceAssembler.ToDTOs(entity.Experiences.ToList());
            }
            if (entity.Achievements != null && entity.Achievements.Count > 0)
            {
                dto.Achievements = AchievementAssembler.ToDTOs(entity.Achievements);
            }
            if (entity.Educations != null && entity.Educations.Count > 0)
            {
                dto.Educations = EducationAssembler.ToDTOs(entity.Educations);
            }
            if (entity.Skills != null && entity.Skills.Count > 0)
            {
                dto.Skills = SkillAssembler.ToDTOs(entity.Skills);
            }
            if (entity.Languages != null && entity.Languages.Count > 0)
            {
                dto.Languages = LanguageAssembler.ToDTOs(entity.Languages);
            }
            if (entity.UserImages != null && entity.UserImages.Count > 0)
            {
                dto.UserImages = UserImageAssembler.ToDTOs(entity.UserImages);
            }
            if (entity.UserPhones != null && entity.UserPhones.Count > 0)
            {
                dto.UserPhone = UserPhoneAssembler.ToDTOs(entity.UserPhones);
            }
            
        }

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="User"/> converted from <see cref="UserDTO"/>.</param>
        static partial void OnEntity(this UserDTO dto, User entity) { 
        
        }
    }
}
