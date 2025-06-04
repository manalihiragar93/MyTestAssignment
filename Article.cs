
namespace WebApplication1.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Section { get; set; }
        public string Subsection { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Url { get; set; }
        public string Uri { get; set; }
        public string Byline { get; set; }
        public string Item_Type { get; set; }
        public string Updated_Date { get; set; }
        public string Created_Date { get; set; }
        public string Published_Date { get; set; }
        public string Material_Type_Facet { get; set; }
        public string Kicker { get; set; }
        public List<Multimedia> Multimedia { get; set; }
        public string Short_Url { get; set; }
    }

    public class Multimedia
    {
        public int MultimediaId { get; set; }
        public string Url { get; set; }
        public string Format { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Type { get; set; }
        public string Subtype { get; set; }
        public string Caption { get; set; }
        public string Copyright { get; set; }
    }

}
