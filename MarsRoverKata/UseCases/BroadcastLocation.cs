using System;
using System.Linq;
using MarsRoverKata;
using MarsRoverKata.Domain;

namespace MarsRover.Tests.AcceptanceTests
{
    public class BroadcastLocation
    {
        private ILocationGateway _locationGateway;

        public BroadcastLocation(ILocationGateway locationGateway)
        {
            _locationGateway = locationGateway;
        }

        public Location Execute()
        {
            return _locationGateway.Retrieve().First();
        }
    }
}