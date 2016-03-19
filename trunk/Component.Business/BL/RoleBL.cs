using JobsInABA.BL.DTOs;
using JobsInABA.BL.DTOs.Assemblers;
using JobsInABA.DAL.Entities;
using JobsInABA.DAL.Repositories;
using System;

namespace JobsInABA.BL
{
    class RoleBL : IDisposable
    {
        RolesRepo _RoleRepos;

        private RolesRepo roleRepos
        {
            get
            {
                if (_RoleRepos == null) _RoleRepos = new RolesRepo();
                return _RoleRepos;
            }
        }

        public RoleDTO Get(int id)
        {
            RoleDTO oRoleDTO = null;
            if (id > 0)
            {
                Role oRole = roleRepos.GetRole(id);
            }

            return oRoleDTO;
        }

        public RoleDTO Create(RoleDTO modelDTO)
        {
            if (modelDTO != null)
            {
                return RoleAssembler.ToDTO(roleRepos.CreateRole(RoleAssembler.ToEntity(modelDTO)));
            }

            return null;
        }

        public RoleDTO Update(RoleDTO modelDTO)
        {
            RoleDTO returnUserMap = null;
            if (modelDTO != null && modelDTO.RoleID > 0)
            {
                roleRepos.UpdateRole(0, RoleAssembler.ToEntity(modelDTO));
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
                    roleRepos.DeleteRole(id);
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
            _RoleRepos.Dispose();
        }
    }
}