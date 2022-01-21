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
    // [] Update
    // [X] Delete
// [X] set up claim class
    // [] Logic for valid claim
// [] set up test class for repo methods
// [] manage list of claims
    // [] set up menu
    // [] display formatting
    // [] recommend claim number
        // create list of already used claimID's & use max + 1
