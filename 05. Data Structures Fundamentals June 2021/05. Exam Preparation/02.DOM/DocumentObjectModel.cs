namespace _02.DOM
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Linq;
    using _02.DOM.Interfaces;
    using _02.DOM.Models;

    public class DocumentObjectModel : IDocument
    {
        public DocumentObjectModel(IHtmlElement root)
        {
            this.Root = root;
        }

        public DocumentObjectModel()
        {
            var htmlRoot = new HtmlElement(ElementType.Document,
                new HtmlElement(ElementType.Html,
                    new HtmlElement(ElementType.Head), 
                    new HtmlElement(ElementType.Body)
                    )
                );

            this.Root = htmlRoot;
        }

        public IHtmlElement Root { get; private set; }

        public IHtmlElement GetElementByType(ElementType type)
        {
            var root = this.Root;
            var queue = new Queue<IHtmlElement>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var currentElement = queue.Dequeue();

                if (currentElement.Type == type)
                {
                    return currentElement;
                }

                foreach (var child in currentElement.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public List<IHtmlElement> GetElementsByType(ElementType type)
        {
            var result = new List<IHtmlElement>();

            GetElementsByTypeDFS(this.Root, type, result);           

            return result;
        }

        private void GetElementsByTypeDFS(IHtmlElement element, ElementType type, List<IHtmlElement> result)
        {
            foreach (var child in element.Children)
            {
                this.GetElementsByTypeDFS(child, type, result);
            }

            if (element.Type == type)
            {
                result.Add(element);
            }
        }

        public bool Contains(IHtmlElement htmlElement)
        {
            return FindElement(htmlElement) != null;            
        }

        public void InsertFirst(IHtmlElement parent, IHtmlElement child)
        {
            IsElementExists(parent);
            parent.Children.Insert(0, child);
            child.Parent = parent;
        }         

        public void InsertLast(IHtmlElement parent, IHtmlElement child)
        {
            IsElementExists(parent);
            parent.Children.Add(child);
            child.Parent = parent;
        }

        public void Remove(IHtmlElement htmlElement)
        {
            IsElementExists(htmlElement);
            htmlElement.Parent.Children.Remove(htmlElement);
            htmlElement.Parent = null;

            foreach (var child in htmlElement.Children)
            {
                child.Parent = null;
            }

            htmlElement.Children.Clear();
        }

        public void RemoveAll(ElementType elementType)
        {
            var elementsToRemove = GetElementsByType(elementType);

            foreach (var element in elementsToRemove)
            {
                Remove(element);
            }
        }

        public bool AddAttribute(string attrKey, string attrValue, IHtmlElement htmlElement)
        {
            IsElementExists(htmlElement);

            if (htmlElement.Attributes.ContainsKey(attrKey))
            {
                return false;
            }

            htmlElement.Attributes.Add(attrKey, attrValue);

            return true;
        }

        public bool RemoveAttribute(string attrKey, IHtmlElement htmlElement)
        {
            IsElementExists(htmlElement);        

            return htmlElement.Attributes.Remove(attrKey);
        }

        public IHtmlElement GetElementById(string idValue)
        {            
            var queue = new Queue<IHtmlElement>();
            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var currentElement = queue.Dequeue();

                if (currentElement.Attributes.ContainsKey("id") 
                    && currentElement.Attributes["id"] == idValue)
                {
                    return currentElement;
                }

                foreach (var item in currentElement.Children)
                {
                    queue.Enqueue(item);
                }
            }

            return null;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            DfsToString(this.Root, 0, result);

            return result.ToString();
        }

        private void DfsToString(IHtmlElement element, int indent, StringBuilder resultString)
        {
            resultString.AppendLine($"{new string(' ', indent)}{element.Type}");

            foreach (var child in element.Children)
            {
                this.DfsToString(child, indent + 2, resultString);
            }
        }

        private IHtmlElement FindElement(IHtmlElement searchedElement)
        {           
            var queue = new Queue<IHtmlElement>();
            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var currentElement = queue.Dequeue();

                if (currentElement == searchedElement)
                {
                    return currentElement;
                }

                foreach (var item in currentElement.Children)
                {
                    queue.Enqueue(item);
                }
            }

            return null;
        }

        private void IsElementExists(IHtmlElement elementToCheck)
        {
            if (Contains(elementToCheck) == false)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
