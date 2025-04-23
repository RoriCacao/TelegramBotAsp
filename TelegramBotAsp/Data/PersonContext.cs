using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;
using TelegramBotAsp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TelegramBotAsp.Context
{
    class PersonContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-J7SMN7O;Initial Catalog=master;Integrated Security=True;Encrypt=False");//(@"Server=(localdb)\DESKTOP-J7SMN7O;Database=master;Trusted_Connection=True;");
        }

        //public PersonContext()
        //{
        //   // Database.EnsureDeleted();
        //    Database.EnsureCreated();
        //}
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
       // public DbSet<Test> Test { get; set; }

    }
}


