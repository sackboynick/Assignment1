using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assignment3_WebAPI.Models {
public class Pet {
    public Pet(int petsCount, string petName, int petAge, string petSpecie)
    {
        Id = petsCount;
        Name = petName;
        Age = petAge;
        Species = petSpecie;
    }

    public Pet()
    {
        Id=-1;
        Species = "";
        Name = "";
        Age = 0;
    }

    [Key]
    public int Id { get; set; }
    [Required]
    [JsonPropertyName("species")]
    public string Species { get; set; }
    [Required]
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [Required]
    [JsonPropertyName("age")]
    public int Age { get; set; }

    public override string ToString()
    {
        return Name + ", a " + Species;
    }
}
}