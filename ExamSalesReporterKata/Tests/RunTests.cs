using exam_sales_reporter_kata.Cli;
using Xunit;
namespace exam_sales_reporter_kata.Tests;


public class RunTests
{
    private Run run = new Run();
    private string[] args = {"test1", "test2", "test3"};
    private string[] emptyArgs = {};
    
    [Fact]
    public void GetCommandFromArgs_on_args_works()
    {
        Assert.Equal(run.GetCommandFromArgs(this.args), "test1");
    }
    
    [Fact]
    public void GetCommandFromArgs_on_empty_args_returns_unknown()
    {
        Assert.Equal(run.GetCommandFromArgs(this.emptyArgs), "unknown");
    }
    
    [Fact]
    public void GetFileFromArgs_on_args_works()
    {
        Assert.Equal(run.GetFileFromArgs(this.args), "test2");
    }
    
    [Fact]
    public void GetFileFromArgs_on_empty_args_returns_unknown()
    {
        Assert.Equal(run.GetFileFromArgs(this.emptyArgs), "../../../Data/data.csv");
    }

    [Fact]
    public void ProcessPrint_works()
    {
        string[] dataContentString = File.ReadAllLines("../../../Data/data.csv");
        Assert.Equal(run.ProcessPrint(dataContentString: dataContentString), 
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
    public void ProcessReport_works()
    {
        string[] dataContentString = File.ReadAllLines("../../../Data/data.csv");
        Assert.Equal(run.ProcessReport(dataContentString: dataContentString), 
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
        Assert.Equal(run.ProcessUnknown(), 
            @$"[ERR] your command is not valid 
Help: 
    - [print]  : show the content of our commerce records in data.csv
    - [report] : show a summary from data.csv records 
");
    }
}