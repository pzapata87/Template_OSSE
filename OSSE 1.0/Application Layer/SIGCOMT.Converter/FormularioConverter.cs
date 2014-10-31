﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using SIGCOMT.Common;
using SIGCOMT.Common.Enum;
using SIGCOMT.Domain;
using SIGCOMT.DTO;
using SIGCOMT.DTO.GlobalResources;

namespace SIGCOMT.Converter
{
    public class FormularioConverter
    {
        public static List<ModuloDto> GenerateTreeView(List<Formulario> formularioDomain, int idiomaId)
        {
            return (from modulo in formularioDomain
                where !modulo.FormularioParentId.HasValue && modulo.Estado == TipoEstado.Activo.GetNumberValue()
                let idioma = ObtenerIdiomaFormulario(idiomaId, modulo.ItemTablaFormularioList)
                select new ModuloDto
                {
                    Id = modulo.Id,
                    Icono = modulo.Direccion,
                    Nombre = idioma.Nombre,
                    Operaciones = GenerateChildren(modulo.FormulariosHijosList, idiomaId)
                }).ToList();
        }

        public static PermisoFormularioDto ObtenerPermisosFormulario(Formulario formulario, IEnumerable<PermisoFormularioRol> permisos)
        {
            var permisoFormulario = new PermisoFormularioDto();

            foreach (var permiso in permisos)
            {
                var tipoPermiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), permiso.TipoPermiso.ToString());
                AsignarPermisoAPropiedad(permisoFormulario, tipoPermiso);
            }

            return permisoFormulario;
        }

        //public static Dictionary<int, List<PermisoFormularioDto>> DomainToDtoPermiso(IEnumerable<Formulario> formularios)
        //{
        //    var dictionary =
        //        formularios.ToDictionary(p => p.Id,
        //            p => p.PermisoList.Where(q => q.Estado == TipoEstado.Activo.GetNumberValue())
        //                .Select(
        //                    q => new PermisoFormularioDto
        //                    {
        //                        RolId = q.RolId,
        //                        TipoPermiso = q.TipoPermiso,
        //                        Activo = q.Activo
        //                    }).ToList());

        //    return dictionary;
        //}

        public static List<FormularioDto> DomainToDtoFormulario(List<Formulario> formularios, int idiomaId)
        {
            return (from modulo in formularios
                where !modulo.FormularioParentId.HasValue
                let nombreModulo = ObtenerIdiomaFormulario(idiomaId, modulo.ItemTablaFormularioList).Nombre
                from formulario in modulo.FormulariosHijosList
                where formulario.Estado == TipoEstado.Activo.GetNumberValue()
                select new FormularioDto
                {
                    Id = formulario.Id,
                    Modulo = nombreModulo,
                    Nombre = ObtenerIdiomaFormulario(idiomaId, formulario.ItemTablaFormularioList).Nombre,
                    PermisoList = ObtenerPermisosFormulario(formulario.PermisoList)
                }).ToList();
        }

        public static List<PermisoFormularioDto> ObtenerPermisosFormulario(IEnumerable<PermisoFormulario> permisos)
        {
            var rm = new ResourceManager("SIGCOMT.DTO.GlobalResources.Master", typeof(Master).Assembly);

            return permisos.Select(p => new PermisoFormularioDto
            {
                FormularioId = p.FormularioId,
                TipoPermiso = p.TipoPermiso,
                NombrePermiso = rm.GetString(Enum.GetName(typeof(TipoPermiso), p.TipoPermiso))
            }).ToList();
        }

        #region Métodos Privados

        private static ItemTablaFormulario ObtenerIdiomaFormulario(int idiomaId, ICollection<ItemTablaFormulario> itemTablaFormularios)
        {
            return itemTablaFormularios.FirstOrDefault(p => p.ItemTablaId == idiomaId) ??
                   itemTablaFormularios.First();
        }

        private static List<OperacionDto> GenerateChildren(IEnumerable<Formulario> childrenList, int idiomaId)
        {
            return (from children in childrenList
                where children.Estado == TipoEstado.Activo.GetNumberValue()
                let idioma = ObtenerIdiomaFormulario(idiomaId, children.ItemTablaFormularioList)
                select new OperacionDto
                {
                    Controlador = children.Direccion,
                    Nombre = idioma.Nombre,
                    Id = children.Id,
                    Operaciones = GenerateChildren(children.FormulariosHijosList, idiomaId)
                }).ToList();
        }

        private static void AsignarPermisoAPropiedad(PermisoFormularioDto permisoFormularioDto, TipoPermiso permiso)
        {
            switch (permiso)
            {
                case TipoPermiso.Mostrar:
                    permisoFormularioDto.Mostrar = true;
                    break;
                case TipoPermiso.Crear:
                    permisoFormularioDto.Crear = true;
                    break;
                case TipoPermiso.Editar:
                    permisoFormularioDto.Modificar = true;
                    break;
                case TipoPermiso.Eliminar:
                    permisoFormularioDto.Eliminar = true;
                    break;
            }
        }

        #endregion
    }
}