namespace Exam.ViTube
{
    public class Video
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public double Length { get; set; }

        public int Views { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public Video(string id, string title, double length, int views, int likes, int dislikes)
        {
            Id = id;
            Title = title;
            Length = length;
            Views = views;
            Likes = likes;
            Dislikes = dislikes;
        }
    }
}
