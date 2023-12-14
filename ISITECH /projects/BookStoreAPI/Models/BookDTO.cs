using BookStoreAPI.Entities;

namespace BookStoreAPI.Models

{
    public class BookDTO
    {


        // Une prop mets a dispostion des accesseurs (getters et setters)
        // ceci est une property
        public int Id { get; set; }
        public required string Title { get; init; }
        public Auteur? Author { get; set; }
        public Genres? Genres { get; set; }

        public string Abstract { get; set; } = string.Empty;



    }
}