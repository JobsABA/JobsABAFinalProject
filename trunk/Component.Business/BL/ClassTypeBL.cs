using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;
using JobsInABA.DAL.Entities;
using JobsInABA.DAL.Repositories;
using System;

namespace JobsInABA.BL
{
    class ClassTypeBL : IDisposable
    {
        ClassTypesRepo _ClassTypeRepos;

        private ClassTypesRepo classTypeRepos
        {
            get
            {
                if (_ClassTypeRepos == null) _ClassTypeRepos = new ClassTypesRepo();
                return _ClassTypeRepos;
            }
        }

        public ClassTypeDTO Get(int id)
        {
            ClassTypeDTO oClassTypeDTO = null;
            if (id > 0)
            {
                ClassType oClassType = classTypeRepos.GetClassType(id);
            }

            return oClassTypeDTO;
        }

        public ClassTypeDTO Create(ClassTypeDTO modeDTO)
        {
            if (modeDTO != null)
            {
                return ClassTypeAssembler.ToDTO(classTypeRepos.CreateClassType(ClassTypeAssembler.ToEntity(modeDTO)));
            }

            return null;
        }

        public ClassTypeDTO Update(ClassTypeDTO modelDTO)
        {
            ClassTypeDTO returnUserMap = null;
            if (modelDTO != null && modelDTO.ClassTypeID > 0)
            {
                classTypeRepos.UpdateClassType(0, ClassTypeAssembler.ToEntity(modelDTO));
                returnUserMap = modelDTO;
            }

            return returnUserMap;
        }

        public bool Delete(int id)
        {
            Boolean isDeleted = false;

            if (id > 0)
            {
                try
                {
                    classTypeRepos.DeleteClassType(id);
                }
                catch
                {
                    return false;
                }
            }
            return isDeleted;
        }

        public void Dispose()
        {
            _ClassTypeRepos.Dispose();
        }
    }
}