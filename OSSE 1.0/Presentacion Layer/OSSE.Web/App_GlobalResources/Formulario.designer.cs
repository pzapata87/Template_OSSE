//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.34014
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile el proyecto de Visual Studio.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Web.Application.StronglyTypedResourceProxyBuilder", "11.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Formulario {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Formulario() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.Formulario", global::System.Reflection.Assembly.Load("App_GlobalResources"));
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Invalida la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Debe seleccionar un formulario y no un módulo.
        /// </summary>
        internal static string MensajeErrorModulo {
            get {
                return ResourceManager.GetString("MensajeErrorModulo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Módulos.
        /// </summary>
        internal static string Modulos {
            get {
                return ResourceManager.GetString("Modulos", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Formulario.
        /// </summary>
        internal static string NombreFormulario {
            get {
                return ResourceManager.GetString("NombreFormulario", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Rol.
        /// </summary>
        internal static string NombreRol {
            get {
                return ResourceManager.GetString("NombreRol", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Permisos.
        /// </summary>
        internal static string Permisos {
            get {
                return ResourceManager.GetString("Permisos", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Roles.
        /// </summary>
        internal static string TituloGridRoles {
            get {
                return ResourceManager.GetString("TituloGridRoles", resourceCulture);
            }
        }
    }
}