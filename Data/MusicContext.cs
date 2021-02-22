using DT102G_moment3._3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DT102G_moment3._3.Data
{
    public class MusicContext : DbContext
    {
        //constructor
        public MusicContext(DbContextOptions<MusicContext> options) : base(options)
        {

        }

        //Props
        public DbSet<Music> musics { get; set; }
    }
}
