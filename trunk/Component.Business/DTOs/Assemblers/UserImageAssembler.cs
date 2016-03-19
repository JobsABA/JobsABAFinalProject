//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/02/22 - 20:58:50
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
    /// Assembler for <see cref="UserImage"/> and <see cref="UserImageDTO"/>.
    /// </summary>
    public static partial class UserImageAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="UserImageDTO"/> converted from <see cref="UserImage"/>.</param>
        static partial void OnDTO(this UserImage entity, UserImageDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="UserImage"/> converted from <see cref="UserImageDTO"/>.</param>
        static partial void OnEntity(this UserImageDTO dto, UserImage entity);

        /// <summary>
        /// Converts this instance of <see cref="UserImageDTO"/> to an instance of <see cref="UserImage"/>.
        /// </summary>
        /// <param name="dto"><see cref="UserImageDTO"/> to convert.</param>
        public static UserImage ToEntity(this UserImageDTO dto)
        {
            if (dto == null) return null;

            var entity = new UserImage();

            entity.UserImageID = dto.UserImageID;
            entity.UserID = dto.UserID;
            entity.ImageID = dto.ImageID;
            entity.IsPrimary = dto.IsPrimary;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="UserImage"/> to an instance of <see cref="UserImageDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="UserImage"/> to convert.</param>
        public static UserImageDTO ToDTO(this UserImage entity)
        {
            if (entity == null) return null;

            var dto = new UserImageDTO();

            dto.UserImageID = entity.UserImageID;
            dto.UserID = entity.UserID;
            dto.ImageID = entity.ImageID;
            dto.IsPrimary = entity.IsPrimary;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="UserImageDTO"/> to an instance of <see cref="UserImage"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<UserImage> ToEntities(this IEnumerable<UserImageDTO> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="UserImage"/> to an instance of <see cref="UserImageDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<UserImageDTO> ToDTOs(this IEnumerable<UserImage> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
