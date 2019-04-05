using System;
using System.Linq;
using MarsRoverKata.Boundary;
using MarsRoverKata.Domain;

namespace MarsRoverKata.UseCases
{
    public class DoCommands
    {
        private ILocationGateway _locationGateway;

        public DoCommands(ILocationGateway locationGateway)
        {
            _locationGateway = locationGateway;
        }

        public DoCommandsResponse Execute(Array commands)
        {
            var location = _locationGateway.Retrieve().First();
            foreach (var command in commands)
            {
                if (command == "f")
                {
                    location.Coordinates[1] += 1;
                }
            }

            _locationGateway.Save(location);

            return new DoCommandsResponse()
            {
                LocationSaved = true
            };
        }
    }
    public interface ILocationWriter
    {
        void Save(Location location);
    }
}