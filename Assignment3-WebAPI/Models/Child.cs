using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assignment3_WebAPI.Models {
public class Child : Person {
    public Child()
    {
        Interests = new Collection<Interest>();
        Pets = new Collection<Pet>();
    }
    
    [Key]
    public int Id { get; set; }
    [Required]
    [JsonPropertyName("interests")]
    public ICollection<Interest> Interests { get; set; }
    [Required]
    [JsonPropertyName("pets")]
    public ICollection<Pet> Pets { get; set; }
}
}