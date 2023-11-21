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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService OrderService;

        private readonly IMapper _mapper;
        private readonly ILogger<OrderController> logger;



        public OrderController(IOrderService orderService, IMapper mapper, ILogger<OrderController> logger)
        {
            OrderService = orderService;
            _mapper = mapper;
            this.logger = logger;


        }
        [HttpGet, Route("GetOrders")]
        public IActionResult GetAll()
        {
            try
            {
                List<Order> orders = OrderService.GetOrders();
                List<OrderDTO> orderDTO = _mapper.Map<List<OrderDTO>>(orders);
                return StatusCode(200, orderDTO);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("GetOrdersByProductId")]
        [HttpGet, Route("GetOrderByProductId/{ProductId}")]
        [Authorize(Roles = "Admin")]

        public IActionResult Get(int ProductId)
        {
            try
            {
                Order order = OrderService.GetOrdersByProductId(ProductId);
                OrderDTO categoryDTO = _mapper.Map<OrderDTO>(order);
                if (order != null)
                    return StatusCode(200, categoryDTO);
                else
                    return StatusCode(404, new JsonResult("Invalid Id"));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost, Route("PlaceOrder")]
        [Authorize(Roles = "user")]
        public IActionResult Add([FromBody] OrderDTO orderDTO)
        {
            try
            {
                Order order = _mapper.Map<Order>(orderDTO);
                OrderService.PlaceOrder(order);
                return StatusCode(200, order);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

    }
}
