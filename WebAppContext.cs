using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Data
{
    public class WebAppContext : DbContext
    {
        public WebAppContext(DbContextOptions<WebAppContext> options)
            : base(options)
        {
        }

        public DbSet<WebApp.Models.Alerte> Alerte { get; set; } = default!;
        public DbSet<WebApp.Models.Utilisateur> Utilisateur { get; set; } = default!;
    }
}