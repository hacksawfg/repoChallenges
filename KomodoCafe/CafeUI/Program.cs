using System;

namespace CafeUI
{
    class Program
    {
        
        // Interface
        static void Main(string[] args)
        {
            KomodoUI ui = new KomodoUI();
            ui.Run();
        }
    }
}

// Tasks
// DONE - Create a class for menu items with properties, constructors, and fields
// DONE - Create a class for the repository that houses the methods
// Create a test class with coverage for repository functionality
// DONE - Create a program that allows the cafe manager to [X] Add [X] Delete [X] See all items in the list

// Version 2.0 notes
// Validate ALL numerical inputs
// Develop better logic to verify unique ID's without displaying list
// Filter based on vegetarian options
// More attractive console (is there a way to highlight a particular field, i.e. MealName?)
