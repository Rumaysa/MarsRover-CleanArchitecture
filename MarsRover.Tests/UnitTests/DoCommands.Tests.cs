using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Common;
using MarsRoverKata;
using MarsRoverKata.Boundary;
using MarsRoverKata.Domain;
using MarsRoverKata.UseCases;
using NUnit.Framework;

namespace MarsRover.Tests.UnitTests
{
    public class DoCommandsTests
    {
        [TestFixture()]
        public class WhenRoverIsFacingNorth
        {
            private Location _location;
            private LocationGatewayFake _locationGatewayFake;
            [SetUp]
            public void SetUp()
            {
                _location = new Location
                {
                    Coordinates = new List<int> {0, 0},
                    Direction = "North"
                };
                _locationGatewayFake = new LocationGatewayFake();
                _locationGatewayFake._locations.Add(_location);
            }
        
            [Test]
            public void CanMoveForwardsOneUnit()
            {
                var commands = new string[1] {"f"};
    
                var doCommand = new DoCommands(_locationGatewayFake);
                
                doCommand.Execute(commands);
                
                _locationGatewayFake._hasBeenCalled.Should().BeTrue();
                
                var expectedLocation = new Location
                {
                    Coordinates = new List<int> {0, 1},
                    Direction = "North"
                };
                
                
                _locationGatewayFake._savedLocation.Coordinates[0].Should().Be(expectedLocation.Coordinates[0]);
                _locationGatewayFake._savedLocation.Coordinates[1].Should().Be(expectedLocation.Coordinates[1]);
                _locationGatewayFake._savedLocation.Direction.Should().Be(expectedLocation.Direction);
            }
    
            [Test]
            public void Execute_ReturnsDoCommandsResponse()
            {
                var commands = new string[1] {"f"};
    
                var doCommand = new DoCommands(_locationGatewayFake);
                
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
                var commands = new string[4] {"f", "f", "f", "b"};
                
                var doCommand = new DoCommands(_locationGatewayFake);
                
                doCommand.Execute(commands);
                            
                _locationGatewayFake._hasBeenCalled.Should().BeTrue();
                
                var expectedLocation = new Location
                {
                    Coordinates = new List<int> {0, 2},
                    Direction = "North"
                };
        
                _locationGatewayFake._savedLocation.Coordinates[0].Should().Be(expectedLocation.Coordinates[0]);
                _locationGatewayFake._savedLocation.Coordinates[1].Should().Be(expectedLocation.Coordinates[1]);
                _locationGatewayFake._savedLocation.Direction.Should().Be(expectedLocation.Direction);
            }
            [Test]
            public void ItCanTurnLeft()
            {
                var commands = new string[1] {"l"};
                var doCommands = new DoCommands(_locationGatewayFake);
                doCommands.Execute(commands);
                var expectedLocation = new Location
                {
                    Coordinates = new List<int> {0, 0},
                    Direction = "West"
                };

                _locationGatewayFake._savedLocation.Coordinates[0].Should().Be(expectedLocation.Coordinates[0]);
                _locationGatewayFake._savedLocation.Coordinates[1].Should().Be(expectedLocation.Coordinates[1]);
                _locationGatewayFake._savedLocation.Direction.Should().Be(expectedLocation.Direction);
            } 
            [Test]
            public void ItCanTurnRight()
            {
                var commands = new string[1] {"r"};
                var doCommands = new DoCommands(_locationGatewayFake);
                doCommands.Execute(commands);
                var expectedLocation = new Location
                {
                    Coordinates = new List<int> {0, 0},
                    Direction = "East"
                };

                _locationGatewayFake._savedLocation.Coordinates[0].Should().Be(expectedLocation.Coordinates[0]);
                _locationGatewayFake._savedLocation.Coordinates[1].Should().Be(expectedLocation.Coordinates[1]);
                _locationGatewayFake._savedLocation.Direction.Should().Be(expectedLocation.Direction);
            }
        }

