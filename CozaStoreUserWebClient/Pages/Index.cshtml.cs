using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;
using System.Text.Json;

namespace CozaStoreUserWebClient.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private List<Product> productslist { get; set; }
    private readonly HttpClient client = null;
    private string ApiUri = "";
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        client = new HttpClient();
        var contentType = new MediaTypeWithQualityHeaderValue("application/json");
        client.DefaultRequestHeaders.Accept.Add(contentType);
        ApiUri = "http://localhost:5000";
    }

    //public async Task<IActionResult> OnGet()
    //{
    //    HttpResponseMessage response = await client.GetAsync(ApiUri + "/api/Product");
    //    string strData = await response.Content.ReadAsStringAsync();

    //    var option = new JsonSerializerOptions
    //    {
    //        PropertyNameCaseInsensitive = true,
    //    };
    //    productslist = JsonSerializer.Deserialize<List<Product>>(strData, option);

    //    return Page();
    //}

    public void Onget()
    {

    }

    public void OnPost()
    {

    }
}

