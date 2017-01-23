using _02___ApiRepositorio.Models.EF;
using _02___ApiRepositorio.Models.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02___ApiRepositorio.Models.Views
{
    public class DireccionViewModel : IViewModel<Direccion>
    {
        public string Via { get; set; }
        public string NombreVia { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public int idDireccion { get; set; }

        public void FromModel(Direccion model)
        {
            Via = model.Via;
            NombreVia = model.NombreVia;
            Ciudad = model.Ciudad;
            Pais = model.Pais;
            idDireccion = model.idDireccion;
        }

        public int[] GetPk()
        {
            return new[] { idDireccion };
        }

        public Direccion ToModel()
        {
            return new Direccion {
                Via = Via,
                NombreVia= NombreVia,
                Ciudad= Ciudad, 
                Pais = Pais,
                idDireccion = idDireccion
            };
        }

        public void UpdateModel(Direccion model)
        {
            model.Via = Via;
            model.NombreVia = NombreVia;
            model.Ciudad = Ciudad;
            model.Pais = Pais;
            model.idDireccion = idDireccion;
        }
    }
}