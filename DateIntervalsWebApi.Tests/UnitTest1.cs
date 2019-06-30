using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using DateIntervalsWebApi.Controllers;
using DateIntervalsWebApi.DataContexts;
using DateIntervalsWebApi.Models;
using DateIntervalsWebApi.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DateIntervalsWebApi.Tests
{
    [TestClass]
    public class DateIntervalsRepositoryTest
    {
        [TestMethod]
        public void Get_IfInputNull_returnNull()
        {
            var dateInterval = new DateInterval
            {
                StartDate = DateTime.Parse("01-01-2019"),
                EndDate = DateTime.Parse("10-09-2019")
            };


            var valueServiceMock = new Mock<DateIntervalsDbContext>();
            valueServiceMock.Setup(service => service.DateIntervals.Add(dateInterval))
                .Returns(dateInterval);

            var controller = new DateIntervalsRepository(valueServiceMock.Object);
            var values = controller.Get(new DateInterval());
            Guid id = new Guid();

            Assert.IsInstanceOfType(values,id.GetType());

        }

       
    }
}
