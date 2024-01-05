using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductDetails.Models;

namespace ProductDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductinfoContext _dbContext;
        public ProductController(ProductinfoContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productsinfo>>> GetProducts()
        {
            if (_dbContext.Productsinfos == null)
            {
                return NotFound();
            }
            return await _dbContext.Productsinfos.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Productsinfo>> GetProduct(int id)
        {
            if (_dbContext.Productsinfos == null)
            { 
                return NotFound();     
            }
            var product=await _dbContext.Productsinfos.FindAsync(id);
            if(product == null)
            { 
                return NotFound();
            }
            return product;
        }
        [HttpPost]
        public async Task<ActionResult<Productsinfo>> PostProduct(Productsinfo product)
        {

            _dbContext.Productsinfos.Add(product);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct),new { id= product.id},product);
        }
        [HttpPut]
        public async Task<IActionResult>PutProduct(int id,Productsinfo product)
        {
            if(id != product.id)
            {
                return BadRequest();
            }
            _dbContext.Entry(product).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw ;
                }
            }
            return Ok();
        }
        private bool ProductAvailable(int id)
        {
            return (_dbContext.Productsinfos?.Any(x => x.id == id)).GetValueOrDefault();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteProduct(int id)
        {
            if(_dbContext.Productsinfos == null)
            {
                return NotFound();
            }
            var product = await _dbContext.Productsinfos.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            _dbContext.Productsinfos.Remove(product);
            await _dbContext.SaveChangesAsync();
            return Ok(); 
        }

    }
}
                                                                        