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
    public static partial class BusinessAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="BusinessDTO"/> converted from <see cref="Business"/>.</param>
        static partial void OnDTO(this Business entity, BusinessDTO dto)
        {
            if (entity.BusinessAddresses != null && entity.BusinessAddresses.Count > 0)
            {
                dto.BusinessAddresses = BusinessAddressAssembler.ToDTOs(entity.BusinessAddresses.ToList());
            }
            if (entity.BusinessEmails != null && entity.BusinessEmails.Count > 0)
            {
                dto.BusinessEmails = BusinessEmailAssembler.ToDTOs(entity.BusinessEmails);
            }
            if (entity.BusinessImages != null && entity.BusinessImages.Count > 0)
            {
                dto.BusinessImages = BusinessImageAssembler.ToDTOs(entity.BusinessImages);
            }
            if (entity.Achievements != null && entity.Achievements.Count > 0)
            {
                dto.Achievements = AchievementAssembler.ToDTOs(entity.Achievements);
            }
            if (entity.BusinessImages != null && entity.BusinessImages.Count > 0)
            {
                dto.BusinessImages = BusinessImageAssembler.ToDTOs(entity.BusinessImages);
            }
            if (entity.BusinessPhones != null && entity.BusinessPhones.Count > 0)
            {
                dto.BusinessPhones = BusinessPhoneAssembler.ToDTOs(entity.BusinessPhones);
            }
        }

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="Business"/> converted from <see cref="BusinessDTO"/>.</param>
        static partial void OnEntity(this BusinessDTO dto, Business entity)
        {

        }
    }
}
