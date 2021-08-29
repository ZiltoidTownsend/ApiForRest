using LibraryMenu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrdersController : ControllerBase
    {
        ApplicationContext db;

        public OrdersController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<OrderData>> Get()
        {
            db.Orders.Add(new OrderData());
            db.SaveChanges();
            return await db.Orders.OrderBy(i => i).LastAsync();
        }
    }
}
