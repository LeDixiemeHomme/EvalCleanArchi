using exam_sales_reporter_kata.Cli;
using exam_sales_reporter_kata.Model;
using exam_sales_reporter_kata.Model.Strategy;
using Xunit;
namespace exam_sales_reporter_kata.Tests;

public class RunTests
{
    private Run run = new Run();
    private string[] args = {"print", "path_file"};
    private string[] emptyArgs = {};
    
    [Fact]
    public void GetCommandFromArgs_on_args_works()
    {
        Assert.Equal(run.GetCommandFromArgs(this.args), Command.Print);
    }
    
    [Fact]
    public void GetCommandFromArgs_on_empty_args_returns_unknown()
    {
        Assert.Equal(run.GetCommandFromArgs(this.emptyArgs), Command.Unknown);
    }
    
    [Fact]
    public void GetFileFromArgs_on_args_works()
    {
        Assert.Equal(run.GetFileFromArgs(this.args), "path_file");
    }
    
    [Fact]
    public void GetFileFromArgs_on_empty_args_returns_unknown()
    {
        Assert.Equal(run.GetFileFromArgs(this.emptyArgs), "../../../Data/data.csv");
    }
    
    [Fact]
    public void DisplayStrategyFromCommand_on_Command_Print_returns_PrintStrategy()
    {
        Assert.IsType<PrintStrategy>(run.DisplayStrategyFromCommand(Command.Print));
    }
    
    [Fact]
    public void DisplayStrategyFromCommand_on_Command_Report_returns_ReportStrategy()
    {
        Assert.IsType<ReportStrategy>(run.DisplayStrategyFromCommand(Command.Report));
    }
    
    [Fact]
    public void DisplayStrategyFromCommand_on_Command_Unknown_returns_DefaultStrategy()
    {
        Assert.IsType<DefaultStrategy>(run.DisplayStrategyFromCommand(Command.Unknown));
    }
    
    [Fact]
    public void DisplayStrategyFromCommand_on_not_registered_Strategy_returns_DefaultStrategy()
    {
        Assert.IsType<DefaultStrategy>(run.DisplayStrategyFromCommand(Command.NotRegistered));
    }
}