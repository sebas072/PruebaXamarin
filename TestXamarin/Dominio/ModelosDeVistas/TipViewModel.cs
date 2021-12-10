namespace TestXamarin.Dominio.ModelosDeVistas
{
    using Modelos;
    using Infraestructura;
    using Xamarin.Forms;
    using System.Windows.Input;
    using Vistas;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System;
    using System.Linq;

    public class TipViewModel : INotifyPropertyChanged
    {
        private readonly IAccesoDatos AccesoDatos;
        private bool EsCreacion;
        public ICommand BotonGuardar { get; set; }
        public Tip Tip { get; set; }
        public List<Autor> Autores { get; set; }
        public Autor Autor
        {
            get
            {
                return _Autor;
            }
            set
            {
                SetProperty(ref _Autor, value);
            }
        }

        private Autor _Autor;

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T backingStore,
                                      T value,
                                      [CallerMemberName] string propertyName = "",
                                      Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public TipViewModel(Tip tip)
        {
            if (tip is null)
            {
                EsCreacion = true;
            }
            Tip = tip ?? new Tip();
            AccesoDatos = DependencyService.Get<IAccesoDatos>();
            BotonGuardar = new Command(GuardarTip);
            Autores = AccesoDatos.ObtenerLista<Autor>();
            if (!EsCreacion)
            {
                _Autor = Autores.FirstOrDefault(s => s.Id == Tip.AutorId);
            }
        }

        private async void GuardarTip()
        {
            if (string.IsNullOrEmpty(Tip.Descripcion))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ingresar descripcion", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(Tip.Titulo))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ingresar titulo", "Ok");
                return;
            }

            if (_Autor == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes seleccionar un autor", "Ok");
                return;
            }

            Tip.AutorId = _Autor.Id;
            if (EsCreacion)
            {
                AccesoDatos.Insertar(Tip);
            }
            else
            {
                AccesoDatos.Actualizar(Tip);
            }
            Application.Current.MainPage = new ListadoTipsPage();
        }
    }
}
