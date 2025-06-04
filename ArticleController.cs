using Microsoft.AspNetCore.Mvc;

namespace WebApplication1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleService articleService;

        public ArticleController(ArticleService nytService)
        {
            articleService = nytService;
        }

        public class ApiRequest
        {
            public string ApiKey { get; set; }
        }


        [HttpGet("ping")]
        public IActionResult Ping() => Ok("API is alive!");


        [HttpPost("load")]
        public async Task<IActionResult> LoadData([FromBody] ApiRequest request)
        {
            var apiKey = request.ApiKey;
            if (string.IsNullOrEmpty(apiKey)) return BadRequest("API Key is required.");
            var articles = await articleService.FetchAndSaveArticles(apiKey);
            return Ok(articles);
        }
    }
}
