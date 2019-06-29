using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using DateIntervalsWebApi.Models;

namespace DateIntervalsWebApi.DataContexts
{
    public class DateIntervalsDbContext: DbContext
    {
        public DbSet<DateInterval> DateIntervals { get; set; }

        public DateIntervalsDbContext() : base("name=IntervalsDBConnectionString")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DateIntervalsDbContext>());
        }
    }
}