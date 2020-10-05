using SportStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SportStore.WebUI.Models
{
	public class EFDbContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
	}
}