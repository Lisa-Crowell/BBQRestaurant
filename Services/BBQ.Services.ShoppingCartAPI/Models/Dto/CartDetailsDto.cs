using System.ComponentModel.DataAnnotations.Schema;
using BBQ.Services.ShoppingCartAPI.Models;
using BBQ.Services.ShoppingCartAPI.Models.Dto;

namespace ShoppingCartAPI.Models.Dto;

public class CartDetailsDto
{
    public int CartDetailsId { get; set; }
    public int CartHeaderId { get; set; }
    public virtual CartHeaderDto CartHeader { get; set; }
    public int ProductId { get; set; }
    public virtual ProductDto Product { get; set; }
    public int Count { get; set; }
}