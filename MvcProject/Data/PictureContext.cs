using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MvcProject.Models;

namespace MvcProject.Data
{
    public class PictureContext : DbContext
    {
        public PictureContext() : base("DefaultConnection")
        {
        }

        public DbSet<Picture> Pictures { get; set; }
    }
}