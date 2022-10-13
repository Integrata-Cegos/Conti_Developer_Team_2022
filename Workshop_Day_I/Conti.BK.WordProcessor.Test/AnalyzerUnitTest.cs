using NUnit.Framework;
using Conti.BK.WordProcessor.Content;
using FluentAssertions;
using System;

namespace Conti.BK.WordProcessor.Test;

public class AnalyzerTests
{
    IContentAnalyzer wordCountAnalyzer = new WordCountContentAnalyzer();
    IContentAnalyzer wordStartsWithAnalyzer = new WordStartsWithContentAnalyzer();
    IContentAnalyzer wordContainsAnalyzer = new WordContainsContentAnalyzer();
    IContentAnalyzer letterCountAnalyzer = new LetterCountContentAnalyzer();
    [SetUp]
    public void Setup()
    {
    }

 
    [TestCase("Ein", 1)]
    [TestCase("Ein Zwei", 2)]
    [TestCase("Ein    Zwei Drei    ", 3)]
    [TestCase("", 0)]
    public void TestWordCountSuccess(string content, int expectedRes)
    {
        string res;
        wordCountAnalyzer.Analyze(content, out res, "");
        res.Should().Be(expectedRes.ToString());
    }

    [TestCase("Ein","E", 1)]
    [TestCase("Ein Zwei", "E", 1)]
    [TestCase("Ein    Zwei Drei    ","e", 2)]
    [TestCase("aaaa aa aaa aa", "e", 0)]
    public void TestWordContainsSuccess(string content, string contains, int expectedRes)
    {
        string res;
        wordContainsAnalyzer.Analyze(content, out res, contains);
        res.Should().Be(expectedRes.ToString());
    }
    [TestCase("Ein","E", 1)]
    [TestCase("Ein eins", "E", 1)]
    [TestCase("Ein    Zwei Drei    E","E", 2)]
    [TestCase("aaaa aa aaa aa", "e", 0)]
    public void TestWordStartsWithSuccess(string content, string contains, int expectedRes)
    {
        string res;
        wordStartsWithAnalyzer.Analyze(content, out res, contains);
        res.Should().Be(expectedRes.ToString());
    }
    [TestCase("Ein", "|Char\t|Count\t| \n|E\t|1\t| \n|i\t|1\t| \n|n\t|1\t|")]
    [TestCase("Ein ei", "|Char\t|Count\t| \n|E\t|1\t| \n|i\t|2\t| \n|n\t|1\t| \n| \t|1\t| \n|e\t|1\t|")]
    [TestCase("", "|Char\t|Count\t|")]
    public void TestLetterCountSuccess(string content, string expectedRes)
    {
        string res;
        letterCountAnalyzer.Analyze(content, out res, "");
        res.Should().Be(expectedRes.ToString());
    }
}