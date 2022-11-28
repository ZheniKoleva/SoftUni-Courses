namespace _01._BrowserHistory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using _01._BrowserHistory.Interfaces;

    public class BrowserHistory : IHistory
    {
        private LinkedList<ILink> links;

        public BrowserHistory()
        {
            links = new LinkedList<ILink>();
        }

        public int Size => links.Count;

        public void Clear() => links.Clear();

        public bool Contains(ILink link) => links.Contains(link);

        public ILink DeleteFirst()
        {
            CheckIfEmpty();

            ILink firstLink = links.Last.Value;
            links.RemoveLast();

            return firstLink;
        }

        public ILink DeleteLast()
        {
            CheckIfEmpty();

            ILink lastLink = links.First.Value;
            links.RemoveFirst();

            return lastLink;
        }

        public ILink GetByUrl(string url)
        {
            var node = this.links.First;

            while (node != null)
            {
                if (node.Value.Url == url)
                {
                    return node.Value;
                }

                node = node.Next;
            }

            return null;
        }

        public ILink LastVisited()
        {
            CheckIfEmpty();

            return links.First.Value;
        }

        public void Open(ILink link) => links.AddFirst(link);

        public int RemoveLinks(string url)
        {
            int removedLinks = 0;
            string searchedUrl = url.ToLower();
            var element = this.links.First;

            while (element != null)
            {
                var nextElement = element.Next;

                if (element.Value.Url.ToLower().Contains(searchedUrl))
                {
                    links.Remove(element);
                    removedLinks++;
                }

                element = nextElement;
            }

            if (removedLinks == 0)
            {
                throw new InvalidOperationException();
            }

            return removedLinks;
        }

        public ILink[] ToArray() => links.ToArray();

        public List<ILink> ToList() => links.ToList();

        public string ViewHistory()
        {
            StringBuilder result = new StringBuilder();

            if (this.Size == 0)
            {
                result.Append("Browser history is empty!");
            }
            else
            {
                foreach (var item in links)
                {
                    result.AppendLine(item.ToString());
                }
            }

            return result.ToString();
        }

        private void CheckIfEmpty()
        {
            if (links.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
