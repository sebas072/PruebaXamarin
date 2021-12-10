using SQLiteNetExtensions.Attributes;
using System;

namespace TestXamarin.Dominio.Modelos
{
    public class Tip : ClaseBaseModelo
    {
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        [ForeignKey(typeof(Autor))]
        public Guid AutorId { get; set; }
    }
}
