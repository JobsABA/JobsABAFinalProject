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
    public static partial class AddressAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="AddressDTO"/> converted from <see cref="Address"/>.</param>
        static partial void OnDTO(this Address entity, AddressDTO dto) {
            if (entity!= null && entity.TypeCode != null) {
                dto.TypeCode = TypeCodeAssembler.ToDTO(entity.TypeCode);
                dto.Country = CountryAssembler.ToDTO(entity.Country);
            }
        }

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="Address"/> converted from <see cref="AddressDTO"/>.</param>
        static partial void OnEntity(this AddressDTO dto, Address entity) { 
        
        }
    }
}
