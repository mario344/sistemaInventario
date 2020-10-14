using SistemaInventario.AccesoDatos.Data;
using SistemaInventario.AccesoDatos.repositorio.IRepositorio;
using SistemaInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaInventario.AccesoDatos.repositorio
{
    public class BodegaRepositorio : Repositorio<Bodega>, IbodegaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public BodegaRepositorio(ApplicationDbContext db):base(db) 
        {
            _db = db;
        }

        public void Actualizar(Bodega bodega)
        {
            var bodegaDb = _db.Bodegas.FirstOrDefault(b => b.Id == bodega.Id);

            if(bodegaDb != null)
            {
                bodegaDb.Nombre = bodega.Nombre;
                bodegaDb.Descricion = bodega.Descricion;
                bodegaDb.Estado = bodega.Estado;

                _db.SaveChanges();

            }
        }
    }
}
