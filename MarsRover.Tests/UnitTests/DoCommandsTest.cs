using System;
using System.Collections.Generic;
using FluentAssertions;
using MarsRoverKata;
using MarsRoverKata.Boundary;
using MarsRoverKata.Domain;
using MarsRoverKata.UseCases;
using NUnit.Framework;

namespace MarsRover.Tests.UnitTests
{
    public class DoCommandsTest
    {
  
        
        [Test]
        public void CanMoveForwardsOneUnit()
        {

            Location location = new Location();
            location.Coordinates = new List<int>{0, 0};
            location.Direction = "North";
            
            var commands = new string[1] {"f"};
            
            var locationGatewaySpy = new LocationGatewayFake();

            locationGatewaySpy._locations.Add(location);
            
            var doCommand = new DoCommands(locationGatewaySpy);
            
            doCommand.Execute(commands);
            
            locationGatewaySpy._hasBeenCalled.Should().BeTrue();
            
            var expectedLocation = new Location
            {
                Coordinates = new List<int> {0, 1},
                Direction = "North"
            };
            
            locationGatewaySpy._savedLocation.Should().BeEquivalentTo(expectedLocation);
        }

        [Test]
        public void Execute_ReturnsDoCommandsResponse()
        {
            Location location = new Location();
            location.Coordinates = new List<int>{0, 0};
            location.Direction = "North";
            
            var commands = new string[1] {"f"};
            
            var locationGatewaySpy = new LocationGatewayFake();

            locationGatewaySpy._locations.Add(location);
            
            var doCommand = new DoCommands(locationGatewaySpy);
            
            var response = doCommand.Execute(commands);

            var expectedResponse = new DoCommandsResponse()
            {
                LocationSaved = true
            };
            
            response.Should().BeEquivalentTo(expectedResponse);
        }

        [Test]
        public void CanMoveForwardsTwoUnitsAndBackwardOneUnit()
        {
            Location location = new Location();
            location.Coordinates = new List<int>{0, 0};
            location.Direction = "North";
            
            var commands = new string[4] {"f", "f", "f", "b"};
            
            var locationGatewaySpy = new LocationGatewayFake();

            locationGatewaySpy._locations.Add(location);
            
            var doCommand = new DoCommands(locationGatewaySpy);
            
            doCommand.Execute(commands);
            
            var response = doCommand.Execute(commands);
            
            locationGatewaySpy._hasBeenCalled.Should().BeTrue();
            
            var expectedLocation = new Location
            {
                Coordinates = new List<int> {0, 2},
                Direction = "North"
            };
            
            locationGatewaySpy._savedLocation.Should().BeEquivalentTo(expectedLocation);
        
        }
    }

    public class LocationGatewayFake : ILocationGateway
    {
        public bool _hasBeenCalled = false;
        public Location _savedLocation;
        public List<Location> _locations = new List<Location>();
        
        
        public void Save(Location location)
        {
            _savedLocation = location;
            _hasBeenCalled = true;
            _locations.Add(location);
        }
        
        public List<Location> Retrieve()
        {
            return _locations;
        }
    }
  
}