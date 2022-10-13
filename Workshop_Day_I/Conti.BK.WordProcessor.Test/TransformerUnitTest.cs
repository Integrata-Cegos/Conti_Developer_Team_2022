using NUnit.Framework;
using Conti.BK.WordProcessor.Content;
using FluentAssertions;
using System;
namespace Conti.BK.WordProcessor.Test;

public class TransformerTests
{
    IContentTransformer toUpperTransformer = new ToUpperContentTransformer();
    IContentTransformer toLowerTransformer = new ToLowerContentTransformer();
    IContentTransformer removeWhitespaceTransformer = new RemoveWhitespaceContentTransformer();
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestToUpperCaseSuccess()
    {
        var res = toUpperTransformer.Transform("tTest test t");
        res.Should().NotBeNull();
        res.Should().Be("TTEST TEST T");
    }
    [Test]
    public void TestToLowerCaseSuccess()
    {
        var res = toLowerTransformer.Transform("TtEST TEST T");
        res.Should().NotBeNull();
        res.Should().Be("ttest test t");
    }
    [Test]
    public void TestRemoveWhitespaceSuccess()
    {
        var res = removeWhitespaceTransformer.Transform("Test test  TEST \n ttt \t ggg \r jjj Test ");
        res.Should().NotBeNull();
        res.Should().Be("TesttestTESTtttgggjjjTest");
    }

}