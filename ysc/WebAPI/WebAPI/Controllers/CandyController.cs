using System;
using System.Linq;
using WebAPI.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandyController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public CandyController(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }


        [HttpGet]
        [Route("getAllCandies")]
        public async Task<IActionResult> GetAllCandies()
        {
            try
            {
                var result = new JsonResult(await _context.tblCandy.FromSqlRaw<Candy>($"exec getAllCandies").ToListAsync());
                Response.StatusCode = StatusCodes.Status200OK;
                return (result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        [Route("getCandyById")]
        public async Task<IActionResult> GetCandyById(int id)
        {
            try
            {
                var result = new JsonResult(_context.tblCandy.FromSqlRaw<Candy>($"exec getCandyById @caId = {id}").ToListAsync().Result.FirstOrDefault());
                Response.StatusCode = StatusCodes.Status200OK;
                return (result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        [Route("getCandiesAmount")]
        public async Task<IActionResult> GetCandiesAmount()
        {
            try
            {
                var result = new JsonResult(await _context.tblCandyAmount.FromSqlRaw<CandiesAmount>($"exec getCandiesAmount").ToListAsync());
                Response.StatusCode = StatusCodes.Status200OK;
                return (result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        [Route("insCandy")]
        public async Task<IActionResult> InsCandy(Candy pCandy) //HttpResponseMessage
        {
            try
            {
                var paramss = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@caName",
                            SqlDbType =  System.Data.SqlDbType.NVarChar,
                            Size = 20,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = pCandy.caName
                        },
                        new SqlParameter() {
                            ParameterName = "@caImage",
                            SqlDbType =  System.Data.SqlDbType.NVarChar,
                            Size = 10,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = pCandy.caImage
                        }
                };
                await _context.Database.ExecuteSqlRawAsync("EXEC insCandy @caName, @caImage", paramss);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut]
        [Route("updCandy")]
        public async Task<IActionResult> UpdCandy(Candy pCandy)
        {
            try
            {
                var paramss = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@caId",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = pCandy.caId
                        },
                        new SqlParameter() {
                            ParameterName = "@caName",
                            SqlDbType =  System.Data.SqlDbType.NVarChar,
                            Size = 20,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = pCandy.caName
                        },
                        new SqlParameter() {
                            ParameterName = "@caImage",
                            SqlDbType =  System.Data.SqlDbType.NVarChar,
                            Size = 10,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = pCandy.caImage
                        }
                };
                await _context.Database.ExecuteSqlRawAsync("EXEC updCandy @caId, @caName, @caImage", paramss);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}