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
    /// Assembler for <see cref="Phone"/> and <see cref="PhoneDTO"/>.
    /// </summary>
    public static partial class PhoneAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="PhoneDTO"/> converted from <see cref="Phone"/>.</param>
        static partial void OnDTO(this Phone entity, PhoneDTO dto) {
            if (entity != null && entity.TypeCode != null)
                dto.TypeCode = TypeCodeAssembler.ToDTO(entity.TypeCode);
        }

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="Phone"/> converted from <see cref="PhoneDTO"/>.</param>
        static partial void OnEntity(this PhoneDTO dto, Phone entity) { 
        
        }
    }
}
