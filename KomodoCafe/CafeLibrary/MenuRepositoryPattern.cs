using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeLibrary
{
    // Create, Read, Delete
    public class MenuRepository
    {
        private readonly List<MenuItem> _menu = new List<MenuItem>();


        // Add items to the menu
        public bool AddMenuItem(MenuItem item)
        {
            int startingCount = _menu.Count;
            _menu.Add(item);

            return _menu.Count > startingCount;
        }

        // See all items in the menu
        public List<MenuItem> GetCafeMenu()
        {
            return _menu;
        }

        // Remove items from the menu
        public bool DeleteMenuItem(MenuItem existingMenuItem)
        {
            return _menu.Remove(existingMenuItem);
        }


    }
}