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
    public static partial class JobAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="JobDTO"/> converted from <see cref="Job"/>.</param>
        static partial void OnDTO(this Job entity, JobDTO dto)
        {
            if (entity.JobApplications != null && entity.JobApplications.Count > 0)
            {
                dto.JobApplications = JobApplicationAssembler.ToDTOs(entity.JobApplications);
            }
            if (entity.Business != null)
            {
                dto.Business = BusinessAssembler.ToDTO(entity.Business);
            }
        }

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="Job"/> converted from <see cref="JobDTO"/>.</param>
        static partial void OnEntity(this JobDTO dto, Job entity) { 
        
        }
    }
}
