using Microsoft.AspNetCore.Mvc;
using ProdutosApi.Models;
using System.Collections.Immutable;

namespace ProdutosApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private static List<Produto> products = new List<Produto>();

    [HttpGet("/")]
    public IActionResult ListProducts() => Ok(products.OrderBy(p => p.Id));

    [HttpGet("/{id}")]
    public IActionResult GetProduct(int id) => Ok(products.FirstOrDefault(p => p.Id == id));

    [HttpPost("/")]
    public IActionResult InsertProduct(Produto product)
    {
        products.Add(product);

        return Ok(product);   
    }

    [HttpPut("/")]
    public IActionResult UpdateProduct(Produto product)
    {
        var findProduct = products.FirstOrDefault(p => p.Id == product.Id);

        products.Remove(findProduct);

        products.Add(product);

        return Ok(product);
    }

    [HttpDelete("/{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);

        products.Remove(product);

        return Ok("Produto removido com sucesso!");
    }

}
