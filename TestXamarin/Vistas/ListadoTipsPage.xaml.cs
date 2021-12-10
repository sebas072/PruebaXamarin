namespace TestXamarin.Vistas
{
    using Dominio.ModelosDeVistas;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListadoTipsPage : ContentPage
    {
        public ListadoTipsPage()
        {
            InitializeComponent();
            BindingContext = new ListadoTipsViewModel();
        }
    }
}