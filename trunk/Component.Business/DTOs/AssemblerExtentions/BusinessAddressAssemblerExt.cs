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
    /// Assembler for <see cref="BusinessAddress"/> and <see cref="BusinessAddressDTO"/>.
    /// </summary>
    public static partial class BusinessAddressAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="BusinessAddressDTO"/> converted from <see cref="BusinessAddress"/>.</param>
        static partial void OnDTO(this BusinessAddress entity, BusinessAddressDTO dto) {
            if (entity != null && entity.Address != null) 
                dto.Addres = AddressAssembler.ToDTO(entity.Address);
        }

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="BusinessAddress"/> converted from <see cref="BusinessAddressDTO"/>.</param>
        static partial void OnEntity(this BusinessAddressDTO dto, BusinessAddress entity) { 
        
        }
    }
}
