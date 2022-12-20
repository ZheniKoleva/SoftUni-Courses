using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.ViTube
{
    public class ViTubeRepository : IViTubeRepository
    {
        private readonly Dictionary<string, User> users;
        private readonly Dictionary<string, Video> videos;

        public ViTubeRepository()
        {
            users = new Dictionary<string, User>();
            videos = new Dictionary<string, Video>();
        }

        public bool Contains(User user)
        {
            return users.ContainsKey(user.Id);
        }

        public bool Contains(Video video)
        {
            return videos.ContainsKey(video.Id);    
        }

        public void DislikeVideo(User user, Video video)
        {
            var userWhichDislikes = Contains(user) ? users[user.Id] : null;
            var videoToDislike = Contains(video) ? videos[video.Id] : null;

            if (userWhichDislikes == null || videoToDislike == null)
            {
                throw new ArgumentException();
            }

            userWhichDislikes.Disliked.Add(video);
            videoToDislike.Dislikes++;
        }

        public IEnumerable<User> GetPassiveUsers()
        {
            Predicate<User> isUserPassive = (u)
                => u.Watched.Count == 0 && u.Liked.Count == 0 && u.Disliked.Count == 0;

            return users.Values
                .Where(u => isUserPassive(u) == true);
        }

        public IEnumerable<User> GetUsersByActivityThenByName()
        {
            return users.Values
                .OrderByDescending(u => u.Watched.Count)
                .ThenByDescending(u => u.Liked.Count)
                .ThenByDescending(u => u.Disliked.Count)
                .ThenBy(u => u.Username);
        }

        public IEnumerable<Video> GetVideos()
        {
            return videos.Values;
        }

        public IEnumerable<Video> GetVideosOrderedByViewsThenByLikesThenByDislikes()
        {
            return videos.Values
                .OrderByDescending(v => v.Views)
                .ThenByDescending(v => v.Likes)
                .ThenBy(v => v.Dislikes);
        }

        public void LikeVideo(User user, Video video)
        {
            var userWhichLikes = Contains(user) ? users[user.Id] : null;
            var videoToLike = Contains(video) ? videos[video.Id] : null;

            if (userWhichLikes == null || videoToLike == null)
            {
                throw new ArgumentException();
            }

            userWhichLikes.Liked.Add(video);
            videoToLike.Likes++;
        }

        public void PostVideo(Video video)
        {
            if (!Contains(video))
            {
                videos.Add(video.Id, video);
            }
        }

        public void RegisterUser(User user)
        {
            if (!Contains(user))
            {
                users.Add(user.Id, user);
            }
        }

        public void WatchVideo(User user, Video video)
        {
            var userWhichWatch = Contains(user) ? users[user.Id] : null;
            var videoToWatch = Contains(video) ? videos[video.Id] : null;

            if (userWhichWatch == null || videoToWatch == null)
            {
                throw new ArgumentException();
            }

            userWhichWatch.Watched.Add(video);
            videoToWatch.Views++;
        }
    }
}
