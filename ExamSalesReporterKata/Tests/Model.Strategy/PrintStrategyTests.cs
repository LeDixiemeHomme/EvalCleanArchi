using System.Text;
using exam_sales_reporter_kata.Model.Strategy;
using NFluent.Extensions;
using Xunit;

namespace exam_sales_reporter_kata.Tests.Model.Strategy;

public class PrintStrategyTests
{
    PrintStrategy strategy = new PrintStrategy();

    [Fact]
    public void AddHeaderStringBuilderTest()
    {
        string headerString = "         data1 |         data2 |    data3";
        StringBuilder stringBuilderProcessPrint = new StringBuilder(); 
        StringBuilder expected = new StringBuilder().Append(
            @$"+-------------------------------------------+
|          data1 |         data2 |    data3 |
+-------------------------------------------+
");
        StringBuilder actual = this.strategy.AddHeaderStringBuilder(headerString, stringBuilderProcessPrint);
        Assert.Equal(expected.ToString(), actual.ToString());
    }

    [Fact]
    public void AddBodyToStringBuilderTest()
    {
        IEnumerable<string> otherLines = new[]
        {
            "1, peter, 3, 123.00, 2021-11-30",
            "2, paul, 1, 433.50, 2021-12-11",
            "3, peter, 1, 329.99, 2021-12-18",
            "4, john, 5, 467.35, 2021-12-30",
            "5, john, 1, 88.00, 2022-01-04"
        };
        StringBuilder stringBuilderProcessPrint = new StringBuilder(); 
        StringBuilder expected = new StringBuilder().Append(
            @$"|                1 |            peter |                3 |           123.00 |       2021-11-30 |
|                2 |             paul |                1 |           433.50 |       2021-12-11 |
|                3 |            peter |                1 |           329.99 |       2021-12-18 |
|                4 |             john |                5 |           467.35 |       2021-12-30 |
|                5 |             john |                1 |            88.00 |       2022-01-04 |
");
        StringBuilder actual = this.strategy.AddBodyToStringBuilder(otherLines, stringBuilderProcessPrint);
        Assert.Equal(expected.ToString(), actual.ToString());
    }
}