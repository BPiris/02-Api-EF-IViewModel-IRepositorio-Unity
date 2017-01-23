using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _02___ApiRepositorio.Models.Views;
using _02___ApiRepositorio.Repositorios;

namespace _02___ApiRepositorio.Controllers
{
    public class PersonasController : ApiController
    {
        [Dependency]
        public RepositorioPersona _repoPersona { get; set; }

        public List<PersonaViewModel> Get()
        {
            return _repoPersona.Get();
        }

        public PersonaViewModel Get(int idPersona)
        {
            return _repoPersona.Get(idPersona);
        }

        public PersonaViewModel Post([FromBody] PersonaViewModel modelo)
        {
            return _repoPersona.Add(modelo);
        }

        public int Put([FromBody] PersonaViewModel modeloActualizar)
        {
            return _repoPersona.Update(modeloActualizar);
        }

        public int Delete(int idPersona)
        {
            return _repoPersona.Delete(idPersona);
        }

    }
}
