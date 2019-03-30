using System;
using System.Linq;

namespace MarsRoverKata.UseCases
{
    public class DoCommands
    {
        private ILocationGateway _locationGateway;

        public DoCommands(ILocationGateway locationGateway)
        {
            _locationGateway = locationGateway;
        }

        public void Execute(Array commands)
        {
            var location =_locationGateway.Retrieve().First();
            if (commands.Length == 0)
            {
                _locationGateway.Save(location);
            }
        }
    }
 
}