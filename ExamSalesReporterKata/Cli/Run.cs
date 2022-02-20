using System.Text;
using exam_sales_reporter_kata.Model;
using exam_sales_reporter_kata.Model.Strategy;

namespace exam_sales_reporter_kata.Cli;

public class Run
{
	public Command GetCommandFromArgs(string[] args)
	{
		if (args.Length > 0)
		{
			string command = args[0];
			return (Command) Enum.Parse(typeof(Command), command, true);
			// return Enum.GetNames(typeof(Command)).Contains(command) ? Enum.Parse(typeof(Command), command) : Command.Unknown;
		}
		return Command.Unknown;
	}
	public string GetFileFromArgs(string[] args)
	{
		return args.Length > 1 ? args[1] : "../../../Data/data.csv";
	}

	public DisplayStrategy DisplayStrategyFromCommand(Command command)
	{
		var commandWithStrategy = new Dictionary<Command, DisplayStrategy>()
		{
			{Command.Print, new PrintStrategy()},
			{Command.Report, new ReportStrategy()},
			{Command.Unknown, new DefaultStrategy()}
		};
		return commandWithStrategy.GetValueOrDefault(command, new DefaultStrategy());
	}
	
	public void Exec(string[] args)
    {
    	//add a title to our app
    	Console.WriteLine("=== Sales Viewer ===");
    	//extract the command name from the args
    	Command command = GetCommandFromArgs(args: args);
    	string file = GetFileFromArgs(args: args);
    	//read content of our data file
    	//[2012-10-30] rui : actually it only works with this file, maybe it's a good idea to pass file
    	//name as parameter to this app later?  
        string[] dataContentString = File.ReadAllLines(file);
        
        DisplayStrategy displayStrategy = DisplayStrategyFromCommand(command: command);
        
        DisplayHelper displayHelper = new DisplayHelper(displayStrategy: displayStrategy);
        
        Console.Write(displayHelper.Display(dataContentString));
    }
}