using CommunityToolkit.Aspire.Testing;
using FluentAssertions;
using Projects;

namespace CommunityToolkit.Aspire.Hosting.Structurizr.Tests;

#pragma warning disable CTASPIRE001
public class AppHostTests(AspireIntegrationTestFixture<CommunityToolkit_Aspire_Hosting_Structurizr_AppHost> fixture)
    : IClassFixture<AspireIntegrationTestFixture<CommunityToolkit_Aspire_Hosting_Structurizr_AppHost>>
{
    [Fact]
    public async Task ResourceStartsAndRespondsOk()
    {
        var appName = "structurizr";
        var httpClient = fixture.CreateHttpClient(appName);

        await fixture.App.WaitForTextAsync("Started StructurizrLite").WaitAsync(TimeSpan.FromSeconds(30));

        var response = await httpClient.GetAsync("/workspace/diagrams");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}