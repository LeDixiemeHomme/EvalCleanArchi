using System.Text;
using exam_sales_reporter_kata.Model.Strategy;

namespace exam_sales_reporter_kata.Cli;

public class Run
{
	public string GetCommandFromArgs(string[] args)
	{
		return args.Length > 0 ? args[0] : "unknown";
	}
	public string GetFileFromArgs(string[] args)
	{
		return args.Length >= 2 ? args[1] : "../../../Data/data.csv";
	}
	
	public void Exec(string[] args)
    {
    	//add a title to our app
    	Console.WriteLine("=== Sales Viewer ===");
    	//extract the command name from the args
    	string command = GetCommandFromArgs(args: args);
    	string file = GetFileFromArgs(args: args);
    	//read content of our data file
    	//[2012-10-30] rui : actually it only works with this file, maybe it's a good idea to pass file
    	//name as parameter to this app later?  
        string[] dataContentString = File.ReadAllLines(file);
        
        var commandWithStrategy = new Dictionary<string, DisplayStrategy>()
        {
	        { "print", new PrintStrategy()},
	        { "report", new ReportStrategy()},
	        { "unknown", new DefaultStrategy()}
        };
        
        DisplayStrategy displayStrategy = commandWithStrategy.GetValueOrDefault(command);
        
        DisplayHelper displayHelper = new DisplayHelper(displayStrategy: displayStrategy);
        
        Console.Write(displayHelper.Display(dataContentString));
    }
}