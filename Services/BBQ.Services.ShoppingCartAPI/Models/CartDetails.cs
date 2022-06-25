using System.ComponentModel.DataAnnotations.Schema;

namespace BBQ.Services.ShoppingCartAPI.Models;

public class CartDetails
{
    public int CartDetailsId { get; set; }
    public int CartHeaderId { get; set; }
    [ForeignKey(nameof(CartHeaderId))] // use nameof(Property) instead of "propertyName"
    public virtual CartHeader CartHeader { get; set; }
    public int ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; }
    public int Count { get; set; }
}