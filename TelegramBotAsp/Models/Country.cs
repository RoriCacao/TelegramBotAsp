using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TelegramBotAsp.Models
{
    public class Country
    {
        [JsonPropertyName("country_id")]
        [Column("ID")]
        public string country_id { get; set; }

        [JsonPropertyName("probability")]
        [Column("Probability")]
        public double probability { get; set; }

        public int PersonId { get; set; }

        public Person? Person { get; set; }

        //  public Person Person { get; set; }

        [JsonConstructor]
        public Country(string Country_id, double Probability)
        {
            country_id = Country_id;
            probability = Probability;
        }

        //public Country(string Country_id, double Probability, int personid)
        //{
        //    country_id = Country_id;
        //    probability = Probability;
        //    PersonID = personid;
        //}
    }
}
