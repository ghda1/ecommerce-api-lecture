using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("/api/products")]

public class ProductController : ControllerBase
{

  private readonly IProductService _productService;

  public ProductController(IProductService productService)
  {
    _productService = productService;
  }

  // //? GET => /api/products => Get all the products
  [HttpGet]
  public IActionResult GetProducts()
  {
    var products = _productService.GetProductsService();
    return Ok(products);
  }

  // //? GET => /api/products/{id} => Get a single product by Id
  [HttpGet("{id:guid}")]
  public IActionResult GetProductById(Guid id)
  {
    var product = _productService.GetProductByIdService(id);
    if (product == null)
    {
      return NotFound($"Product with this {id} does not exist");
    }
    return Ok(product);
  }


  // //? Delete => /api/products/{id} => delete a single product by Id
  [HttpDelete("{id}")]
  public IActionResult DeleteProductById(Guid id)
  {
    var result = _productService.DeleteProductByIdService(id);
    if (!result)
    {
      return NotFound($"Product with this {id} does not exist");
    }
    return NoContent();
  }

  [HttpPost]
  public IActionResult CreateProduct(CreateProductDto newProduct)
  {
    // checking validation before create the new product
    if (!ProductValidation.isValidName(newProduct.Name))
    {
      return BadRequest("Name can not be empty");
    }
    if (!ProductValidation.isValidPrice(newProduct.Price))
    {
      return BadRequest("Price can not be negative");
    }
    var product = _productService.CreateProductService(newProduct);
    return Created($"/api/products/{product.Id}", product);
  }

  [HttpPut("{id}")]
  public IActionResult UpdateProduct(Guid id, UpdateProductDto updateProduct)
  {
    // found the product then check the validation before update the product
    var foundUpdatedProduct = _productService.GetProductByIdService(id);

    if (foundUpdatedProduct == null)
    {
      return NotFound($"Product with {id} not found");
    }

    if (updateProduct.Name != null)
    {

      if (!ProductValidation.isValidName(updateProduct.Name)) // "test"
      {
        return BadRequest("Name can not be empty");
      }
    }

    if (!ProductValidation.isValidPrice(updateProduct.Price))
    {
      return BadRequest("Price can not be negative");
    }
    foundUpdatedProduct = _productService.UpdateProductService(id, updateProduct);

    return Ok(foundUpdatedProduct);
  }

}