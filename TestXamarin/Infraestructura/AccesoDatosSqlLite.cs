using SQLite;
using Xamarin.Forms;
using System.Collections.Generic;
using TestXamarin.Infraestructura;
using TestXamarin.Dominio.Modelos;
using System;

[assembly: Dependency(typeof(AccesoDatosSqlLite))]
namespace TestXamarin.Infraestructura
{
    public class AccesoDatosSqlLite : IAccesoDatos
    {
        private readonly SQLiteConnection BaseDatos;

        public AccesoDatosSqlLite()
        {
            ISQLitePlataforma plataforma = DependencyService.Get<ISQLitePlataforma>();
            BaseDatos = plataforma.ObtenerConexion();
            BaseDatos.CreateTable<Autor>();
            BaseDatos.CreateTable<Tip>();
            CargarAutoresPorDefecto();
        }
        public void Insertar<TModelo>(TModelo modelo)
        {
            BaseDatos.Insert(modelo);
        }
        public void Actualizar<TModelo>(TModelo modelo)
        {
            BaseDatos.Update(modelo);
        }
        public void Eliminar<TModelo>(TModelo modelo)
        {
            BaseDatos.Delete(modelo);
        }
        public List<TModelo> ObtenerLista<TModelo>() where TModelo : new()
        {
            return BaseDatos.Table<TModelo>().ToList();
        }
        public TModelo ObtenerRegistro<TModelo>(object id) where TModelo : new()
        {
            return BaseDatos.Find<TModelo>(id);
        }

        private void CargarAutoresPorDefecto()
        {
            List<Autor> autores = ObtenerLista<Autor>();
            if (autores == null || autores.Count == 0)
            {
                Insertar(new Autor { Nombre = "Autor 1"});
                Insertar(new Autor { Nombre = "Autor 2"});
                Insertar(new Autor { Nombre = "Autor 3"});
            }
        }
    }
}
