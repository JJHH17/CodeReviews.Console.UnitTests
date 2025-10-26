using Spectre.Console;
using CodingTrackerApp.JJHH17;
using CodingTrackerApp.JJHH17.Models;

namespace CodingTrackerApp.JJHH17;

public class UserInterface
{
    enum MenuOptions
    {
        AddEvent,
        ViewAllEvents,
        DeleteAll,
        DeleteSingleEvent,
        Exit
    }

    public static void Running()
    {
        bool active = true;

        while (active)
        {
            Console.Clear();

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOptions>()
                    .Title("Select an option:")
                    .AddChoices(Enum.GetValues<MenuOptions>()));

            switch (choice)
            {
                case MenuOptions.AddEvent:
                    AnsiConsole.MarkupLine("[green]Add Event selected.[/]");
                    AddEntry();
                    break;

                case MenuOptions.ViewAllEvents:
                    AnsiConsole.MarkupLine("[green]View All Events selected.[/]");
                    ViewAllEntries();
                    break;

                case MenuOptions.DeleteAll:
                    AnsiConsole.MarkupLine("[green]Delete All selected.[/]");
                    DeleteAllEntries();
                    break;

                case MenuOptions.DeleteSingleEvent:
                    AnsiConsole.MarkupLine("[green]Delete Single Event selected.[/]");
                    DeleteSingleEntry();
                    break;

                case MenuOptions.Exit:
                    active = false;
                    break;
            }
        }
    }

    public static void AddEntry()
    {
        string startTime = AnsiConsole.Ask<string>("Enter start time (YYYY-MM-DD HH:MM) (Time is optional):");

        DateTime parsedStartTime;
        while (!DateTime.TryParse(startTime, out parsedStartTime))
        {
            AnsiConsole.MarkupLine("[red]Invalid date format. Please try again.[/]");
            startTime = AnsiConsole.Ask<string>("Enter start time (YYYY-MM-DD HH:MM):");
        }

        string endTime = AnsiConsole.Ask<string>("Enter end time (YYYY-MM-DD HH:MM) (Time is optional)");

        DateTime parsedEndTime;
        while (!DateTime.TryParse(endTime, out parsedEndTime) || parsedEndTime <= parsedStartTime)
        {
            AnsiConsole.MarkupLine("[red]Invalid date format or end time is before start time. Please try again.[/]");
            endTime = AnsiConsole.Ask<string>("Enter end time (YYYY-MM-DD HH:MM):");
        }

        AnsiConsole.MarkupLine("[green]Entry added successfully! Enter a key to continue[/]");
        Console.ReadKey();
        var newEntry = new CodingSession(startTime, endTime);
        newEntry.CalculateDuration();
        Database.Database.AddEntry(newEntry.StartTime, newEntry.EndTime, newEntry.Duration);
    }

    public static void ViewAllEntries()
    {
        var table = new Table();
        table.AddColumn("ID");
        table.AddColumn("Start Time");
        table.AddColumn("End Time");
        table.AddColumn("Duration");

        List<CodingSession> entries = Database.Database.GetAllEntries();
        foreach (var entry in entries)
        {
            table.AddRow(entry.Id.ToString(), entry.StartTime, entry.EndTime, entry.Duration);
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("[green]Press any key to continue...[/]");
        Console.ReadKey();
    }

    public static void DeleteAllEntries()
    {
        string confirmation = AnsiConsole.Ask<string>("Are you sure you want to delete all entries? (yes/no):");
        if (confirmation.ToLower() == "yes")
        {
            Database.Database.DeleteAllEntries();
            AnsiConsole.MarkupLine("[green]All entries deleted successfully! Press any key to continue...[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[yellow]Deletion cancelled. Press any key to continue...[/]");
        }

        Console.ReadKey();
    }

    public static void DeleteSingleEntry()
    {
        ViewAllEntries();
        int idToDelete = AnsiConsole.Ask<int>("Enter the ID of the entry to delete:");
        AnsiConsole.MarkupLine($"[red]Are you sure you want to delete entry ID {idToDelete}[/]");
        string confirmation = AnsiConsole.Ask<string>("Type 'yes' to confirm deletion:");

        if (confirmation.ToLower() == "yes")
        {
            Database.Database.DeleteEntryById(idToDelete);
            AnsiConsole.MarkupLine("[green]Entry deleted successfully! Press any key to continue...[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[yellow]Deletion cancelled. Press any key to continue...[/]");
        }

        Console.ReadKey();
    }
}