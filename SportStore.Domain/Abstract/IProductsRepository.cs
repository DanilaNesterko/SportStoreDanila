using SportStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportStore.Domain.Abstract
{
	public interface IProductRepository
	{
		IEnumerable<Product> Products { get; }
		void SaveProduct(Product product);
		Product DeleteProduct(int productID);
	}
}
