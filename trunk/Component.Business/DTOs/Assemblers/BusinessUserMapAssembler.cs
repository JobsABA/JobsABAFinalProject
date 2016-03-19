//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/02/22 - 20:58:46
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using JobsInABA.BL.DTOs;
using JobsInABA.DAL.Entities;

namespace JobsInABA.BL.DTOs.Assemblers
{

    /// <summary>
    /// Assembler for <see cref="BusinessUserMap"/> and <see cref="BusinessUserMapDTO"/>.
    /// </summary>
    public static partial class BusinessUserMapAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="BusinessUserMapDTO"/> converted from <see cref="BusinessUserMap"/>.</param>
        static partial void OnDTO(this BusinessUserMap entity, BusinessUserMapDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="BusinessUserMap"/> converted from <see cref="BusinessUserMapDTO"/>.</param>
        static partial void OnEntity(this BusinessUserMapDTO dto, BusinessUserMap entity);

        /// <summary>
        /// Converts this instance of <see cref="BusinessUserMapDTO"/> to an instance of <see cref="BusinessUserMap"/>.
        /// </summary>
        /// <param name="dto"><see cref="BusinessUserMapDTO"/> to convert.</param>
        public static BusinessUserMap ToEntity(this BusinessUserMapDTO dto)
        {
            if (dto == null) return null;

            var entity = new BusinessUserMap();

            entity.BusinessUserMapID = dto.BusinessUserMapID;
            entity.BusinessID = dto.BusinessID;
            entity.UserID = dto.UserID;
            entity.IsOwner = dto.IsOwner;
            entity.BusinessUserTypeID = dto.BusinessUserTypeID;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="BusinessUserMap"/> to an instance of <see cref="BusinessUserMapDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="BusinessUserMap"/> to convert.</param>
        public static BusinessUserMapDTO ToDTO(this BusinessUserMap entity)
        {
            if (entity == null) return null;

            var dto = new BusinessUserMapDTO();

            dto.BusinessUserMapID = entity.BusinessUserMapID;
            dto.BusinessID = entity.BusinessID;
            dto.UserID = entity.UserID;
            dto.IsOwner = entity.IsOwner;
            dto.BusinessUserTypeID = entity.BusinessUserTypeID;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="BusinessUserMapDTO"/> to an instance of <see cref="BusinessUserMap"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<BusinessUserMap> ToEntities(this IEnumerable<BusinessUserMapDTO> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="BusinessUserMap"/> to an instance of <see cref="BusinessUserMapDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<BusinessUserMapDTO> ToDTOs(this IEnumerable<BusinessUserMap> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
