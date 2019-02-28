using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AMVC.Models;
using System.Data;
using System.Web.Mvc;
using AMVC.Controllers;

namespace AMVC.ViewModels.Home
{
    public class ProductListViewModel
    {
        public ProductListViewModel(IEnumerable<Product> product)
        {
          var ProductsList = product.Select(p => new SelectListItem() { Text = p.ToString() });
        }
    }
}