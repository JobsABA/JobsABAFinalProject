using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using JobsInABA.DAL.Entities;
using JobsInABA.BL.DTOs;

namespace JobsInABA.BL.DTOs.Assemblers
{

    /// <summary>
    /// Assembler for <see cref="BusinessEmail"/> and <see cref="BusinessEmailDTO"/>.
    /// </summary>
    public static partial class BusinessEmailAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="BusinessEmailDTO"/> converted from <see cref="BusinessEmail"/>.</param>
        static partial void OnDTO(this BusinessEmail entity, BusinessEmailDTO dto) {
            if (entity != null && entity.Email != null)
                dto.Email = EmailAssembler.ToDTO(entity.Email);
        }

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="BusinessEmail"/> converted from <see cref="BusinessEmailDTO"/>.</param>
        static partial void OnEntity(this BusinessEmailDTO dto, BusinessEmail entity) { 
        
        }

    }
}
