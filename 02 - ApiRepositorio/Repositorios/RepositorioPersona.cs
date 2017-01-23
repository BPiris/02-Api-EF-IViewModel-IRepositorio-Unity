using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _02___ApiRepositorio.Models.EF;
using _02___ApiRepositorio.Models.Views;
using _02___ApiRepositorio.Repositorios.Base;

namespace _02___ApiRepositorio.Repositorios
{
    public class RepositorioPersona : Repositorio<PersonaViewModel, Persona>
    {
        public RepositorioPersona(clasetajamarEntities context) : base(context)
        {
        }
    }
}