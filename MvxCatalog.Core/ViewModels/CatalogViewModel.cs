using MvvmCross.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;
using MvxCatalog.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using Newtonsoft.Json;
using System.IO;
using MvvmCross.Plugin.Json;
using System.Linq;

namespace MvxCatalog.Core.ViewModels
{
    public class CatalogViewModel : MvxViewModel
    {
        private const int itemHeight = 230;

        private int _listHeight;

        public int ListHeight
        {
            get { return _listHeight; }
            set { SetProperty(ref _listHeight, value); ; }
        }


        private MvxObservableCollection<ProductModel> _products;

        private ProductModel selectedItem ;

        public ProductModel SelectedItem
        {
            get { return selectedItem; }
            set { SetProperty(ref selectedItem, value); }
        }


        public MvxObservableCollection<ProductModel> Products
        {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _info;

        public string Info
        {
            get { return _info; }
            set { SetProperty(ref _info, value); }
        }

        private string _img;

        public string Img
        {
            get { return _img; }
            set { SetProperty(ref _info, value); }
        }

        public void AddProduct()
        {
            _navigationService.Navigate(new AddViewModel(this._navigationService) { Products = this.Products});
        }

        public void More()
        {
            if (SelectedItem == null)
                return;
            _navigationService.Navigate(new MoreViewModel(this._navigationService, SelectedItem));
        }

        public void Update()
        {
            if (SelectedItem == null)
                return;
            _navigationService.Navigate(new UpdateViewModel(this._navigationService) { Product = SelectedItem });
        }

        public void Sort()
        {
            Products = new MvxObservableCollection<ProductModel>(Products.OrderBy(i => i.ToString()));
        }

        public void Delete()
        {
            if (SelectedItem == null)
                return;
            _products.Remove(SelectedItem);
        }

        public IMvxCommand AddProductCommand { get; set; }

        public IMvxCommand SortCommand { get; set; }

        public IMvxCommand MoreCommand { get; set; }

        public IMvxCommand UpdateCommand { get; set; }

        public IMvxCommand DeleteCommand { get; set; }


        private readonly IMvxNavigationService _navigationService;

        public CatalogViewModel(IMvxNavigationService navigationService)
        {
            try
            {
                string list = File.ReadAllText("List.json");
                Products = JsonConvert.DeserializeObject<MvxObservableCollection<ProductModel>>(list);
            }
            catch
            {
                Products = new MvxObservableCollection<ProductModel>();
            }
            _navigationService = navigationService;
            ListHeight = Products.Count * itemHeight;
            AddProductCommand = new MvxCommand(AddProduct);
            MoreCommand = new MvxCommand(More);
            UpdateCommand = new MvxCommand(Update);
            DeleteCommand = new MvxCommand(Delete);
            SortCommand = new MvxCommand(Sort);
        }

        ~CatalogViewModel()
        {
            string list = JsonConvert.SerializeObject(Products);
            File.WriteAllText("List.json", list);
        }
    }
}
