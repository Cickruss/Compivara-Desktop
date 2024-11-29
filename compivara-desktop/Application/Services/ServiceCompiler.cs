using compivara_desktop.Application.Models;
using compivara_desktop.Application.Ports.Services;

namespace compivara_desktop.Application.Services;

public class ServiceCompiler : IServiceCompiler
{
    private readonly IServiceLexer _serviceLexer;
    private readonly IServiceParser _serviceParser;
    private readonly IServiceSemantic _serviceSemantic;

    public ServiceCompiler(IServiceLexer serviceLexer, IServiceParser serviceParser, IServiceSemantic serviceSemantic)
    {
        _serviceLexer = serviceLexer;
        _serviceParser = serviceParser;
        _serviceSemantic = serviceSemantic;
    }
    public CompilationResult Compile(string sourceCode)
    {
        var result = new CompilationResult();
        try 
        {
            _serviceLexer.AddSourceCode(sourceCode);
            var tokens = _serviceLexer.ScanTokens();
            
            _serviceParser.AddTokens(tokens);
            _serviceParser.Parse();

            //var semanticAnalyzer = new SemanticAnalyzer();
            
            
            result.Success = true;
            result.Tokens = tokens;
            result.Message = "Compilação realizada com sucesso!";
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = ex.Message;
        }
        return result;
    }
}