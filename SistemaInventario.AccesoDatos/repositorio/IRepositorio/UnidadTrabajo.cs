using SistemaInventario.AccesoDatos.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.AccesoDatos.repositorio.IRepositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public IbodegaRepositorio Bodega { get; private set; }

        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Bodega = new BodegaRepositorio(_db); // Inicializamos
        }

        public void Guardar() 
        {
            _db.SaveChanges(); //guarda cambios en la base de datos
        }

        public void Dispose()
        {
            _db.Dispose();  //libera todo lo que esta en memoria 
        }
    }
}
