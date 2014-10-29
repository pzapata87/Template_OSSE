﻿using System.Data.Entity.ModelConfiguration;
using SIGCOMT.Domain;

namespace SIGCOMT.Persistence.DatabaseMappings
{
    public class PermisoFormularioRolConfiguration : EntityTypeConfiguration<PermisoFormularioRol>
    {
        public PermisoFormularioRolConfiguration()
        {
            HasRequired(p => p.Formulario).WithMany(p => p.PermisoRolList).HasForeignKey(p => p.FormularioId);
            HasRequired(p => p.Rol).WithMany(p => p.PermisoRolList).HasForeignKey(p => p.RolId);
        }
    }
}