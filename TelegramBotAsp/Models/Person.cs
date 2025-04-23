using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TelegramBotAsp.Models
{
    public class Person
    {
        [JsonPropertyName("count")]
        [NotMapped]
        public int? Count { get; set; }

        public int ID { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("country")]
        public List<Country> Country { get; set; } = new();

        //public Person(string name, Country country, int id)
        //{
        //    Name = name;
        //    Country = new List<Country>();
        //    Country.Add(country);
        //    //country = Country;
        //    PersonID = id;

        //}


        [JsonConstructor]
        public Person(List<Country> country)
        //public Person(Country Country)
        {
            Country = country;
        }

    }
}
