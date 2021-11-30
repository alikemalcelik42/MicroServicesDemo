using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return Ok(_customerService.GetAll());
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return Ok(_customerService.GetById(id));
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            _customerService.Add(customer);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            _customerService.Update(customer);
            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult Delete(Customer customer)
        {
            _customerService.Delete(customer);
            return Ok();
        }
    }
}
