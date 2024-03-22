
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppMVVM.ViewModels
{
    public class ProductosViewModels : BaseViewModel
    {
        private String _nombre;
        private double _precio;
        private String _foto;

        public String Nombre 
        {
            get { return _nombre; }
            set { _nombre = value;  OnPropertyChanged(); }
        }

        public double Precio
        {
            get { return _precio; }
            set { _precio = value; OnPropertyChanged(); }
        }

        public String Foto
        {
            get { return _foto; }
            set { _foto = value; OnPropertyChanged(); }
        }

        public ProductosViewModels() 
        {
            CleanCommand = new Command(Cleaner);
            CreateCommand = new Command(async () => await CreateData());
        }

        public ICommand CleanCommand {  get; private set; }
        public ICommand CreateCommand {  get; private set; }
        public ICommand ReadCommand {  get; private set; }
        public ICommand UpdateCommand {  get; private set; }
        public ICommand DeleteCommand {  get; private set; }


        void Cleaner()
        {
            Nombre = string.Empty;
            Precio = 0;
            Foto   = string.Empty;
        }


        // CRUD
        async Task CreateData()
        {
            try 
            {
                var product = new Models.Productos
                {
                    Nombre = Nombre,
                    Precio = Precio,
                    Foto = Foto
                };

                // SQLITE 
                // RESTAPI

                await Task.Delay(1000);

            }
            catch 
            {

            }
        }
    }
}
