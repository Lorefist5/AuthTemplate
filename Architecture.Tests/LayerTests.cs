using AuthTemplate.Domain.Entities;
using NetArchTest.Rules;
using System.Reflection;
using FluentAssertions;

namespace Architecture.Tests;

public class LayerTests
{
    private readonly Assembly _domainAssembly = typeof(User).Assembly;
    private readonly Assembly _applicationAssembly = typeof(AuthTemplate.Application.DependencyInjection).Assembly;
    private readonly Assembly _infrastructureAssembly = typeof(AuthTemplate.Infrastructure.DependencyInjection).Assembly;

    [Fact]
    public void Domain_Should_Not_Depend_On_Application_Or_Infrastructure()
    {
        var noReferenceToApplicationResult = Types.InAssembly(_domainAssembly)
            .That()
            .ResideInNamespace("AuthTemplate.Domain")
            .ShouldNot()
            .HaveDependencyOn("AuthTemplate.Application")
            .GetResult();
        var noReferenceToInfrastructureResult = Types.InAssembly(_domainAssembly)
            .That()
            .ResideInNamespace("AuthTemplate.Domain")
            .ShouldNot()
            .HaveDependencyOn("AuthTemplate.Infrastructure")
            .GetResult();

        noReferenceToApplicationResult.IsSuccessful.Should().BeTrue();
        noReferenceToInfrastructureResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Application_Should_Not_Depend_On_Infrastructure()
    {
        var result = Types.InAssembly(_applicationAssembly)
            .That()
            .ResideInNamespace("AuthTemplate.Application")
            .ShouldNot()
            .HaveDependencyOn("AuthTemplate.Infrastructure")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Infrastructure_Should_Not_Depend_On_Domain_Or_Application()
    {
        var result = Types.InAssembly(_infrastructureAssembly)
            .That()
            .ResideInNamespace("AuthTemplate.Infrastructure")
            .ShouldNot()
            .HaveDependencyOn("AuthTemplate.Domain")
            .And()
            .HaveDependencyOn("AuthTemplate.Application")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}