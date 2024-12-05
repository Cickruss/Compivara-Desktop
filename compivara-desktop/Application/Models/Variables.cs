using compivara_desktop.Application.Enums;

namespace compivara_desktop.Application.Models;

public record Variables
{
    public string Name { get; set; }
    public DataType Type { get; set; }
    public object Value { get; set; }
};