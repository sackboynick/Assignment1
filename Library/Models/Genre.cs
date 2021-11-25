using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Library.Models
{
    public class Genre
    {
        [Key]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        [JsonPropertyName("id")]
        private int _genreId;

        [Required]
        [JsonPropertyName("genreName")]
        private string _genreName;


        public Genre(int genreId, string genreName)
        {
            this._genreId = genreId;
            this._genreName = genreName;
        }
    }
}