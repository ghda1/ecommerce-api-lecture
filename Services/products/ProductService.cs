using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IProductService
{
    List<ProductDto> GetProductsService();
    Product CreateProductService(CreateProductDto createProduct);
    bool DeleteProductByIdService(Guid id);
    ProductDto? GetProductByIdService(Guid id);
    ProductDto? UpdateProductService(Guid id, UpdateProductDto updateProduct);

}
public class ProductService : IProductService
{
    private static List<Product> _products = new List<Product>();

    public List<ProductDto> GetProductsService()
    {
        // retrun the product as list of ProductDto
        var products = _products.Select(product => new ProductDto
        {
            Name = product.Name,
            Price = product.Price,
            Description = product.Description
        }).ToList();

        return products;
    }

    public Product CreateProductService(CreateProductDto createProduct)
    {
        //Create new product 
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = createProduct.Name,
            Price = createProduct.Price,
            Description = createProduct.Description,
            CreatedAt = DateTime.Now,
        };
        _products.Add(product);
        return product;
    }

    public bool DeleteProductByIdService(Guid id)
    {
        // Find the product by id and delete it from the list
        var product = _products.FirstOrDefault(product => product.Id == id);

        if (product == null)
        {
            return false;
        }

        _products.Remove(product);
        return true;
    }


    public ProductDto? GetProductByIdService(Guid id)
    {
        // find the product and return it as ProductDto
        var product = _products.FirstOrDefault(product => product.Id == id);

        if (product == null)
        {
            return null;
        }

        var productData = new ProductDto
        {
            Name = product.Name,
            Price = product.Price,
            Description = product.Description
        };

        return productData;

    }

    public ProductDto? UpdateProductService(Guid id, UpdateProductDto updateProduct)
    {
        // Find the product
        var product = _products.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            return null;
        }
        // Update the product 
        product.Name = updateProduct.Name ?? product.Name;
        product.Price = updateProduct.Price ?? product.Price;
        product.Description = updateProduct.Description ?? product.Description;

        // return the product as ProductDto
        var productData = new ProductDto
        {
            Name = product.Name,
            Price = product.Price,
            Description = product.Description
        };

        return productData;
    }
}
