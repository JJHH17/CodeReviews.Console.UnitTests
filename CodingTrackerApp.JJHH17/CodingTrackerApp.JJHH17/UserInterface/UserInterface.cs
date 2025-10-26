using Spectre.Console;
using CodingTrackerApp.JJHH17;

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
                    break;

                case MenuOptions.DeleteAll:
                    break;

                case MenuOptions.DeleteSingleEvent:
                    break;

                case MenuOptions.Exit:
                    active = false;
                    break;
            }
        }
    }

    public static void AddEntry()
    {
        string startTime = AnsiConsole.Ask<string>("Enter start time (YYYY-MM-DD HH:MM):");

        DateTime parsedStartTime;
        while (!DateTime.TryParse(startTime, out parsedStartTime))
        {
            AnsiConsole.MarkupLine("[red]Invalid date format. Please try again.[/]");
            startTime = AnsiConsole.Ask<string>("Enter start time (YYYY-MM-DD HH:MM):");
        }

        string endTime = AnsiConsole.Ask<string>("Enter end time (YYYY-MM-DD HH:MM)");

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
}