using compivara_desktop.Application.Models;

namespace compivara_desktop.Application.Ports.Services;

public interface IServiceParser
{
    void Parse();
    void AddTokens(List<Token> tokens);
}