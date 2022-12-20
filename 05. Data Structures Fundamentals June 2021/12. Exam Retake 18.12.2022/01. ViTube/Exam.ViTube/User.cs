using System.Collections.Generic;

namespace Exam.ViTube
{
    public class User
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public User(string id, string username)
        {
            Id = id;
            Username = username;
            Watched = new HashSet<Video>();
            Liked = new HashSet<Video>();
            Disliked = new HashSet<Video>();
        }        

        public ICollection<Video> Watched { get; set; }

        public ICollection<Video> Liked { get; set; }

        public ICollection<Video> Disliked { get; set; }
    }
}
