using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TelegramBotAsp.Models
{
    public class Test
    {
        [Column("ID")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public Test(int ID, string Nm, string Desc)
        //{
        //    Id = ID;
        //    Name = Nm;
        //    Description = Desc;
        //}

    }
}
