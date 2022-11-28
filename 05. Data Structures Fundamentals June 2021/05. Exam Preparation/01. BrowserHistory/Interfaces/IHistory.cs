namespace _01._BrowserHistory.Interfaces
{
    using System.Collections.Generic;

    public interface IHistory
    {
        int Size { get;  }

        void Open(ILink link);

        bool Contains(ILink link);

        ILink GetByUrl(string url);

        ILink LastVisited();

        ILink DeleteFirst();

        ILink DeleteLast();

        int RemoveLinks(string url);

        void Clear();

        ILink[] ToArray();

        List<ILink> ToList();

        string ViewHistory();
    }
}
