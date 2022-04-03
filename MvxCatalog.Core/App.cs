using MvvmCross.ViewModels;
using MvxCatalog.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvxCatalog.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<CatalogViewModel>();
        }
    }
}
