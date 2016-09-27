using System;
using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arrange
            var context = new VidzyContext();

            // Action movies sorted by name
            Console.WriteLine("-- Action movies sorted by name");

            var actionMovies = context.Videos
                .Where(v => v.Genre.Name == "Action")
                .OrderBy(v => v.Name).ToList();

            foreach (var movie in actionMovies)
                Console.WriteLine(movie.Name);

            // Gold drama movies sorted by release date (newest first)
            Console.WriteLine("\n\n-- Gold drama movies sorted by release date (newest first)");

            var goldDramaMovies = context.Videos
                .Where(v => v.Classification == Classification.Gold && v.Genre.Name == "Drama")
                .OrderBy(v => v.ReleaseDate);

            foreach (var movie in goldDramaMovies)
                Console.WriteLine(movie.Name);

            // All movies projected into an anonymous type with two properties: MovieName and Genre
            Console.WriteLine("\n\n-- All movies projected into an anonymous type with two properties: MovieName and Genre");

            var movieNameAndGenreList = context.Videos.Select(v => new { MovieName = v.Name, Genre = v.Genre.Name });

            foreach (var item in movieNameAndGenreList)
                Console.WriteLine($"Movie: {item.MovieName} - Genre: {item.Genre}");

            /*
               All movies grouped by their classification: Project the group into a new
               anonymous type with two properties: Classification (string), Movies
               (IEnumerable<Video>). For each group, display the classification and list of
               videos in that class sorted alphabetically. 
             */
            Console.WriteLine("\n\n-- All movies grouped by their classification");

            var videosGroupedByClassification = context.Videos.GroupBy(v => v.Classification,
                v => v,
                (classification, videos) => new {
                    Classification = classification.ToString(),
                    Movies = videos
                });

            foreach (var item in videosGroupedByClassification)
            {
                Console.WriteLine($"Classification: {item.Classification}");
                foreach (var movie in item.Movies)
                    Console.WriteLine($"    {movie.Name}");
            }

            // List of classifications sorted alphabetically and count of videos in them. 
            Console.WriteLine("\n\n-- List of classifications sorted alphabetically and count of videos in them.");

            var classificationsAndVideoCount = context.Videos
                .GroupBy(v => v.Classification,
                    v => v,
                    (classification, videos) => new {
                        Classification = classification.ToString(),
                        Movies = videos.Count()
                    })
                .OrderBy(x => x.Classification);

            foreach (var item in classificationsAndVideoCount)
            {
                Console.WriteLine($"Classification: {item.Classification} - {item.Movies}");
            }

            /*
               List of genres and number of videos they include, sorted by the number of videos. 
               Genres with the highest number of videos come first.
            */
            Console.WriteLine("\n\n-- List of genres and number of videos they include, sorted by the number of videos. Genres with the highest number of videos come first.");

            var videosCountGroupedByGenre = context.Videos
                .GroupBy(
                    g => g.Genre.Name,
                    v => v,
                    (genreName, videos) => new {
                        Genre = genreName,
                        NumberOfVideos = videos.Count()
                    })
                .OrderByDescending(x => x.NumberOfVideos);

            foreach (var item in videosCountGroupedByGenre)
                Console.WriteLine($"Genre: {item.Genre} - {item.NumberOfVideos}");

            Console.ReadLine();
            context.Dispose();
        }
    }
}
