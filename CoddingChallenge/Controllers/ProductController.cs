using AutoMapper;
using CoddingChallenge.DTOs;
using CoddingChallenge.Entities;
using CoddingChallenge.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoddingChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper _mapper;
        private readonly IConfiguration configuration;
        private readonly ILogger<ProductController> logger;

        public ProductController(IProductService userService, IMapper mapper, IConfiguration configuration, ILogger<ProductController> logger)
        {
            this.productService = productService;
            _mapper = mapper;
            this.configuration = configuration;
            this.logger = logger;

        }
        [HttpGet, Route("GetAllProducts")]
        [Authorize(Roles ="Admin")]
        public IActionResult GetAll()
        {
            try
            {
                List<Product> products = productService.GetAllProducts();
                List<ProductDTO> productDTO = _mapper.Map<List<ProductDTO>>(products);
                return StatusCode(200, productDTO);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost, Route("AddProduct")]
        [Authorize(Roles ="Supplier")]
        public IActionResult AddProduct([FromBody] ProductDTO productDTO)
        {
            try
            {

                Product product = _mapper.Map<Product>(productDTO);
                productService.AddProduct(product);

                return StatusCode(200, product);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("GetProductById/{productId}")]
        [Authorize]
        public IActionResult GetProductById(int productId)
        {
            try
            {
                Product product = productService.GetProductById(productId);

                ProductDTO productDTO = _mapper.Map<ProductDTO>(product);
                return StatusCode(200, productDTO);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut, Route("EditProduct")]
        [Authorize(Roles = "supplier")]
        public IActionResult Edit(ProductDTO productDTO)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDTO);
                productService.UpdateProduct(product);
                return StatusCode(200, product);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete, Route("DeleteProduct/{productId}")]
        [Authorize]

        public IActionResult Delete(int productId)
        {
            try
            {
                productService.DeleteProduct(productId);
                return StatusCode(200, new JsonResult($"Product with Id {productId} is Deleted"));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
