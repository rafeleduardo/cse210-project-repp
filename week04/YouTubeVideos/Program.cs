namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Video> videos = new List<Video>();
            
            Video video1 = new Video("Learn C# in 15 minutes", "ProgrammingExpert", 900);
            video1.AddComment(new Comment("Maria", "Great tutorial!"));
            video1.AddComment(new Comment("John", "Very clear and concise"));
            video1.AddComment(new Comment("Peter", "This helped me a lot"));

            Video video2 = new Video("Paella Recipe - Spanish Cuisine", "SpanishChef", 720);
            video2.AddComment(new Comment("Anna", "Best recipe I've seen"));
            video2.AddComment(new Comment("Charles", "Can you make more Spanish recipes?"));
            video2.AddComment(new Comment("Laura", "I made this and it was amazing"));

            Video video3 = new Video("Guitar Tutorial for Beginners", "EasyMusic", 1200);
            video3.AddComment(new Comment("Michael", "Finally I understand how to play"));
            video3.AddComment(new Comment("Sophie", "Very well explained"));
            video3.AddComment(new Comment("David", "Will you make more tutorials?"));
            video3.AddComment(new Comment("Helen", "Loved this class"));


            Video video4 = new Video("Travel Vlog: Japan Adventure", "Wanderlust", 1500);
            video4.AddComment(new Comment("Sergio", "¡Qué viaje tan increíble!"));
            video4.AddComment(new Comment("Lucía", "Me encantaría visitar Japón algún día"));
            video4.AddComment(new Comment("Carlos", "Muy buenas tomas y edición"));
            video4.AddComment(new Comment("Elena", "Gracias por compartir tu experiencia"));
            
            videos.Add(video1);
            videos.Add(video2);
            videos.Add(video3);
            videos.Add(video4);
            
            foreach (var video in videos)
            {
                Console.WriteLine("\n=== Video Information ===");
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
                Console.WriteLine($"Number of comments: {video.GetCommentCount()}");

                Console.WriteLine("\nComments:");
                foreach (var comment in video.GetComments())
                {
                    Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
                }
                Console.WriteLine("==========================");
            }
        }
    }
}