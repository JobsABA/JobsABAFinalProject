//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/02/22 - 20:58:47
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using JobsInABA.BL.DTOs;
using JobsInABA.DAL.Entities;

namespace JobsInABA.BL.DTOs.Assemblers
{

    /// <summary>
    /// Assembler for <see cref="JobApplication"/> and <see cref="JobApplicationDTO"/>.
    /// </summary>
    public static partial class JobApplicationAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="JobApplicationDTO"/> converted from <see cref="JobApplication"/>.</param>
        static partial void OnDTO(this JobApplication entity, JobApplicationDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="JobApplication"/> converted from <see cref="JobApplicationDTO"/>.</param>
        static partial void OnEntity(this JobApplicationDTO dto, JobApplication entity);

        /// <summary>
        /// Converts this instance of <see cref="JobApplicationDTO"/> to an instance of <see cref="JobApplication"/>.
        /// </summary>
        /// <param name="dto"><see cref="JobApplicationDTO"/> to convert.</param>
        public static JobApplication ToEntity(this JobApplicationDTO dto)
        {
            if (dto == null) return null;

            var entity = new JobApplication();

            entity.JobApplicationID = dto.JobApplicationID;
            entity.JobID = dto.JobID;
            entity.ApplicantUserID = dto.ApplicantUserID;
            entity.ApplicationDate = dto.ApplicationDate;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="JobApplication"/> to an instance of <see cref="JobApplicationDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="JobApplication"/> to convert.</param>
        public static JobApplicationDTO ToDTO(this JobApplication entity)
        {
            if (entity == null) return null;

            var dto = new JobApplicationDTO();

            dto.JobApplicationID = entity.JobApplicationID;
            dto.JobID = entity.JobID;
            dto.ApplicantUserID = entity.ApplicantUserID;
            dto.ApplicationDate = entity.ApplicationDate;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="JobApplicationDTO"/> to an instance of <see cref="JobApplication"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<JobApplication> ToEntities(this IEnumerable<JobApplicationDTO> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="JobApplication"/> to an instance of <see cref="JobApplicationDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<JobApplicationDTO> ToDTOs(this IEnumerable<JobApplication> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
