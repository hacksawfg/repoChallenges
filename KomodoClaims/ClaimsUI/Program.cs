using System;
using ClaimsLibrary;
using ClaimsUI;

namespace ClaimsUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ClaimsInterface ui = new ClaimsInterface();
            ui.Run();
        }
    }
}

// To-do list
// [] set up repository
    // [X] Create
    // [X] Read
    // [X] Update
    // [X] Delete
// [X] set up claim class
    // [X] Logic for valid claim
// [] set up test class for repo methods
// [] manage list of claims
    // [X] set up menu
    // [X] display formatting
    // [X] recommend claim number
        // [X] create list of already used claimID's & use max + 1
// [] Repository Testing
