using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using SportStore.WebUI.Models;
using System.Collections.Generic;

namespace SportStore.Domain.Concrete
{
	public class EFProductRepository : IProductRepository
	{
		private EFDbContext context = new EFDbContext();
		public IEnumerable<Product> Products {
			get { return context.Products; }
		}
	}
}
