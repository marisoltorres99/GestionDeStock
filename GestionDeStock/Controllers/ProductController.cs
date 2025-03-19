using GestionDeStock.DTOs;
using GestionDeStock.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ICommonService<ProductDTO, ProductInsertDTO, ProductUpdateDTO> _productService;

        public ProductController(
            [FromKeyedServices("productService")] ICommonService<ProductDTO, ProductInsertDTO, ProductUpdateDTO> productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> Get() =>
            await _productService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            var productDTO = await _productService.GetById(id);

            return productDTO == null ? NotFound() : Ok(productDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Add(ProductInsertDTO productInsertDTO)
        {
            var productDTO = await _productService.Add(productInsertDTO);

            return CreatedAtAction(nameof(GetById), new { id = productDTO.Id }, productDTO);
        }
    }
}
