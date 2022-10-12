using NUnit.Framework;
using Conti.BK.WordProcessor.Content;
using FluentAssertions;
using System;
using System.IO;
namespace Conti.BK.WordProcessor.Test;

public class ReporterTests
{
    IContentReporter consoleReporter = new ConsoleContentReporter();
    IContentReporter fileReporter = new FileContentReporter("../../../UnitTestResults.txt");
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestConsoleReporterSuccess()
    {
        
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        consoleReporter.Report("Test");
        stringWriter.ToString().Should().StartWith("Test");
    }
    [Test]
    public void TestFileReporterSuccess()
    {
        string text = "test TEST";
        fileReporter = new FileContentReporter("../../../UnitTestResults.txt");
        fileReporter.Report(text);
        string output = File.ReadAllText("../../../UnitTestFileReader.txt");

        
        output.Should().Be(text);
    }
    [Test]
    public void TestFileReporterFail()
    {
        string text = "test TEST";
        fileReporter = new FileContentReporter("../../../UnitTestResults.txt");
        fileReporter.Report(text);
        string output = File.ReadAllText("../../../UnitTestFileReader.txt");

        
        output.Should().NotBe("test");
    }
}