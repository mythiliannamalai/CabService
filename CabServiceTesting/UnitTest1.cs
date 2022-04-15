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
        //UC-1
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
        //UC-2 && UC-3
        [Test]
        public void GivenListOfRide()
        {
            Ride ride1=new Ride(2, 2);
            Ride ride2=new Ride(2, 1);
            List<Ride> rides=new List<Ride>();
            rides.Add(ride1);
            rides.Add(ride2);
            Assert.AreEqual(43.0d,invoiceGeneration.MultiRide(rides));
            Assert.AreEqual(21.5d, invoiceGeneration.averagePerRide);
            Assert.AreEqual(2, invoiceGeneration.numofRides);
        }
        //TC-2.1 && TC-3.1
        [Test]
        public void GivenListOfRide_InvalidDistance_ThrowException()
        {
            Ride ride3=new Ride(-2, 2);
            Ride ride4=new Ride(-2, 1);
            List<Ride> rides = new List<Ride>();
            rides.Add(ride3);
            rides.Add(ride4);
            CabException cabException = Assert.Throws<CabException>(() => invoiceGeneration.MultiRide(rides));
            Assert.AreEqual(cabException.type,CabException.ExceptionType.Invalid_Distance);            
        }
        [Test]
        //TC-2.2 && TC-3.2
        public void GivenListOfRide_InvalidTime_ThrowException()
        {
            Ride ride5 = new Ride(2, -2);
            Ride ride6 = new Ride(2, -1);
            List<Ride> rides = new List<Ride>();
            rides.Add(ride5);
            rides.Add(ride6);
            CabException cabException = Assert.Throws<CabException>(() => invoiceGeneration.MultiRide(rides));
            Assert.AreEqual(cabException.type, CabException.ExceptionType.Invalid_Time);
        }
    }
}