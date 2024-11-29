namespace compivara_desktop.Application.Models;

public record CompilationResult
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public List<Token>? Tokens { get; set; }
}