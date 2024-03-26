using Microsoft.EntityFrameworkCore;
using MovieReact.Server.Entities;

namespace MovieReact.Server.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> opt) : base(opt)
        {

        }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Name = "Alien:Romulus",
                    Description = "The sci-fi/horror-thriller takes the phenomenally successful “Alien” franchise back to its roots: While scavenging the deep ends of a derelict space station, a group of young space colonizers come face to face with the most terrifying life form in the universe. ",
                    TrailerLink = "https://www.youtube.com/embed/GTNMt84KT0k?si=abeYQEbwF6WbdJSO"
                },
                new Movie
                {
                    Id = 2,
                    Name = "The Fall Guy",
                    Description = "He’s only the stuntman, but he’s stealing the show.",
                    TrailerLink = "https://www.youtube.com/embed/EySdVK0NK1Y?si=xs39l6fz6Q5yeX8S"
                },
                new Movie
                {
                    Id = 3,
                    Name = "BEETLEJUICE BEETLEJUICE ",
                    Description = "Beetlejuice is back!  Oscar-nominated, singular creative visionary Tim Burton and Oscar nominee and star Michael Keaton reunite for Beetlejuice Beetlejuice, the long-awaited sequel to Burton’s award-winning Beetlejuice.",
                    TrailerLink = "https://www.youtube.com/embed/e6yDanmWI1E?si=RHCDG12ejFVXfv3f"
                }
                );
        }
    }
}
