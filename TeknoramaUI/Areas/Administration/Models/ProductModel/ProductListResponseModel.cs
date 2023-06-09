﻿using TeknoramaUI.Areas.Administration.Models.CategoryModel;
using TeknoramaUI.Areas.Administration.Models.SupplierModel;

namespace TeknoramaUI.Areas.Administration.Models.ProductModel
{
    public class ProductListResponseModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public CategoryListResponseModel Category { get; set; }
        public int SupplierId { get; set; }
        public SupplierListResponseModel Supplier { get; set; }
    }
}
