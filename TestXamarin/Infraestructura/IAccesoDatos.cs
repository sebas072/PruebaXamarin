using System.Collections.Generic;

namespace TestXamarin.Infraestructura
{
    public interface IAccesoDatos
    {
        void Insertar<TModelo>(TModelo modelo);
        void Actualizar<TModelo>(TModelo modelo);
        void Eliminar<TModelo>(TModelo modelo);
        List<TModelo> ObtenerLista<TModelo>() where TModelo : new();
        TModelo ObtenerRegistro<TModelo>(object id) where TModelo : new();
    }
}
