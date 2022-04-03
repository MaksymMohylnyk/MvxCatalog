using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using MvxCatalog.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace MvxCatalog.Core.ViewModels
{
    public class AddViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        private ProductModel _newProduct;

        public ProductModel NewProduct
        {
            get { return _newProduct; }
            set { SetProperty(ref _newProduct, value); }
        }

        private MvxObservableCollection<ProductModel> _products;
        public MvxObservableCollection<ProductModel> Products
        {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }

        public AddViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            NewProduct = new ProductModel();
            AddCommand = new MvxCommand(Add);
            BackCommand = new MvxCommand(Back);
        }

        public void Add()
        {
            Products.Add(NewProduct);
            _navigationService.Close(this);
        }

        public void Back()
        {
            _navigationService.Close(this);
        }

        public IMvxCommand AddCommand { get; set; }

        public IMvxCommand BackCommand { get; set; }
    }
}
