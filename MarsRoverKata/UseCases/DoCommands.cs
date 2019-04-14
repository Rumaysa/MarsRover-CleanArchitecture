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
                if ((string) command == "f")
                {
                    if (location.Direction == "North")
                    {
                        location.Coordinates[1] += 1;
                    }
                    else if (location.Direction == "East")
                    {
                        location.Coordinates[0] += 1;
                    } 
                    else if (location.Direction == "South")
                    {
                        location.Coordinates[1] -= 1;
                    }
                    else if (location.Direction == "West")
                    {
                        location.Coordinates[0] -= 1;
                    }
                }
                else if ((string) command == "b")
                {
                    if (location.Direction == "North")
                    {
                        location.Coordinates[1] -= 1;
                    }
                    else if (location.Direction == "East")
                    {
                        location.Coordinates[0] -= 1;
                    } 
                    else if (location.Direction == "South")
                    {
                        location.Coordinates[1] += 1;
                    }
                    else if (location.Direction == "West")
                    {
                        location.Coordinates[0] += 1;
                    }
                }
     
                else if ((string) command == "l")
                {
                    if (location.Direction == "North")
                    {
                        location.Direction = "West"; 
                    }
                    else if (location.Direction == "East")
                    {
                        location.Direction = "North";
                    }
                    else if (location.Direction == "South")
                    {
                        location.Direction = "East";
                    }
                }
                
                else if ((string) command == "r")
                {
                    if (location.Direction == "North")
                    {
                        location.Direction = "East"; 
                    }
                    else if (location.Direction == "East")
                    {
                        location.Direction = "South";
                    }
                    else if (location.Direction == "South")
                    {
                        location.Direction = "East";
                    }
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