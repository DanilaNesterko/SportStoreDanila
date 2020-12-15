using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CredentialManagement;
using SportsStore.WebUI.Infrastructure.Concrete;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using SportStore.WebUI.Controllers;
using SportStore.WebUI.Infrastructure.Abstract;

namespace SportsStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;
        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            /*PasswordRepository passwordRepository = new PasswordRepository();
            passwordRepository.SavePassword("test", "test123");*/

         /*   HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            string cookiePath = ticket.CookiePath;
            DateTime expiration = ticket.Expiration;
            bool expired = ticket.Expired;
            bool isPersistent = ticket.IsPersistent;
            DateTime issueDate = ticket.IssueDate;
            string name = ticket.Name;
            string userData = ticket.UserData;
            int version = ticket.Version;
            FormsAuthentication.GetAuthCookie("admin", isPersistent).Value.ToString();*/

            return View(repository.Products);
        }
        public ViewResult Edit(int productId)
        {
            Product product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(product);
            }
        }
        public ViewResult Create()
        {
            return View("Edit", new Product());
        }
        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Logout()
        {
             /*HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
             FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

             string cookiePath = ticket.CookiePath;
             DateTime expiration = ticket.Expiration;
             bool expired = ticket.Expired;
             bool isPersistent = ticket.IsPersistent;
             DateTime issueDate = ticket.IssueDate;
             string name = ticket.Name;
             string userData = ticket.UserData;
             int version = ticket.Version;*/
            if (ModelState.IsValid)
            {
                FormsAuthentication.SignOut();
            }
            return RedirectToAction("Index");
        }
        public ActionResult LogoutMain()
        {
            if (ModelState.IsValid)
            {
                FormsAuthentication.SignOut();
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
    public class PasswordRepository
    {
        private const string PasswordName = "ServerPassword";
        private const string userName = "usser";

        public void SavePassword(string password, string username)
        {
            using (var cred = new Credential())
            {
                cred.Username = username;
                cred.Password = password;
                cred.Target = PasswordName;
                cred.Type = CredentialType.Generic;
                cred.PersistanceType = PersistanceType.Session;
                cred.Save();
            }
        }

        public string GetPassword()
        {
            using (var cred = new Credential())
            {
                cred.Target = PasswordName;
                cred.Load();
                return cred.Password;
            }
        }
        public string GetUser()
        {
            using (var cred = new Credential())
            {
                cred.Target = userName;
                cred.Load();
                return cred.Username;
            }
        }
    }
}