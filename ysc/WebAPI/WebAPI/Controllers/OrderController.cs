using System;
using WebAPI.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public OrderController(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }


        [HttpPost]
        [Route("insOrder")]
        public async Task<IActionResult> InsOrder(Order pOrder)
        {
            try
            {
                var paramss = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@caId",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = pOrder.caId
                        },
                        new SqlParameter() {
                            ParameterName = "@cuId",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = pOrder.cuId
                        },
                        new SqlParameter() {
                            ParameterName = "@amount",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = pOrder.amount
                        }
                };
                await _context.Database.ExecuteSqlRawAsync("EXEC insOrder @caId, @cuId, @amount", paramss);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}