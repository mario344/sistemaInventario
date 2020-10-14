using Microsoft.EntityFrameworkCore;
using SistemaInventario.AccesoDatos.Data;
using SistemaInventario.AccesoDatos.repositorio.iRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SistemaInventario.AccesoDatos.repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbset;

        public Repositorio(ApplicationDbContext db)
        {
            _db = db;
            this.dbset = _db.Set<T>();
        }

        public void Agregar(T entidad)
        {
            dbset.Add(entidad); //insert into Table
        }

        public T Obtener(int id)
        {
            return dbset.Find(id); //select * from
        }

        public T ObtenerPrimero(Expression<Func<T, bool>> filter = null, string incluirPropiedades = null)
        {
            IQueryable<T> query = dbset;
            if (filter != null) ;
            {
                query = query.Where(filter); //select * from where...
            }

            if (incluirPropiedades != null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);
                }
            }



            return query.FirstOrDefault();
        }

        public IEnumerable<T> ObtenerTodos(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string incluirPropiedades = null)
        {
            IQueryable<T> query = dbset;
            if (filter != null);
            {
                query = query.Where(filter); //select * from where...
            }

            if (incluirPropiedades != null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) 
                {
                    query = query.Include(incluirProp);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        public void Remover(int id)
        {
           T entidad = dbset.Find(id);
            Remover(entidad);
        }

        public void Remover(T entidad)
        {
            dbset.Remove(entidad); //delete from
        }

        public void RemoverRango(IEnumerable<T> entidad)
        {
            dbset.RemoveRange(entidad);
        }
    }
}
