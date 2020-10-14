using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.AccesoDatos.repositorio.IRepositorio
{
     public interface IUnidadTrabajo : IDisposable
    {
        IbodegaRepositorio Bodega { get; }
    }
}
