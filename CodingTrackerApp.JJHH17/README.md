### Coding Tracking Application - Unit Tests

A command line based code tracking application - allows the user to enter time studied, which is then stored to a local instance of SQLite.
This project follows the "Unit Testing" project of the CSharpAcademy, found on: https://www.thecsharpacademy.com/project/21/unit-testing.

## Technologies used and installed

- SQLite database.
- Dapper (for integrating with SQLite).
- Spectre console (for terminal styling).
- Microsoft.VisualStudio.TestTools.UnitTesting - For unit testing.

## Installation and Running Steps:
- This project uses SQLite, meaning a local instance needs to exist in order to store data.
- The project (program.cs) file contains a method that creates the database if it doesn't already exist, meaning you don't need to create this manually.
- Furthermore, it will also create the relevant SQL table needed for storing events.

## Application Details

- The application can be started by cloning the directory and running the program.cs file.
- You're then presented with a list of options - use the arrow keys to navigate via the terminal options:

<img width="164" height="120" alt="image" src="https://github.com/user-attachments/assets/ea0f5ca5-69c0-46bd-9e05-39e4d441d597" />
  
- The user can add entries via the "Add Event" option, which takes in the start and end date and time:

<img width="482" height="66" alt="image" src="https://github.com/user-attachments/assets/1b726f9f-68b6-4118-ab9a-b9cc855714a1" />

- View a full list of coding events added.

<img width="659" height="140" alt="image" src="https://github.com/user-attachments/assets/f82a3b2f-2349-4c36-9d9c-6c94ed97995c" />

- Delete a single event (by the unique event ID)

<img width="653" height="157" alt="image" src="https://github.com/user-attachments/assets/491e1112-19d0-4b34-8e08-c41caccbd87d" />

- Delete all events on the database.

<img width="434" height="40" alt="image" src="https://github.com/user-attachments/assets/c5970159-37b7-46d9-861a-0b7342257891" />

## Unit Tests
- This project contains a suite of unit tests, which can be found under the "CodingTrackerApp.JJHH17.Tests" directory.
- To run the tests, cd to the test directory via terminal and run ```dotnet test```.
- This command will execute all tests in the testing class.
