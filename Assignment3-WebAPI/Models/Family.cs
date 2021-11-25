using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assignment3_WebAPI.Models {
public class Family {
    
    [Key]
    public int Id { get; set; }
    [Required]
    [JsonPropertyName("streetname")]
    public string StreetName { get; set; }
    [Required]
    [JsonPropertyName("housenumber")]
    public int HouseNumber{ get; set; }
    [Required]
    [JsonPropertyName("adults")]
    public ICollection<Adult> Adults { get; set; }
    [Required]
    [JsonPropertyName("children")]
    public ICollection<Child> Children{ get; set; }
    [Required]
    [JsonPropertyName("pets")]
    public ICollection<Pet> Pets{ get; set; }

    public Family() {
        Adults = new Collection<Adult>();
        Children = new Collection<Child>();
        Pets = new Collection<Pet>();
    }
}


}