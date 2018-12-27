using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NermeenVidly.Models
{
    public class ApplicationDbContext :DbContext
    {

        DbSet<Customer> customersDBSet { get; set; }
        public DbSet<Movie> MoviesDBSet { get; set; }

    }
}