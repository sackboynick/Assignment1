using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assignment3_WebAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        [Required]
        [JsonPropertyName("domain")]
        public string Domain { get; set; }
        [Required]
        [JsonPropertyName("city")]
        public string City { get; set; }
        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [Required]
        [JsonPropertyName("birthyear")]
        public int BirthYear { get; set; }
        [Required]
        [JsonPropertyName("role")]
        public string Role { get; set; }
        [Required]
        [JsonPropertyName("securitylevel")]
        public int SecurityLevel { get; set; }
    }
}