using SQLite;
using System.IO;
using TestXamarin.Droid;
using TestXamarin.Infraestructura;
[assembly: Xamarin.Forms.Dependency(typeof(AndroidSQLitePlataforma))]
namespace TestXamarin.Droid
{
    public class AndroidSQLitePlataforma : ISQLitePlataforma
    {
        private string ObtenerCarpeta()
        {
            string nombreBaseDatos = "TestXamarin.db3";
            string carpeta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), nombreBaseDatos);
            return carpeta;
        }

        public SQLiteConnection ObtenerConexion()
        {
            return new SQLiteConnection(ObtenerCarpeta());
        }
    }
}