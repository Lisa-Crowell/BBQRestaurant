using BBQ.Services.ProductAPI.Models.Dto;

namespace BBQ.Services.ProductAPI.Repository;

public interface IProductRepository
{
    Task<IEnumerable<ProductDto>> GetProducts();

    Task<ProductDto> GetProductById(int productId);

    // method to create or update a product  (ProductModel)
    Task<ProductDto> CreateUpdateProduct(ProductDto productDto);

    // method to delete product using bool value
    Task<bool> DeleteProduct(int productId);
}