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
    /// Assembler for <see cref="UserPhone"/> and <see cref="UserPhoneDTO"/>.
    /// </summary>
    public static partial class BusinessPhoneAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="UserPhoneDTO"/> converted from <see cref="UserPhone"/>.</param>
        static partial void OnDTO(this BusinessPhone entity, BusinessPhoneDTO dto)
        {
            if (entity != null && entity.Phone != null)
                dto.Phone = PhoneAssembler.ToDTO(entity.Phone);
        }

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="UserPhone"/> converted from <see cref="UserPhoneDTO"/>.</param>
        static partial void OnEntity(this BusinessPhoneDTO dto, BusinessPhone entity)
        { 
        
        }
    }
}
