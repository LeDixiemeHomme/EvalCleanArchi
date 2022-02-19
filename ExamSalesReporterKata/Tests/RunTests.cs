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
}