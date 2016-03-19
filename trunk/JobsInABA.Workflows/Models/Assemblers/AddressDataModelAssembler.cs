using JobsInABA.BL.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace JobsInABA.Workflows.Models.Assemblers
{
    public static class AddressDataModelAssembler
    {
        public static AddressDataModel ToDataModel(AddressDTO dto)
        {

            AddressDataModel datamodel = new AddressDataModel();

            if (dto != null)
            {
                datamodel.AddressID = dto.AddressID;
                datamodel.Title = dto.Title;
                datamodel.Line1 = dto.Line1;
                datamodel.Line2 = dto.Line2;
                datamodel.Line3 = dto.Line3;
                datamodel.City = dto.City;
                datamodel.State = dto.State;
                datamodel.ZipCode = dto.ZipCode;
                datamodel.AddressTypeID = dto.AddressTypeID;
            }
            if (dto.Country != null)
            {
                CountryDTO countrydto = dto.Country;
                datamodel.CountryID = countrydto.CountryID;
                datamodel.AddressCountryAbbreviation = countrydto.Abbreviation;
                datamodel.AddressCountryCode = countrydto.Code;
                datamodel.AddressCountryName = countrydto.Name;
                datamodel.AddressCountryPhoneCode = countrydto.PhoneCode;
            }

            if (dto.TypeCode != null)
            {
                TypeCodeDTO typecodedto = dto.TypeCode;
                datamodel.AddressTypeID = typecodedto.TypeCodeID;
                datamodel.AddressTypeCode = typecodedto.Code;
                datamodel.AddressTypeCodeClassTypeID = typecodedto.ClassTypeID;
                datamodel.AddressTypeCodeDescription = typecodedto.Description;
                datamodel.AddressTypeCodeName = typecodedto.Name;
                datamodel.AddressTypeCodeParentTypeCodeID = typecodedto.ParentTypeCodeID;
            }

            return datamodel;
        }

        public static AddressDTO ToDTO(AddressDataModel datamodel)
        {
            AddressDTO dto = new AddressDTO();

            if (datamodel != null)
            {
                dto.AddressID = datamodel.AddressID;
                dto.Title = datamodel.Title;
                dto.Line1 = datamodel.Line1;
                dto.Line2 = datamodel.Line2;
                dto.Line3 = datamodel.Line3;
                dto.City = datamodel.City;
                dto.State = datamodel.State;
                dto.ZipCode = datamodel.ZipCode;
                dto.AddressTypeID = datamodel.AddressTypeID;
            }

            return dto;
        }

        public static IEnumerable<AddressDataModel> ToDataModels(IEnumerable<AddressDTO> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => ToDataModel(e)).ToList();
        }
    }
}
