using SistemaInventario.AccesoDatos.repositorio.iRepositorio;
using SistemaInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.AccesoDatos.repositorio.IRepositorio
{
   public interface IbodegaRepositorio : IRepositorio<Bodega>
    {
        void Actualizar(Bodega bodega);
    }
}