        [TestFixture()]
        public class WhenFacingEast
        {
            private Location _location;
            private LocationGatewayFake _locationGatewayFake;
            [SetUp]
            public void SetUp()
            {
                _location = new Location
                {
                    Coordinates = new List<int> {0, 0},
                    Direction = "East"
                };
                _locationGatewayFake = new LocationGatewayFake();
                _locationGatewayFake._locations.Add(_location);
            }
            
            [Test]
            public void ItCanMoveForwardOneUnit()
            {
                var commands = new string[1] {"f"};
                var doCommands = new DoCommands(_locationGatewayFake);
                doCommands.Execute(commands);
                var expectedLocation = new Location
                {
                    Coordinates = new List<int> {1, 0},
                    Direction = "East"
                };

                _locationGatewayFake._savedLocation.Coordinates[0].Should().Be(expectedLocation.Coordinates[0]);
                _locationGatewayFake._savedLocation.Coordinates[1].Should().Be(expectedLocation.Coordinates[1]);
                _locationGatewayFake._savedLocation.Direction.Should().Be(expectedLocation.Direction);
            }  
            
            [Test]
            public void ItCanMoveBackwardOneUnit()
            {
                var commands = new string[1] {"b"};
                var doCommands = new DoCommands(_locationGatewayFake);
                doCommands.Execute(commands);
                var expectedLocation = new Location
                {
                    Coordinates = new List<int> {-1, 0},
                    Direction = "East"
                };

                _locationGatewayFake._savedLocation.Coordinates[0].Should().Be(expectedLocation.Coordinates[0]);
                _locationGatewayFake._savedLocation.Coordinates[1].Should().Be(expectedLocation.Coordinates[1]);
                _locationGatewayFake._savedLocation.Direction.Should().Be(expectedLocation.Direction);
            } 
                        
            [Test]
            public void ItCanTurnLeft()
            {
                var commands = new string[1] {"l"};
                var doCommands = new DoCommands(_locationGatewayFake);
                doCommands.Execute(commands);
                var expectedLocation = new Location
                {
                    Coordinates = new List<int> {0, 0},
                    Direction = "North"
                };

                _locationGatewayFake._savedLocation.Coordinates[0].Should().Be(expectedLocation.Coordinates[0]);
                _locationGatewayFake._savedLocation.Coordinates[1].Should().Be(expectedLocation.Coordinates[1]);
                _locationGatewayFake._savedLocation.Direction.Should().Be(expectedLocation.Direction);
            } 
            [Test]
            public void ItCanTurnRight()
            {
                var commands = new string[1] {"r"};
                var doCommands = new DoCommands(_locationGatewayFake);
                doCommands.Execute(commands);
                var expectedLocation = new Location
                {
                    Coordinates = new List<int> {0, 0},
                    Direction = "South"
                };

                _locationGatewayFake._savedLocation.Coordinates[0].Should().Be(expectedLocation.Coordinates[0]);
                _locationGatewayFake._savedLocation.Coordinates[1].Should().Be(expectedLocation.Coordinates[1]);
                _locationGatewayFake._savedLocation.Direction.Should().Be(expectedLocation.Direction);
            }

            [Test]
            public void ItCanMoveAndRotate()
            {
                var commands = new string[6] {"r", "f", "f", "l", "l", "b"};
                var doCommands = new DoCommands(_locationGatewayFake);
                doCommands.Execute(commands);
                var expectedLocation = new Location
                {
                    Coordinates = new List<int> {0, -3},
                    Direction = "North"
                };

                _locationGatewayFake._savedLocation.Coordinates[0].Should().Be(expectedLocation.Coordinates[0]);
                _locationGatewayFake._savedLocation.Coordinates[1].Should().Be(expectedLocation.Coordinates[1]);
                _locationGatewayFake._savedLocation.Direction.Should().Be(expectedLocation.Direction);
            }
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