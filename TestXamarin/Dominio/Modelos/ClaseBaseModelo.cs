using SQLite;
using System;

namespace TestXamarin.Dominio.Modelos
{
    public class ClaseBaseModelo
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public DateTime FechaCreacion { get; set; }

        public ClaseBaseModelo()
        {
            Id = Guid.NewGuid();
            FechaCreacion = DateTime.Now;
        }
    }
}
