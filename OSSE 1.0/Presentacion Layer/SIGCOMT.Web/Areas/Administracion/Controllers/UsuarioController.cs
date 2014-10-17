﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SIGCOMT.BusinessLogic.Core;
using SIGCOMT.BusinessLogic.Interfaces;
using SIGCOMT.Cache;
using SIGCOMT.Common;
using SIGCOMT.Common.DataTable;
using SIGCOMT.Common.Enum;
using SIGCOMT.Converter;
using SIGCOMT.Domain;
using SIGCOMT.DTO;
using SIGCOMT.Web.Core;

namespace SIGCOMT.Web.Areas.Administracion.Controllers
{
    [Authorize]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioBL _usuarioBL;

        public UsuarioController(IFormularioBL formularioBL, IPermisoRolBL permisoRolBL, IItemTablaBL itemTablaBL, IUsuarioBL usuarioBL)
             :base(formularioBL, permisoRolBL, itemTablaBL)
        {
            _usuarioBL = usuarioBL;
        }

        public ActionResult Index()
        {
            var listaIdiomas = new List<ValorHomologacion>();

            GlobalParameters.Idiomas.ToList().ForEach(p => listaIdiomas.Add(new ValorHomologacion
            {
                ValorHomologado = Convert.ToString(p.Key),
                ValorReal = p.Value
            }));

            var parametrosListado = new Dictionary<string, List<ValorHomologacion>> {{"IdiomaId", listaIdiomas}};

            return View(parametrosListado);
        }

        [HttpPost]
        public JsonResult Listar(GridTable gridTable)
        {
            return ListarJQGrid(new ListParameter<Usuario, UsuarioDto>
            {
                BusinessLogicClass = _usuarioBL,
                Grid = gridTable,
                SelecctionFormat = p => new UsuarioDto
                {
                    Id = p.Id,
                    UserName = p.UserName,
                    Email = p.Email,
                    Nombre = p.Nombre,
                    Apellido = p.Apellido,
                    Telefono = p.Telefono,
                    Idioma = GlobalParameters.Idiomas[p.IdiomaId],
                    Estado = p.Estado
                }
            });
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Accion = "Edit";

            var usuarioActual = UsuarioConverter.DomainToDto(_usuarioBL.GetById(id));
            return View(usuarioActual);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(UsuarioDto usuarioDto)
        {
            var response = new JsonResponse {Success = false};

            if (!ModelState.IsValid)
            {
                response.Message = "Favor ingrese los campos requeridos.";
            }
            else
            {
                try
                {
                    var entityTemp =
                        _usuarioBL.Get(
                            p => p.UserName == usuarioDto.UserName && p.Id != usuarioDto.Id && p.Estado == (int) TipoEstado.Activo);

                    if (entityTemp == null)
                    {
                        var usuarioDomain = _usuarioBL.GetById(usuarioDto.Id);
                        UsuarioConverter.DtoToDomain(usuarioDomain, usuarioDto);

                        _usuarioBL.Update(usuarioDomain);

                        response.Message = "Se actualizó el usuario correctamente";
                        response.Success = true;
                    }
                    else
                    {
                        response.Message = "Ya existe el nombre de usuario";
                        response.Success = false;
                    }
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                }
            }

            return Json(response);
        }

        public ActionResult Crear()
        {
            ViewBag.Accion = "Crear";
            var usuarioDto = new UsuarioDto();

            return View("Edit", usuarioDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Crear(UsuarioDto usuarioDto)
        {
            var response = new JsonResponse { Success = false };

            if (!ModelState.IsValid)
            {
                response.Message = "Favor ingrese los campos requeridos.";
            }
            else
            {
                try
                {
                    var entityTemp =
                        _usuarioBL.Get(
                            p => p.UserName == usuarioDto.UserName && p.Estado == (int)TipoEstado.Activo);

                    if (entityTemp == null)
                    {
                        var usuarioDomain = new Usuario {Estado = (int) TipoEstado.Activo};

                        UsuarioConverter.DtoToDomain(usuarioDomain, usuarioDto);

                        _usuarioBL.Add(usuarioDomain);

                        response.Message = "Se registró el usuario correctamente";
                        response.Success = true;
                    }
                    else
                    {
                        response.Message = "Ya existe el nombre de usuario";
                        response.Success = false;
                    }
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                }
            }

            return Json(response);
        }
    }
}