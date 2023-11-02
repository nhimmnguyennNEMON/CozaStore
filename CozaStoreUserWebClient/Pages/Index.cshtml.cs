using Azure;
using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;
using System.Text.Json;
using DTO;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CozaStoreUserWebClient.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public List<ProductDTO> productslist { get; set; }
    public int productIdTemp { get; set; }
    private readonly HttpClient client = null;
    private string ApiUri = "";
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        client = new HttpClient();
        var contentType = new MediaTypeWithQualityHeaderValue("application/json");
        client.DefaultRequestHeaders.Accept.Add(contentType);
        ApiUri = "http://localhost:5002";
    }

    public async Task<IActionResult> OnGet()
    {
       HttpResponseMessage response = await client.GetAsync(ApiUri + "/api/Product");
       string strData = await response.Content.ReadAsStringAsync();

       var option = new JsonSerializerOptions
       {
           PropertyNameCaseInsensitive = true,
       };
       productslist = JsonSerializer.Deserialize<List<ProductDTO>>(strData, option);
       productIdTemp = 1;

       return Page();
    }

    public IActionResult OnPostUpdateRazorVariable(int newValue)
    {
        productIdTemp = newValue;
        return new JsonResult(productIdTemp);
    }

}

