using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assignment3_WebAPI.Models {
public class Person {
    
    [Key]
    public int Id { get; set; }
    [Required]
    [JsonPropertyName("firstname")]
    public string FirstName { get; set; }
    [Required]
    [JsonPropertyName("lastname")]
    public string LastName { get; set; }
    
    [Required]
    [JsonPropertyName("hairColor")]
    public string HairColor { get; set; }
    [Required]
    [JsonPropertyName("eyecolor")]
    public string EyeColor { get; set; }
    [Required]
    [JsonPropertyName("age")]
    public int Age { get; set; }
    [Required]
    [JsonPropertyName("weight")]
    public float Weight { get; set; }
    [Required]
    [JsonPropertyName("height")]
    public int Height { get; set; }
    [Required]
    [JsonPropertyName("sex")]
    public string Sex { get; set; }


    public Person()
    {
        
    }
}


}