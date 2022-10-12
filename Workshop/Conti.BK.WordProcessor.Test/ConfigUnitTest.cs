using NUnit.Framework;
using Conti.BK.WordProcessor.Config;
using FluentAssertions;
using System;
namespace Conti.BK.WordProcessor.Test;

public class ConfigTests
{
    IConfigReader reader = new FileConfigReader("");
    [SetUp]
    public void Setup()
    {
        //reader = new FileConfigReader("../../../configFileUnitTest.txt");
    }

    [Test]
    public void TestIfConfigReaderReadsConfig()
    {
        reader = new FileConfigReader("../../../configFileUnitTest.txt");
        var config = reader.Read();
        var configShould = new ContentConfig(){
            readerType = ReaderType.Console,
            ReaderParam = String.Empty,
            transformerType = TransformerType.ToUpper,
            TransformerParam = String.Empty,
            analyzerType = AnalyzerType.WordStartsWith,
            AnalyzerParam = "A",
            reporterType = ReporterType.Console,
            ReporterParam = String.Empty
        };
        config.Should().NotBeNull();
        config.AnalyzerParam.Should().Be(configShould.AnalyzerParam);
        config.analyzerType.Should().Be(configShould.analyzerType);
        config.readerType.Should().Be(configShould.readerType);
        config.ReaderParam.Should().Be(configShould.ReaderParam);
        config.ReporterParam.Should().Be(configShould.ReporterParam);
        config.reporterType.Should().Be(configShould.reporterType);
        config.TransformerParam.Should().Be(configShould.TransformerParam);
        config.transformerType.Should().Be(configShould.transformerType);
    }
    [Test]
    public void TestIfConfigReaderReadsWrongConfigAndFails()
    {
        reader = new FileConfigReader("../../../configFileUnitTestFail.txt");
        reader.Invoking(y => y.Read())
        .Should().Throw<Exception>()
        .WithMessage("No transformer called test");
    }

}