//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/02/22 - 20:58:38
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace JobsInABA.BL.DTOs
{
    [DataContract()]
    public partial class RoleDTO
    {
        [DataMember()]
        public Int32 RoleID { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public Int32 Precedence { get; set; }

        [DataMember()]
        public List<Int32> UserRoles_UserRoleID { get; set; }

        public RoleDTO()
        {
        }

        public RoleDTO(Int32 roleID, String name, Int32 precedence, List<Int32> userRoles_UserRoleID)
        {
			this.RoleID = roleID;
			this.Name = name;
			this.Precedence = precedence;
			this.UserRoles_UserRoleID = userRoles_UserRoleID;
        }
    }
}
