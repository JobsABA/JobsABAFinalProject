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
    /// Assembler for <see cref="UserEmail"/> and <see cref="UserEmailDTO"/>.
    /// </summary>
    public static partial class UserEmailAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="UserEmailDTO"/> converted from <see cref="UserEmail"/>.</param>
        static partial void OnDTO(this UserEmail entity, UserEmailDTO dto) {
            if (entity != null && entity.Email != null)
                dto.Email = EmailAssembler.ToDTO(entity.Email);
        }

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="UserEmail"/> converted from <see cref="UserEmailDTO"/>.</param>
        static partial void OnEntity(this UserEmailDTO dto, UserEmail entity) { 
        
        }

    }
}
