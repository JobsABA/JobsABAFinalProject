//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/02/22 - 20:58:40
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
    public partial class TypeCodeDTO
    {
        [DataMember()]
        public Int32 TypeCodeID { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public String Code { get; set; }

        [DataMember()]
        public String Description { get; set; }

        [DataMember()]
        public Int32 ClassTypeID { get; set; }

        [DataMember()]
        public Nullable<Int32> ParentTypeCodeID { get; set; }

        [DataMember()]
        public List<Int32> Addresses_AddressID { get; set; }

        [DataMember()]
        public List<Int32> Businesses_BusinessID { get; set; }

        [DataMember()]
        public List<Int32> BusinessUserMaps_BusinessUserMapID { get; set; }

        [DataMember()]
        public ClassTypeDTO ClassType { get; set; }

        [DataMember()]
        public Int32 ClassType_ClassTypeID { get; set; }

        [DataMember()]
        public List<Int32> Emails_EmailID { get; set; }

        [DataMember()]
        public List<Int32> Images_ImageID { get; set; }

        [DataMember()]
        public List<Int32> JobApplicationStates_JobApplicationStateID { get; set; }

        [DataMember()]
        public List<Int32> Jobs_JobID { get; set; }

        [DataMember()]
        public List<Int32> Phones_PhoneID { get; set; }

        [DataMember()]
        public List<Int32> TypeCodes1_TypeCodeID { get; set; }

        [DataMember()]
        public Int32 TypeCode1_TypeCodeID { get; set; }

        public TypeCodeDTO()
        {
        }

        public TypeCodeDTO(Int32 typeCodeID, String name, String code, String description, Int32 classTypeID, Nullable<Int32> parentTypeCodeID, List<Int32> addresses_AddressID, List<Int32> businesses_BusinessID, List<Int32> businessUserMaps_BusinessUserMapID, Int32 classType_ClassTypeID, List<Int32> emails_EmailID, List<Int32> images_ImageID, List<Int32> jobApplicationStates_JobApplicationStateID, List<Int32> jobs_JobID, List<Int32> phones_PhoneID, List<Int32> typeCodes1_TypeCodeID, Int32 typeCode1_TypeCodeID)
        {
			this.TypeCodeID = typeCodeID;
			this.Name = name;
			this.Code = code;
			this.Description = description;
			this.ClassTypeID = classTypeID;
			this.ParentTypeCodeID = parentTypeCodeID;
			this.Addresses_AddressID = addresses_AddressID;
			this.Businesses_BusinessID = businesses_BusinessID;
			this.BusinessUserMaps_BusinessUserMapID = businessUserMaps_BusinessUserMapID;
			this.ClassType_ClassTypeID = classType_ClassTypeID;
			this.Emails_EmailID = emails_EmailID;
			this.Images_ImageID = images_ImageID;
			this.JobApplicationStates_JobApplicationStateID = jobApplicationStates_JobApplicationStateID;
			this.Jobs_JobID = jobs_JobID;
			this.Phones_PhoneID = phones_PhoneID;
			this.TypeCodes1_TypeCodeID = typeCodes1_TypeCodeID;
			this.TypeCode1_TypeCodeID = typeCode1_TypeCodeID;
        }
    }
}
