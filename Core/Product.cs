using System.ComponentModel.DataAnnotations;

namespace Core;

public class Product
{
    public long Id { get; set; }
    public string Name { get; set; } = "";
}