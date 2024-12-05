using compivara_desktop.Application.Ports.Services;
using compivara_desktop.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace compivara_desktop;

static class Program
{
    [STAThread]
    static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IServiceLexer, ServiceLexer>()
            .AddSingleton<IServiceParser, ServiceParser>()
            .AddSingleton<IServiceVariables, ServiceVariables>()
            .AddSingleton<IServiceCompiler, ServiceCompiler>()
            .AddScoped<IDEForm>()
            .BuildServiceProvider();
        
        
        ApplicationConfiguration.Initialize();
        System.Windows.Forms.Application.Run(serviceProvider.GetRequiredService<IDEForm>());
    }
}