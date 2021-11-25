using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Library.Models
{
    public class Book
    
    {
        [Key]
        [Required]
        [Range(1000000, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1000000}")]
        [JsonPropertyName("ISBN")]
        private int _isbn;
        
        [Required]
        [JsonPropertyName("title")]
        private string _title;

        [Required]
        [JsonPropertyName("totalPages")]
        private int _totalPages;

        [Required]
        [JsonPropertyName("publishDate")]
        private DateTime _publishDate;

        [Required]
        [JsonPropertyName("genre")]
        private Genre _genre;

        [Required]
        [JsonPropertyName("author")]
        private Author _author;

        public Book()
        {
            
        }

        public Book(int isbn, string title, int totalPages, DateTime publish, Genre genre,Author author)
        {
            _isbn = isbn;
            _title = title;
            _totalPages = totalPages;
            _publishDate = publish;
            _genre = genre;
        }
    }
}
