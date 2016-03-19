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
    /// Assembler for <see cref="Email"/> and <see cref="EmailDTO"/>.
    /// </summary>
    public static partial class EmailAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="EmailDTO"/> converted from <see cref="Email"/>.</param>
        static partial void OnDTO(this Email entity, EmailDTO dto) {
            if (entity != null && entity.TypeCode != null)
                dto.TypeCode = TypeCodeAssembler.ToDTO(entity.TypeCode);
        }

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="Email"/> converted from <see cref="EmailDTO"/>.</param>
        static partial void OnEntity(this EmailDTO dto, Email entity) { 
        
        }
    }
}
