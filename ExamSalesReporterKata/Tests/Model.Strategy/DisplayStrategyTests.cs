using exam_sales_reporter_kata.Model.Strategy;
using Xunit;

namespace exam_sales_reporter_kata.Tests.Model.Strategy;

public class DisplayStrategyTests
{
    public DisplayHelper HelperProvider(DisplayStrategy displayStrategy)
    {
        return new DisplayHelper(displayStrategy: displayStrategy);
    }
    
    [Fact]
    public void PrintStrategy_on_data_works()
    {
        string[] dataContentString = File.ReadAllLines("../../../Data/data.csv");

        DisplayHelper displayHelper = HelperProvider(new PrintStrategy());
        
        Assert.Equal(displayHelper.Display(dataContentString: dataContentString), 
            @$"+----------------------------------------------------------------------------------------------+
|          orderid |         userName |    numberOfItems |    totalOfBasket |        dateOfBuy |
+----------------------------------------------------------------------------------------------+
|                1 |            peter |                3 |           123.00 |       2021-11-30 |
|                2 |             paul |                1 |           433.50 |       2021-12-11 |
|                3 |            peter |                1 |           329.99 |       2021-12-18 |
|                4 |             john |                5 |           467.35 |       2021-12-30 |
|                5 |             john |                1 |            88.00 |       2022-01-04 |
+----------------------------------------------------------------------------------------------+
");
    }

    [Fact]
    public void ReportStrategy_on_data_works()
    {
        string[] dataContentString = File.ReadAllLines("../../../Data/data.csv");

        DisplayHelper displayHelper = HelperProvider(new ReportStrategy());
        
        Assert.Equal(displayHelper.Display(dataContentString: dataContentString), 
            @$"+---------------------------------------------+
|                Number of sales |          5 |
|              Number of clients |          3 |
|               Total items sold |         11 |
|             Total sales amount |    1441.84 |
|            Average amount/sale |     288.37 |
|             Average item price |     131.08 |
+---------------------------------------------+
");
    }

    [Fact]
    public void ProcessUnknown_works()
    {
        DisplayHelper displayHelper = HelperProvider(new DefaultStrategy());
        
        Assert.Equal(displayHelper.Display(new string[]{}), 
            @$"[ERR] your command is not valid 
Help: 
    - [print]  : show the content of our commerce records in data.csv
    - [report] : show a summary from data.csv records 
");
    }
}