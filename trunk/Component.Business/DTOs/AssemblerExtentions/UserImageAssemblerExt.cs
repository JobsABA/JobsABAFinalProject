﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;

using JobsInABA.DAL.Entities;
using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;

namespace JobsInABA.BL.DTOs.Assemblers
{
    public static partial class UserImageAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="UserDTO"/> converted from <see cref="User"/>.</param>
        static partial void OnDTO(this UserImage entity, UserImageDTO dto) {

            if (entity.Image != null)
            {
                dto.Image = ImageAssembler.ToDTO(entity.Image);
            }
        }

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="User"/> converted from <see cref="UserDTO"/>.</param>
        static partial void OnEntity(this UserImageDTO dto, UserImage entity) { 
        
        }
    }
}
