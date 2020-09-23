using SportStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore.WebUI.Controllers
{
	public class ProductController : Controller
	{
		private IProductRepository repository;
		public ProductController(IProductRepository productRepository)
		{
			repository = productRepository;
		}
		public ViewResult List(int page = 1)
		{
			return View(repository.Products
			.OrderBy(p => p.ProductID)
			.Skip((page - 1) * 200)
			.Take(200));
		}
	}
}