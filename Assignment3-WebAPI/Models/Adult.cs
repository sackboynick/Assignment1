using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assignment3_WebAPI.Models {
public class Adult : Person {
    [Required]
    [JsonPropertyName("jobtitle")]
    public Job JobTitle { get; set; }
}
}