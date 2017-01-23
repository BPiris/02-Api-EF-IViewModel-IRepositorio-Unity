using _02___ApiRepositorio.Models.EF;
using _02___ApiRepositorio.Models.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace _02___ApiRepositorio.Models.Views
{
    public class PersonaViewModel : IViewModel<Persona>
    {
        public String Nombre { get; set; }
        public string Apellidos { get; set; }
        public int idPersona { get; set; }
        public int idDireccion { get; set; }
        public DireccionViewModel DireccionPersona { get; set; }

        //Externas al modelo
        public String NombreCompleto { get; set; }

        public void FromModel(Persona model)
        {
            Nombre = model.Nombre;
            Apellidos = model.Apellidos;
            idPersona = model.idPersona;
            idDireccion = model.idDireccion;

            NombreCompleto = model.Nombre + " " + model.Apellidos;

            var temp = new DireccionViewModel();
            temp.FromModel(model.Direccion);
            DireccionPersona = temp;
        }

        public int[] GetPk()
        {
            return new[] { idPersona };
        }

        public Persona ToModel()
        {
            return new Persona {
                Nombre=Nombre,
                Apellidos= Apellidos,
                idPersona = idPersona,
                idDireccion = idDireccion
            };
        }

        public void UpdateModel(Persona model)
        {
            model.Nombre = Nombre;
            model.Apellidos = Apellidos;
            model.idPersona = idPersona;
            model.idDireccion = idDireccion;
        }
    }
}