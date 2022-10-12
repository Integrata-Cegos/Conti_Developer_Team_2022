using NUnit.Framework;
using Conti.BK.WordProcessor.Content;
using FluentAssertions;
using System;
using System.IO;

namespace Conti.BK.WordProcessor.Test;

public class ReaderTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestConsoleReaderSuccess()
    {
        string text = "test TEST";
        var stringReader = new StringReader(text+"\n");
        var stringWriter = new StringWriter();
        Console.SetIn(stringReader);
        Console.SetOut(stringWriter);
        var reader = new ConsoleContentReader();
        string input = reader.Read();
        stringWriter.ToString().Should().StartWith("Enter content:");
        input.Should().Be(text);
    }
    [Test]
    public void TestFileReaderSuccess()
    {
        string text = "test TEST";
        File.WriteAllText("../../../UnitTestFileReader.txt",text);
        var reader = new FileContentReader("../../../UnitTestFileReader.txt");
        string input = reader.Read();
        input.Should().Be(text);
    }
    [Test]
    public void TestFileReaderFail()
    {
        string text = "test TEST";
        File.WriteAllText("../../../UnitTestFileReader.txt",text);
        var reader = new FileContentReader("../../../UnitTestFileReader.txt");
        string input = reader.Read();
        input.Should().NotBe("test");
    }
}