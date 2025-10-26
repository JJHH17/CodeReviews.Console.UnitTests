using Menu = CodingTrackerApp.JJHH17.UserInterface;
using Database = CodingTrackerApp.JJHH17.Database;

namespace CodingTrackerApp.JJHH17;

class Program
{
    public static void Main(string[] args)
    {
        Database.Database.CreateDatabase();
        Menu.Running();
    }
}