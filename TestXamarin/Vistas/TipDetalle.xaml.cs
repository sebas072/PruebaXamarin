using System;
namespace TestXamarin.Vistas
{
    using Dominio.Modelos;
    using Dominio.ModelosDeVistas;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipDetalle : ContentPage
    {
        public TipDetalle(Tip tip)
        {
            InitializeComponent();
            BindingContext = new TipViewModel(tip);
        }
    }
}