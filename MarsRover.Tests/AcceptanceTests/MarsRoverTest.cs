using System;
using System.Collections.Generic;
using MarsRoverKata;
using MarsRoverKata.Domain;
using MarsRoverKata.UseCases;
using NUnit.Framework;

namespace MarsRover.Tests.AcceptanceTests
{
    public class MarsRoverTest
    {
        private DoCommands _doCommands;
        private InMemoryLocationGateway _locationGateway;
        private BroadcastLocation _broadcastLocation;


        [SetUp]
        public void SetUp()
        {
            _locationGateway = new InMemoryLocationGateway();
            _doCommands = new DoCommands(_locationGateway);
            _broadcastLocation = new BroadcastLocation(_locationGateway);
        }

        [Test]
        public void InitialStartingPossitionDoesntChange_WhenItRecievedNoCommands()
        {
            
            string[] commands = new string[0];
            Location location = new Location();
            
            List<int> coordinates = new List<int> { 0, 0};
            location.Coordinates = coordinates;
            location.Direction = "North";
            
            _locationGateway.Save(location);
            
            _doCommands.Execute(commands);
            var response = _broadcastLocation.Execute();
            
            Assert.That(response, Is.EqualTo(location));
            Assert.That(_locationGateway.Retrieve().Count, Is.EqualTo(2));
        }
    }

    public class InMemoryLocationGateway : ILocationGateway
    {
        private List<Location> _locations = new List<Location>();
        public void Save(Location location) => _locations.Add(location);
        public List<Location> Retrieve() => _locations;
    }
}

    

  