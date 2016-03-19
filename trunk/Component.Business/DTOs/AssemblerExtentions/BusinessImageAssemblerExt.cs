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
    public static partial class BusinessImageAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="BusinessDTO"/> converted from <see cref="Business"/>.</param>
        static partial void OnDTO(this BusinessImage entity, BusinessImageDTO dto)
        {
            if(entity.Image!=null)
                dto.Image = ImageAssembler.ToDTO(entity.Image);
        }

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="Business"/> converted from <see cref="BusinessDTO"/>.</param>
        static partial void OnEntity(this BusinessImageDTO dto, BusinessImage entity)
        {

        }
    }
}
