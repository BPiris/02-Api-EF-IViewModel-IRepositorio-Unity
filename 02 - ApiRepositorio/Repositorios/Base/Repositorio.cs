using _02___ApiRepositorio.Models.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using _02___ApiRepositorio.Models.EF;
using System.Data.Entity;

namespace _02___ApiRepositorio.Repositorios.Base
{
    public class Repositorio<TView, TEntity> :
        IRepositorio<TView, TEntity> where TView : class,
        IViewModel<TEntity>, new() where TEntity : class
    {
        private clasetajamarEntities Context;

        public Repositorio(clasetajamarEntities context)
        {
            Context = context;
        }

        protected DbSet<TEntity> DbSet
        {
            get { return Context.Set<TEntity>(); }
        }

        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
        }

        public TView Add(TView model)
        {
            var data = model.ToModel();

            DbSet.Add(data);

            try
            {
                Context.SaveChanges();
                model.FromModel(data);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            return model;
      
        }

        public int Delete(int pk)
        {
            var obj = DbSet.Find(pk);
            DbSet.Remove(obj);

            int n = 0;

            try
            {
                n = Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return n;
        }

        public int Delete(Expression<Func<TEntity, bool>> busqueda, bool sencillo)
        {
            var data = DbSet.Where(busqueda);

            foreach (var view in data)
            {
                DbSet.Remove(view);
            }

            try
            {
                return Context.SaveChanges();
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public List<TView> Find(Expression<Func<TEntity, bool>> busqueda, bool sencillo)
        {
            var data = DbSet.Where(busqueda);

            var lista = new List<TView>();

            foreach (var obj in data)
            {
                var view = new TView();

                view.FromModel(obj);

                lista.Add(view);
            }

            return lista;
        }

        public List<TView> Get()
        {
            var lista = new List<TView>();
            var data = DbSet;
            foreach (var obj in data)
            {
                var v = new TView();
                v.FromModel(obj);
                lista.Add(v);
            }
            return lista;
        }

        public TView Get(int pk)
        {
            var model = DbSet.Find(pk);

            var view = new TView();

            view.FromModel(model);

            return view;
        }

        public TEntity GetModelByPk(TView model)
        {
            int[] pks = model.GetPk();
            TEntity data = null;
            if (pks.Length == 1)
            {
                data = DbSet.Find(pks[0]);
            }
            else if (pks.Length == 2)
            {
                data = DbSet.Find(pks[0],pks[1]);
            }
            else if (pks.Length == 3)
            {
                data = DbSet.Find(pks[0], pks[1], pks[2]);
            }

            return data;
        }

        public int Update(TView model)
        {
            var data = GetModelByPk(model);

            model.UpdateModel(data);

            try
            {
                int r = Context.SaveChanges();
                model.FromModel(data);
                return r;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }

        }
    }
}