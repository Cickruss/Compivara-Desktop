using compivara_desktop.Application.Models;

namespace compivara_desktop.Application.Ports.Services;

public interface IServiceCompiler
{
    CompilationResult Compile(string sourceCode);
}