using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateIntervalsWebApi.Models;

namespace DateIntervalsWebApi.Interfaces
{
    public interface IDateIntervalsRepository
    {
        void Save(DateInterval dateInterval);
        List<DateInterval> Get(DateInterval dateInterval);
    }
}
