using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assignment3_WebAPI.Models {
public class Interest {
    public Interest(string interestType, string interestDescription)
    {
        Type = interestType;
        Description = interestDescription;
    }

    public Interest()
    {
        Type = "";
        Description = "";
    }

    [Key]
    public int Id { get; set; }
    [Required]
    [JsonPropertyName("type")]
    public string Type { get; set; }
    [Required]
    [JsonPropertyName("description")]
    public string Description { get; set; }

    public override string ToString()
    {
        return Type + ": " + Description;
    }
}
}