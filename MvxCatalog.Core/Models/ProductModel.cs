using System;
using System.Collections.Generic;
using System.Text;

namespace MvxCatalog.Core.Models
{

    [Serializable]
    public class ProductModel
    {
        public string Name { get; set; } = "";

        public string Info { get; set; } = "";

        public string Img { get; set; } = "";

        public override string ToString()
        {
            return Name;
        }
    }
}
