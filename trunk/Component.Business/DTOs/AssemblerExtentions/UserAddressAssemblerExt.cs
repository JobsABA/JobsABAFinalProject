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
    /// Assembler for <see cref="UserAddress"/> and <see cref="UserAddressDTO"/>.
    /// </summary>
    public static partial class UserAddressAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="UserAddressDTO"/> converted from <see cref="UserAddress"/>.</param>
        static partial void OnDTO(this UserAddress entity, UserAddressDTO dto) {
            if (entity != null && entity.Address != null) 
                dto.Address = AddressAssembler.ToDTO(entity.Address);
        }

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="UserAddress"/> converted from <see cref="UserAddressDTO"/>.</param>
        static partial void OnEntity(this UserAddressDTO dto, UserAddress entity) { 
        
        }
    }
}
