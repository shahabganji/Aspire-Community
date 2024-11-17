using Aspire.Hosting;
using FluentAssertions;

namespace CommunityToolkit.Aspire.Hosting.Structurizr.Tests;

public class ResourceCreationTests
{
    [Fact]
    public void DefaultStructurizrApp()
    {
        var builder = DistributedApplication.CreateBuilder();

        builder.AddStructurizr("structurizr", 9090, Environment.CurrentDirectory);

        using var app = builder.Build();

        var appModel = app.Services.GetRequiredService<DistributedApplicationModel>();

        var resource = appModel.Resources.OfType<StructurizrResource>().SingleOrDefault();

        Assert.NotNull(resource);
        
        resource.Annotations.OfType<EndpointAnnotation>().Should().NotBeNullOrEmpty();
        resource.Annotations.OfType<EndpointAnnotation>().Single().Port.Should().Be(9090);

        resource.Annotations.OfType<ContainerMountAnnotation>().Should().NotBeNullOrEmpty();
        resource.Annotations.OfType<ContainerMountAnnotation>().Single().Source.Should()
            .Be(Environment.CurrentDirectory);
    }
}