using System;
using System.Collections.Generic;
using System.Web.Http;
using DateIntervalsWebApi.Controllers.Models;
using DateIntervalsWebApi.Interfaces;
using DateIntervalsWebApi.Models;

namespace DateIntervalsWebApi.Controllers
{
    public class DateIntervalsController : ApiController
    {
        private readonly IDateIntervalsRepository _repository;
        public DateIntervalsController(IDateIntervalsRepository repository)
        {
            _repository = repository;
        }
        public string Get()
        {
            return "date type 01-01-2000";
        }
        [HttpPost]
        public List<DateInterval> GetIntervals([FromBody]DateIntervalsRequest getRequest)
        {
            if (getRequest != null)
            {
                return _repository.Get(new DateInterval
                {
                    Id = Guid.NewGuid(),
                    StartDate = DateTime.Parse(getRequest.StartDate),
                    EndDate = DateTime.Parse(getRequest.EndDate)
                });
            }
            return null;
        }

        [HttpPost]
        public void Save([FromBody]DateIntervalsRequest saveRequest)
        {
            if (saveRequest != null)
            {
                _repository.Save(new DateInterval
                {
                    Id = Guid.NewGuid(),
                    StartDate = DateTime.Parse(saveRequest.StartDate),
                    EndDate = DateTime.Parse(saveRequest.EndDate)
                });
            }

        }
    }
}
