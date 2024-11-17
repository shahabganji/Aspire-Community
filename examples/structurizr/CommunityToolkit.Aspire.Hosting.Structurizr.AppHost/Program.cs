IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

builder.AddStructurizr("structurizr", httpPort: 9090);

builder.Build().Run();