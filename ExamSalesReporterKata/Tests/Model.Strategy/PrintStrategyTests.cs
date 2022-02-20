using System.Text;
using exam_sales_reporter_kata.Model.Strategy;
using NFluent.Extensions;
using Xunit;

namespace exam_sales_reporter_kata.Tests.Model.Strategy;

public class PrintStrategyTests
{
    PrintStrategy strategy = new PrintStrategy();

    [Fact]
    public void StringBuilderWithHeaderString()
    {
        string headerString = "         data1 |         data2 |    data3";
        StringBuilder expected = new StringBuilder().Append(
            @$"+-------------------------------------------+
|          data1 |         data2 |    data3 |
+-------------------------------------------+
");
        StringBuilder actual = this.strategy.StringBuilderWithHeaderString(headerString: headerString);
        Assert.Equal(expected.ToString(), actual.ToString());
    }
}