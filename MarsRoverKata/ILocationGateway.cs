using System.Collections.Generic;
using MarsRover.Tests.AcceptanceTests;
using MarsRoverKata.Domain;
using MarsRoverKata.UseCases;

namespace MarsRoverKata
{
    public interface ILocationGateway: ILocationWriter, ILocationReader
    {

    }
}