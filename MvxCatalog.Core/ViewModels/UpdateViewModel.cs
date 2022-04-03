using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using MvxCatalog.Core.Models;
using MvvmCross.Commands;

namespace MvxCatalog.Core.ViewModels
{
    public class UpdateViewModel: MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public UpdateViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            BackCommand = new MvxCommand(Back);
        }

        private ProductModel _product;

        public ProductModel Product
        {
            get { return _product; }
            set { SetProperty(ref _product, value); }
        }

        public IMvxCommand BackCommand { get; set; }

        public void Back()
        {
            _navigationService.Close(this);
        }
    }
}
