﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.App.Models
{
    public class ProductCreateViewModel
    {
        
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public SelectList Categories { get; set; }
    }
}
