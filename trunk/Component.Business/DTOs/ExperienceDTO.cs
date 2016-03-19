//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/02/22 - 20:58:34
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
    public partial class ExperienceDTO
    {
        [DataMember()]
        public Int32 ExperienceID { get; set; }

        [DataMember()]
        public Int32 UserID { get; set; }

        [DataMember()]
        public Int32 BusinessID { get; set; }

        [DataMember()]
        public String JobPossition { get; set; }

        [DataMember()]
        public Nullable<DateTime> StartDate { get; set; }

        [DataMember()]
        public Nullable<DateTime> EndDate { get; set; }

        [DataMember()]
        public Nullable<Boolean> IsCurrent { get; set; }

        [DataMember()]
        public BusinessDTO Business { get; set; }

        [DataMember()]
        public Int32 Business_BusinessID { get; set; }

        [DataMember()]
        public UserDTO User { get; set; }

        [DataMember()]
        public Int32 User_UserID { get; set; }

        public ExperienceDTO()
        {
        }

        public ExperienceDTO(Int32 experienceID, Int32 userID, Int32 businessID, String jobPossition, Nullable<DateTime> startDate, Nullable<DateTime> endDate, Nullable<Boolean> isCurrent, Int32 business_BusinessID, Int32 user_UserID)
        {
			this.ExperienceID = experienceID;
			this.UserID = userID;
			this.BusinessID = businessID;
			this.JobPossition = jobPossition;
			this.StartDate = startDate;
			this.EndDate = endDate;
			this.IsCurrent = isCurrent;
			this.Business_BusinessID = business_BusinessID;
			this.User_UserID = user_UserID;
        }
    }
}
