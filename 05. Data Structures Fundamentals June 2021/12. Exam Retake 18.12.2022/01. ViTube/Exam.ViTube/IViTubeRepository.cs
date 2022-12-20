using System;
using System.Collections.Generic;

namespace Exam.ViTube
{
    public interface IViTubeRepository
    {
        void RegisterUser(User user);

        void PostVideo(Video video);

        bool Contains(User user);

        bool Contains(Video video);

        IEnumerable<Video> GetVideos();

        void WatchVideo(User user, Video video);

        void LikeVideo(User user, Video video);

        void DislikeVideo(User user, Video video);

        IEnumerable<User> GetPassiveUsers();

        IEnumerable<Video> GetVideosOrderedByViewsThenByLikesThenByDislikes();

        IEnumerable<User> GetUsersByActivityThenByName();
    }
}
