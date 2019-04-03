﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Store.Models
{
    /// <summary>
    /// Good model for create entity in database
    /// </summary>
    public class Good
    {
        public Good()
        {
            Storages = new List<GoodStorage>();
            Orders = new List<GoodOrder>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Specification { get; set; }

        public string PhotoUrl { get; set; }

        public int YearOfManufacture { get; set; }

        public int WarrantyTerm { get; set; }

        public int ProducerId { get; set; }

        public Producer Producer { get; set; }

        public decimal Price { get; set; }

        public string Type { get; set; }

        public int Count { get; set; }

        public ICollection<GoodOrder> Orders { get; set; }

        public ICollection<GoodStorage> Storages { get; set; }
    }
}