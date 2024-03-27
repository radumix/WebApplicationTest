using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationTest.Models;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace WebApplicationTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IEntity _entity;
        public HomeController(ILogger<HomeController> logger, IEntity entity)
        {
            _logger = logger;
            _entity = entity;
        }

        public IActionResult Index()
        {
            Customer customer = new Customer();

         
            ViewBag.Message = "";
            ViewBag.Remarks = false;

            if (Constant.hasTransaction && Constant.transactionSuccessful)
             {
                ViewBag.Message = Constant.SuccessMessage;
                ViewBag.Remarks = true;
                ViewBag.Alert = "alert-success";
             }
            else if (Constant.hasTransaction && !Constant.transactionSuccessful)
             {
                ViewBag.Message = Constant.ErrorMessage;
                ViewBag.Remarks = true;
                ViewBag.Alert = "alert-danger";
            }
            else
            {
                ViewBag.Remarks = false;
            }


            return View(customer);
        }

        public IActionResult Delete(string Id)
        {
            Customer customer = new Customer();

            customer = _entity.GetCustomerById(Id);

            return View(customer);
        }

        public IActionResult Update(string Id)
        {
            Customer customer = new Customer();

            customer = _entity.GetCustomerById(Id);

            return View(customer);
        }

        public IActionResult CustomerList()
        {
            List<Customer> list = new List<Customer>();

            list = _entity.GetCustomer();

            return PartialView("_Customer", list);
        }


        [HttpPost]
        public ActionResult SaveData(Customer customer)
        {
            TempData["Success"] = false;
            TempData["NewData"] = true;
            if (_entity.Save(customer))
            {
                Constant.hasTransaction = true;
                Constant.transactionSuccessful = true;
            }
            else
            {
                Constant.hasTransaction = true;
                Constant.transactionSuccessful = false;
            }
            //sss
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SaveChanges(Customer customer)
        {
            TempData["Success"] = false;
            TempData["NewData"] = true;
            if (_entity.update(customer))
            {
                Constant.hasTransaction = true;
                Constant.transactionSuccessful = true;
            }
            else
            {
                Constant.hasTransaction = true;
                Constant.transactionSuccessful = false;
            }
            //sss
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteRecord(Customer customer)
        {
            TempData["Success"] = false;
            TempData["NewData"] = true;
            if (_entity.delete(customer.Id.ToString()))
            {
                Constant.hasTransaction = true;
                Constant.transactionSuccessful = true;
            }
            else
            {
                Constant.hasTransaction = true;
                Constant.transactionSuccessful = false;
            }
            //sss
            return RedirectToAction("Index");
        }

    }
}
