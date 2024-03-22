using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppMVVM.ViewModels
{
    public class ListProductsViewModels : BaseViewModel
    {
        private ObservableCollection<Models.Productos> _products;

        public ObservableCollection<Models.Productos> Products
        {
            get { return _products; }
            set { _products = value; OnPropertyChanged(); }
        }

        private Models.Productos _selectedProduct;

        public Models.Productos SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; OnPropertyChanged(); }
        }

        public ICommand GoToDetailsCommand { private set; get; }

        public INavigation Navigation { get; set; }

        public ListProductsViewModels(INavigation navigation)
        {
            Navigation = navigation;
            GoToDetailsCommand = new Command<Type>(async (pageType) => await GoToDetails(pageType));

            Products = new ObservableCollection<Models.Productos>();

            // SQLITE 
            // RESTAPI
            // try catch


            Products.Add(new Models.Productos() { Id = 1, Nombre = "Televisor", Precio = 10.30, Foto = String.Empty });
            Products.Add(new Models.Productos() { Id = 2, Nombre = "Cortina", Precio = 12.78, Foto = String.Empty });
            Products.Add(new Models.Productos() { Id = 3, Nombre = "Parlante", Precio = 8, Foto = String.Empty });
        }

        async Task GoToDetails(Type pageType)
        {
            if (SelectedProduct != null)
            {
                var page = (Page)Activator.CreateInstance(pageType);

                page.BindingContext = new ProductosViewModels()
                {
                    
                    Nombre = SelectedProduct.Nombre,
                    Precio = SelectedProduct.Precio,
                    Foto = SelectedProduct.Foto,
                };

                await Navigation.PushAsync(page);
            }
        }

    }
}
