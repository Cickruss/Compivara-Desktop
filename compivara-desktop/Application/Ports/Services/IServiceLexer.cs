using compivara_desktop.Application.Models;

namespace compivara_desktop.Application.Ports.Services;

public interface IServiceLexer
{
    List<Token> ScanTokens();
    void AddSourceCode(string source);

}