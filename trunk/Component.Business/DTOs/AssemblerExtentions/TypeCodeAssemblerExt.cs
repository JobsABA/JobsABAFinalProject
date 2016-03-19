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
    /// Assembler for <see cref="JobsInABA.DAL.Entities.TypeCode"/> and <see cref="TypeCodeDTO"/>.
    /// </summary>
    public static partial class TypeCodeAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="TypeCodeDTO"/> converted from <see cref="JobsInABA.DAL.Entities.TypeCode"/>.</param>
        static partial void OnDTO(this JobsInABA.DAL.Entities.TypeCode entity, TypeCodeDTO dto) {
            if (entity.ClassType != null) dto.ClassType = ClassTypeAssembler.ToDTO(entity.ClassType);
        }

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="JobsInABA.DAL.Entities.TypeCode"/> converted from <see cref="TypeCodeDTO"/>.</param>
        static partial void OnEntity(this TypeCodeDTO dto, JobsInABA.DAL.Entities.TypeCode entity) { 
        
        }
    }
}
