using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace AddressBook;

public class AddressBookWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<AddressBookWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
