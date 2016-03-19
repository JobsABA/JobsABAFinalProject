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
    public partial class PhoneDTO
    {
        [DataMember()]
        public Int32 PhoneID { get; set; }

        [DataMember()]
        public Int32 AddressbookID { get; set; }

        [DataMember()]
        public Nullable<Int32> CountryID { get; set; }

        [DataMember()]
        public String Number { get; set; }

        [DataMember()]
        public String Ext { get; set; }

        [DataMember()]
        public Nullable<Int32> PhoneTypeID { get; set; }

        [DataMember()]
        public Int32 Address_AddressID { get; set; }

        [DataMember()]
        public List<Int32> BusinessPhones_BusinessPhoneID { get; set; }

        [DataMember()]
        public Int32 TypeCode_TypeCodeID { get; set; }

        [DataMember()]
        public JobsInABA.BL.DTOs.TypeCodeDTO TypeCode { get; set; }

        [DataMember()]
        public List<Int32> UserPhones_UserPhoneID { get; set; }

        public PhoneDTO()
        {
        }

        public PhoneDTO(Int32 phoneID, Int32 addressbookID, Nullable<Int32> countryID, String number, String ext, Nullable<Int32> phoneTypeID, Int32 address_AddressID, List<Int32> businessPhones_BusinessPhoneID, Int32 typeCode_TypeCodeID, List<Int32> userPhones_UserPhoneID)
        {
			this.PhoneID = phoneID;
			this.AddressbookID = addressbookID;
			this.CountryID = countryID;
			this.Number = number;
			this.Ext = ext;
			this.PhoneTypeID = phoneTypeID;
			this.Address_AddressID = address_AddressID;
			this.BusinessPhones_BusinessPhoneID = businessPhones_BusinessPhoneID;
			this.TypeCode_TypeCodeID = typeCode_TypeCodeID;
			this.UserPhones_UserPhoneID = userPhones_UserPhoneID;
        }
    }
}
