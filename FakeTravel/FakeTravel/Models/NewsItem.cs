using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeTravel.Models
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Headline { get; set; }
        public string Subhead { get; set; }
        public string DateLine { get; set; }
        public string Image { get; set; }
    }

    public class NewsManager
    {
        public static void GetNews(string category, ObservableCollection<NewsItem> newsItems)
        {
            var allItems = getNewsItems();
            var filteredNewsItems = allItems.Where(p => p.Category == category).ToList();
            newsItems.Clear();
            filteredNewsItems.ForEach(p => newsItems.Add(p));
        }

        private static List<NewsItem> getNewsItems()
        {
            var items = new List<NewsItem>();

            items.Add(new NewsItem() { Id = 1, Category = "Europe", Headline = "Czech Republic", Subhead = "Prague is a perfect destination for beach-weary vacationers. You can explore Prague Castle and the Old Town Square.", DateLine = "Visit anytime of the year", Image = "Assets/czech_republic_thumb.jpg" });
            items.Add(new NewsItem() { Id = 2, Category = "Europe", Headline = "Italy", Subhead = "Rome is full of historic sites. Toss a coin into the Trevi Fountain, contemplate the Colosseum and the Pantheon.", DateLine = "Visit anytime of the year", Image = "Assets/italy_thumb.jpg" });
            items.Add(new NewsItem() { Id = 3, Category = "Europe", Headline = "Spain", Subhead = "In Barcelona, stepping into Gaudí’s Church of the Sacred Family is a bit like falling through the looking glass.", DateLine = "Visit anytime of the year", Image = "Assets/spain_thumb.jpg" });
            items.Add(new NewsItem() { Id = 4, Category = "Europe", Headline = "United Kingdom", Subhead = "The crown jewels, Buckingham Palace, Camden Market…in London, history collides with art, fashion, food, and good British ale.", DateLine = "Visit during summer or winter", Image = "Assets/uk_thumb.jpg" });

            items.Add(new NewsItem() { Id = 5, Category = "Other", Headline = "Australia", Subhead = "The marvelous Sydney Opera House looks like a great origami sailboat.", DateLine = "Visit during winter", Image = "Assets/australia_thumb.jpg" });
            items.Add(new NewsItem() { Id = 6, Category = "Other", Headline = "Japan", Subhead = "Tradition collides with pop culture in Tokyo, where you can reverently wander ancient temples before rocking out at a karaoke bar.", DateLine = "Visit during summer", Image = "Assets/japan_thumb.jpg" });
            items.Add(new NewsItem() { Id = 7, Category = "Other", Headline = "Turkey", Subhead = "The mosques, bazaars, and Turkish baths of Istanbul could keep you happily occupied for your entire trip.", DateLine = "Visit during winter", Image = "Assets/turkey_thumb.jpg" });
            items.Add(new NewsItem() { Id = 8, Category = "Other", Headline = "USA", Subhead = "Hit the must-sees – the Empire State Building, the Statue of Liberty, Central Park, the Metropolitan Museum of Art.", DateLine = "Visit anytime of the year", Image = "Assets/usa_thumb.jpg" });

            return items;
        }
    }
}
