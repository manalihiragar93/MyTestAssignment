using Newtonsoft.Json.Linq;
using WebApplication1.Models;

namespace WebApplication1
{
    public class ArticleService
    {
        private readonly HttpClient _httpClient;
        private readonly AppDbContext _db;

        public ArticleService(HttpClient httpClient, AppDbContext db)
        {
            _httpClient = httpClient;
            _db = db;
        }

        public async Task<List<Article>> FetchAndSaveArticles(string apiKey)
        {
            var url = $"https://api.nytimes.com/svc/topstories/v2/home.json?api-key={apiKey}";
            var response = await _httpClient.GetStringAsync(url);
            var json = JObject.Parse(response);

            var articles = json["results"]!.Select(item => new Article
            {
                Section = item.Value<string>("section"),
                Subsection = item.Value<string>("subsection"),
                Title = item.Value<string>("title"),
                Abstract = item.Value<string>("abstract"),
                Url = item.Value<string>("url"),
                Uri = item.Value<string>("uri"),
                Byline = item.Value<string>("byline"),
                Item_Type = item.Value<string>("item_type"),
                Updated_Date = item.Value<string>("updated_date"),
                Created_Date = item.Value<string>("created_date"),
                Published_Date = item.Value<string>("published_date"),
                Material_Type_Facet = item.Value<string>("material_type_facet"),
                Kicker = item.Value<string>("kicker"),
               
                Multimedia = item["multimedia"]?.ToObject<List<Multimedia>>() ?? new List<Multimedia>(),
                Short_Url = item.Value<string>("short_url")
            }).ToList();

            // remove existing articles
            _db.Articles.RemoveRange(_db.Articles);
            await _db.SaveChangesAsync();
            //add new articles
            _db.Articles.AddRange(articles);
            await _db.SaveChangesAsync();
            return articles;
        }

        public List<Article> GetAllArticles() => _db.Articles.ToList();

    }
}
