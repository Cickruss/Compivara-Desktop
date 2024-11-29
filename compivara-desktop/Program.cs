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
            .AddScoped<IServiceLexer, ServiceLexer>()
            .AddScoped<IServiceParser, ServiceParser>()
            .AddScoped<IServiceSemantic, ServiceSemantic>()
            .AddScoped<IServiceCompiler, ServiceCompiler>()
            .AddScoped<IDEForm>()
            .BuildServiceProvider();
        
        
        ApplicationConfiguration.Initialize();
        System.Windows.Forms.Application.Run(serviceProvider.GetRequiredService<IDEForm>());
    }
}