namespace TestXamarin.Dominio.ModelosDeVistas
{
    using System.Collections.ObjectModel;
    using Modelos;
    using Infraestructura;
    using System.Collections.Generic;
    using Xamarin.Forms;
    using System.Windows.Input;
    using System;
    using Vistas;
    using System.Linq;

    public class ListadoTipsViewModel
    {
        private readonly IAccesoDatos AccesoDatos;
        public ICommand BotonNavegarDetalle { get; set; }
        public ICommand BotonEliminar { get; set; }
        public ObservableCollection<Tip> Tips { get; set; }
        public ListadoTipsViewModel()
        {
            AccesoDatos = DependencyService.Get<IAccesoDatos>();
            ObtenerTips();
            BotonNavegarDetalle = new Command(NavegarDetalle);
            BotonEliminar = new Command(EliminarTip);
        }

        private void EliminarTip(object obj)
        {
            Tip tip = obj as Tip;
            AccesoDatos.Eliminar(tip);
            Application.Current.MainPage = new ListadoTipsPage();
        }

        private void NavegarDetalle(object obj)
        {
            if (obj != null)
            {
                Application.Current.MainPage = new TipDetalle(obj as Tip);
            }
            else 
            {
                Application.Current.MainPage = new TipDetalle(null);
            }
        }

        private void ObtenerTips()
        {
            List<Tip> tips = AccesoDatos.ObtenerLista<Tip>().OrderByDescending(s => s.FechaCreacion).ToList();
            Tips = new ObservableCollection<Tip>(tips);
        }
    }
}
