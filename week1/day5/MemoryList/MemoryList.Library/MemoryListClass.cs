using System;
using System.Collections.Generic;

namespace MemoryList.Library
{
    /// <summary>
    /// List that retains history of contents
    /// </summary>
    public class MemoryListClass : List<string>
    {

        // Dynamic, updated list
        private List<string> list = new List<string>();
        // History of the list
        private List<string> history = new List<string>();

        // Adds a string to the list
        public void AddToList(string item)
        {
            list.Add(item);

            // Check if item is already in history, add if not

            if (!(this.IsInHistory(item)))
            {
                history.Add(item);
            }


        }

        // Removes a string from the list
        public new void Remove(string item)
        {
            list.Remove(item);
        }

        // Displays the dynamic/updated list
        public void DisplayList()
        {
            foreach (string item in list)
                Console.WriteLine(item);
        }

        // Displays history of list
        public void DisplayHistory()
        {
            foreach (string item in history)
                Console.WriteLine(item);
        }

        // Returns whether an item has existed in the list's history
        public bool IsInHistory(string item)
        {
            return history.Contains(item);
        }



    }
}
