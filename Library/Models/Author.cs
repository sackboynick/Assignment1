using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Library.Models
{
    public class Author
    {
        
        [Key]
        [Required] 
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        [JsonPropertyName("id")]
        private int _authorId;
        
        [Required]
        [JsonPropertyName("firstName")]
        private string _firstName;

        [Required]
        [JsonPropertyName("lastName")]
        private string _lastName;

        [Required]
        [JsonPropertyName("bio")]
        private string _bio;

        public Author(int authorId, string firstName, string lastName, string bio)
        {
            this._authorId = authorId;
            this._firstName = firstName;
            this._lastName = lastName;
            this._bio = bio;
        }
    }
}