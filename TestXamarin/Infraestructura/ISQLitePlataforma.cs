using SQLite;

namespace TestXamarin.Infraestructura
{
    public interface ISQLitePlataforma
    {
        SQLiteConnection ObtenerConexion();
    }
}
