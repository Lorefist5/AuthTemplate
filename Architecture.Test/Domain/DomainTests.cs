using AuthTemplate.Domain.Entities;
using FluentAssertions;
using NetArchTest.Rules;
using System.Reflection;
using Xunit;

namespace Architecture.Test.Domain;

public class DomainTests
{
    private static readonly Assembly DomainAssembly = typeof(User).Assembly;

    //If you have domain events
    //[Fact]
    //public void DomainEvents_Should_BeSealed()
    //{
    //    var testResult = Types.InAssembly(DomainAssembly)
    //        .That()
    //        .ImplementInterface(typeof(IDomainEvent))
    //        .Should()
    //        .BeSealed()
    //        .GetResult();


    //    testResult.IsSuccessful.Should().BeTrue();
    //}

}
