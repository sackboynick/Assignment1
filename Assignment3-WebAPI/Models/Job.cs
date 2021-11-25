using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assignment3_WebAPI.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("jobtitle")]
        public string JobTitle { get; set; }
        [Required]
        [JsonPropertyName("salary")]
        public int Salary { get; set; }
    }
}