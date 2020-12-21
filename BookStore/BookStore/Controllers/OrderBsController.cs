using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;
using BookStore.ApplicationLogic;
using BookStore.DTO;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderBsController : ControllerBase
    {
        private readonly BookStoredbContext _context;
        private readonly IOrderApplicationLogics _orderApplicationLogics;

        public OrderBsController(BookStoredbContext context, IOrderApplicationLogics orderApplicationLogics)
        {
            _context = context;
            this._orderApplicationLogics = orderApplicationLogics;
        }

        // GET: api/OrderBs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderB>>> GetOrderBs()
        {
            try
            {

                return Ok(await _orderApplicationLogics.getOrders());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
           
            
        }

        // GET: api/OrderBs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrderB(int id)
        {
            var orderB = await _orderApplicationLogics.getOder(id);

            if (orderB == null)
            {
                return NotFound();
            }

            return orderB;
        }

        // PUT: api/OrderBs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDTO>> PutOrderB(int id, OrderDTO order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            return await _orderApplicationLogics.updateOrderB(order);

            return NoContent();
        }

        // POST: api/OrderBs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrderB>> PostOrderB(OrderDTO order)
        {
            await _orderApplicationLogics.addOrder(order);
            return CreatedAtAction("GetOrderB", new { id = order.OrderId }, order);
        }

        // DELETE: api/OrderBs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderB>> DeleteOrderB(int id)
        {
            var orderB = await _context.OrderB.FindAsync(id);
            if (orderB == null)
            {
                return NotFound();
            }

            _context.OrderB.Remove(orderB);
            await _context.SaveChangesAsync();

            return orderB;
        }

        private bool OrderBExists(int id)
        {
            return _context.OrderB.Any(e => e.OrderId == id);
        }
    }
}
