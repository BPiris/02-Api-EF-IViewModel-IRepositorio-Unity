using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _02___ApiRepositorio.Repositorios.Base
{
    public interface IRepositorio<TView, TEntity> : IDisposable 
    {
        TView Get(int pk);
        List<TView> Get();
        TView Add(TView model);
        int Update(TView model);
        int Delete(int pk);
        int Delete(Expression<Func<TEntity, bool>> busqueda, bool sencillo);
        List<TView> Find(Expression<Func<TEntity, bool>> busqueda, bool sencillo);
        TEntity GetModelByPk(TView model);
    }
}
