using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingTrackerApp.JJHH17.Models;
using System;

namespace CodingTrackerApp.JJHH17.Tests;

[TestClass]
public class AppTests
{
    [TestMethod]
    public void Duration_CalculateDurationCorrectly()
    {
        var start = "2024-01-01 10:00:00";
        var end = "2024-01-01 12:30:45";
        var session = new CodingTrackerApp.JJHH17.Models.CodingSession(start, end);

        Assert.AreEqual("0 years, 0 months, 0 days, 2 hours, 30 minutes, 45 seconds", session.GetDuration());
    }

    [TestMethod]
    public void Duration_InvalidDurationCalculation_PassesIfTestPasses()
    {
        var start = "2024-01-01 10:00:00";
        var end = "2024-01-01 11:00:00";
        var session = new CodingTrackerApp.JJHH17.Models.CodingSession(start, end);

        Assert.AreNotEqual("0 years, 0 months, 0 days, 3 hours, 0 minutes, 0 seconds", session.GetDuration());
    }

    [TestMethod]
    public void Duration_ZeroDuration_PassesIfTestPasses()
    {
        var start = "2024-01-01 10:00:00";
        var end = "2024-01-01 10:00:00";
        var session = new CodingTrackerApp.JJHH17.Models.CodingSession(start, end);
        Assert.AreEqual("0 years, 0 months, 0 days, 0 hours, 0 minutes, 0 seconds", session.GetDuration());
    }

    [TestMethod]
    public void DateInput_ValidDateFormat_PassesIfValidFormat()
    {
        var dateString = "2024-06-15 14:30";
        DateTime parsedDate;
        var isValid = DateTime.TryParse(dateString, out parsedDate);
        Assert.IsTrue(isValid);
    }
}