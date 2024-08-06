using AuthTemplate.Domain.Entities;
using FluentAssertions;
using NetArchTest.Rules;
using System.Reflection;
using Xunit;

namespace Architecture.Tests.Global;

public class ArchitectureTests
{
    private readonly Assembly _infrastructureAssembly = typeof(AuthTemplate.Infrastructure.DependencyInjection).Assembly;
    private readonly Assembly _domainAssembly = typeof(User).Assembly;
    private readonly Assembly _applicationAssembly = typeof(AuthTemplate.Application.DependencyInjection).Assembly;
    //List of assemblies

    private List<Assembly> _assemblies => new()
    {
        _infrastructureAssembly, _domainAssembly, _applicationAssembly
    };

    [Fact]
    public void Interfaces_Should_HaveIPrefix()
    {
        
        var result = Types.InAssemblies(_assemblies)
            .That()
            .AreInterfaces()
            .And()
            .DoNotHaveNameStartingWith("I")
            .Should()
            .HaveNameStartingWith("I")
            .GetResult();


        result.IsSuccessful.Should().BeTrue();
    }
}
