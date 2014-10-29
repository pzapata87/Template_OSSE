﻿namespace SIGCOMT.DTO
{
    public class PermisoFormularioDto
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public int TipoPermiso { get; set; }
        public bool Activo { get; set; }
        public string NombrePermiso { get; set; }

        //ToDo: quitar estos atributos
        public bool Mostrar { get; set; }
        public bool Crear { get; set; }
        public bool Modificar { get; set; }
        public bool Eliminar { get; set; }
        public bool Imprimir { get; set; }
        public bool Mover { get; set; }
        public bool Reportar { get; set; }
    }
}