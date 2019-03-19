using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Web;
using System.Data.Entity;

namespace netCoreMVC.Models
{
    public class SpaceDbContext : DbContext
    {
        public DbSet<Data> spaceFlights {get; set;}

    }
}
