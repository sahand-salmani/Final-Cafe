using System;
using System.Threading.Tasks;
using CafeTap.Controllers.Base;
using Infrastructure.EmployeePayments.Queries;
using Infrastructure.EmployeePayments.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.Controllers
{
    public class HomeController : MyController
    {
        [HttpGet]
        [Route("Home")]
        public IActionResult Index()
        {

            return View();
        }


        [HttpGet]
        [Route("/testt")]
        public async Task<IActionResult> Test()
        {
            var start = new DateTime(DateTime.Now.Year, 1, 1);
            var ends = new DateTime(DateTime.Now.Year, 12, 30);
            var query = new GetEmployeePaymentByMonthQuery(1,start, ends);
            var result = await Mediator.Send(query);

            return Ok();
        }
    }
}
