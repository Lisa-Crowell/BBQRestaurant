using BBQ.MessageBus;
using BBQ.Services.ShoppingCartAPI.Messages;
using BBQ.Services.ShoppingCartAPI.Models.Dto;
using BBQ.Services.ShoppingCartAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BBQ.Services.ShoppingCartAPI.Controllers;

[ApiController]
[Route("api/cart")]
public class CartAPIController : Controller
{
    private readonly ICartRepository _cartRepository;

    private readonly IMessageBus _messageBus;
    // private readonly ICouponRepository _couponRepository;
    protected ResponseDto _response;

    public CartAPIController(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;

        _response = new ResponseDto();
    }

    [HttpGet("GetCart/{userId}")]
    public async Task<object> GetCart(string userId)
    {
        try
        {
            var cartDto = await _cartRepository.GetCartByUserId(userId);
            _response.Result = cartDto;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> {ex.ToString()};
        }

        return _response;
    }

    [HttpPost("AddCart")]
    public async Task<object> AddCart(CartDto cartDto)
    {
        try
        {
            var cartDt = await _cartRepository.CreateUpdateCart(cartDto);
            _response.Result = cartDt;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> {ex.ToString()};
        }

        return _response;
    }

    [HttpPost("UpdateCart")]
    public async Task<object> UpdateCart(CartDto cartDto)
    {
        try
        {
            var cartDt = await _cartRepository.CreateUpdateCart(cartDto);
            _response.Result = cartDt;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> {ex.ToString()};
        }

        return _response;
    }

    [HttpPost("RemoveCart")]
    public async Task<object> RemoveCart([FromBody] int cartId)
    {
        try
        {
            var isSuccess = await _cartRepository.RemoveFromCart(cartId);
            _response.Result = isSuccess;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> {ex.ToString()};
        }

        return _response;
    }

    [HttpPost("ApplyCoupon")]
    public async Task<object> ApplyCoupon([FromBody] CartDto cartDto)
    {
        try
        {
            var isSuccess = await _cartRepository.ApplyCoupon(cartDto.CartHeader.UserId,
                cartDto.CartHeader.CouponCode);
            _response.Result = isSuccess;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> {ex.ToString()};
        }

        return _response;
    }

    [HttpPost("RemoveCoupon")]
    public async Task<object> RemoveCoupon([FromBody] string userId)
    {
        try
        {
            var isSuccess = await _cartRepository.RemoveCoupon(userId);
            _response.Result = isSuccess;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> {ex.ToString()};
        }

        return _response;
    }
    
    [HttpPost("Checkout")]
    public async Task<object> Checkout(CheckoutHeaderDto checkoutHeader)
    {
        try
        {
            CartDto cartDto = await _cartRepository.GetCartByUserId(checkoutHeader.UserId);
            if (cartDto == null)
            {
                return BadRequest();
            }

            checkoutHeader.CartDetails = cartDto.CartDetails;
          
            await _messageBus.PublishMessage(checkoutHeader, "checkoutmessagetopic");
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> {ex.ToString()};
        }

        return _response;
    }
}
