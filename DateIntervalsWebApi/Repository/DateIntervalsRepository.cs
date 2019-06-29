using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using DateIntervalsWebApi.DataContexts;
using DateIntervalsWebApi.Interfaces;
using DateIntervalsWebApi.Models;

namespace DateIntervalsWebApi.Repository
{
    public class DateIntervalsRepository : IDateIntervalsRepository
    {
        private readonly DateIntervalsDbContext _dbContext;

        public DateIntervalsRepository(DateIntervalsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<DateInterval> Get(DateInterval dateInterval)
        {
           return _dbContext.DateIntervals.Where(x=>x.EndDate <= dateInterval.EndDate 
                                                     && x.EndDate > dateInterval.StartDate).ToList();
        }

        public void Save(DateInterval dateInterval)
        {
            if (dateInterval != null)
            {
                _dbContext.DateIntervals.Add(dateInterval);
                _dbContext.SaveChanges();
            }
        }
    }
}