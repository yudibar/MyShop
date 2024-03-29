﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyShop.Core.Models
{
    public class Product : BaseEntity
    {
        

        [StringLength(20)]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }

        /*public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }*/
    }
}
