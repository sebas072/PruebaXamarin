namespace TestXamarin
{
    using TestXamarin.Infraestructura;
    using Vistas;
    using Xamarin.Forms;

    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<IAccesoDatos, AccesoDatosSqlLite>();
            MainPage = new ListadoTipsPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
