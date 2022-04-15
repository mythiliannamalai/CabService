using NUnit.Framework;
using Cab;
using System;
using System.Collections;
using System.Collections.Generic;
namespace CabServiceTesting
{    
    public class Tests
    {
        InvoiceGeneration invoiceGeneration;
        [SetUp]
        public void Setup()
        {
            invoiceGeneration = new InvoiceGeneration();
        }
        [Test]
        [TestCase(5,7)]
        public void GivenTimeAndDistance_CalculateFare(double distance,double time)
        {
            Ride ride=new Ride(distance,time);
            int expected = 57;
            Assert.AreEqual(expected,invoiceGeneration.SingleRide(ride));
        }
        //TC-1.1
        [Test]
        public void GivenInvalidDistance_ThrowException()
        {
            Ride ride = new Ride(-1, 1);
            CabException cabException=Assert.Throws<CabException>(()=>invoiceGeneration.SingleRide(ride));
            Assert.AreEqual(cabException.type, CabException.ExceptionType.Invalid_Distance);
        }
        //TC-1.2
        [Test]
        public void GivenInvalidTime_ThrowException()
        {
            Ride ride=new Ride(1,-1);
            CabException cabException=Assert.Throws<CabException>(()=>invoiceGeneration.SingleRide(ride));
            Assert.AreEqual(cabException.type,CabException.ExceptionType.Invalid_Time);
        }
    }
}