using System;
using System.Linq;
using WebAPI.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public CustomerController(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }


        [HttpGet]
        [Route("getAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var result = new JsonResult(await _context.tblCustomer.FromSqlRaw<Customer>($"exec getAllCustomers").ToListAsync());
                Response.StatusCode = StatusCodes.Status200OK;
                return (result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        [Route("getCustomerLogin")]
        public async Task<IActionResult> GetCustomerLogin(string cuName, string password)
        {
            try
            {
                var result = new JsonResult(_context.tblCustomer.FromSqlRaw<Customer>($"exec getCustomerLogin {cuName}, {password}").ToListAsync().Result.FirstOrDefault());
                Response.StatusCode = StatusCodes.Status200OK;
                return (result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}