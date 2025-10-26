namespace CodingTrackerApp.JJHH17.Models;

public class CodingSession
{
    public long Id { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string Duration { get; set; }

    public DateTime? stopwatchStartTime;
    public DateTime? stopwatchEndTime;

    public CodingSession()
    {
    }

    public CodingSession(string startTime, string endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
        CalculateDuration();
    }

    public CodingSession(string startTime, string endTime, string duration)
    {
        StartTime = startTime;
        EndTime = endTime;
        Duration = duration;
    }

    public void CalculateDuration()
    {
        DateTime start = DateTime.Parse(StartTime);
        DateTime end = DateTime.Parse(EndTime);

        int years = end.Year - start.Year;
        int months = end.Month - start.Month;
        int days = end.Day - start.Day;

        if (days < 0)
        {
            months--;
            var previousMonth = end.AddMonths(-1);
            days += DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month);
        }

        if (months < 0)
        {
            years--;
            months += 12;
        }

        TimeSpan timespan = end - start;

        int totalDays = (int)timespan.TotalDays;
        int totalHours = (int)timespan.TotalHours % 24;
        int totalMinutes = (int)timespan.TotalMinutes % 60;
        int totalSeconds = (int)timespan.TotalSeconds % 60;

        Duration = $"{years} years, {months} months, {days} days, {totalHours} hours, {totalMinutes} minutes, {totalSeconds} seconds";
    }

    public void StartStopwatch()
    {
        stopwatchStartTime = DateTime.Now;
        Console.WriteLine("Stopwatch started at: " + stopwatchStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
    }

    public void StopStopwatch()
    {
        if (stopwatchStartTime == null)
        {
            Console.WriteLine("Stopwatch has not been started.");
            return;
        }

        stopwatchEndTime = DateTime.Now;
        Console.WriteLine($"Stopwatch stopped at {stopwatchEndTime}");

        StartTime = stopwatchStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
        EndTime = stopwatchEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");

        CalculateDuration();

        stopwatchStartTime = null;
        stopwatchEndTime = null;
    }
}