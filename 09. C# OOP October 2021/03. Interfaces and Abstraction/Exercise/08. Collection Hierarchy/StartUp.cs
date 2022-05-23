using System;
using System.Collections.Generic;

namespace _08.CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            AddCollection add = new AddCollection();
            AddRemoveCollection addRemove = new AddRemoveCollection();
            MyList myList = new MyList();

            List<int> addAddings = new List<int>();
            List<int> addRemoveAddings = new List<int>();
            List<int> myListAddings = new List<int>();

            foreach (var element in inputData)
            {
                addAddings.Add(add.Add(element));
                addRemoveAddings.Add(addRemove.Add(element));
                myListAddings.Add(myList.Add(element));
            }

            int elementsToRemove = int.Parse(Console.ReadLine());

            List<string> addRemoveRemoved = new List<string>();
            List<string> myListRemoved = new List<string>();

            for (int i = 0; i < elementsToRemove; i++)
            {
                addRemoveRemoved.Add(addRemove.Remove());
                myListRemoved.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(' ', addAddings));
            Console.WriteLine(string.Join(' ', addRemoveAddings));
            Console.WriteLine(string.Join(' ', myListAddings));
            Console.WriteLine(string.Join(' ', addRemoveRemoved));
            Console.WriteLine(string.Join(' ', myListRemoved));
        }
    }
}
