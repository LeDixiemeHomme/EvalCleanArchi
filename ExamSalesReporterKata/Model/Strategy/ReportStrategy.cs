using System.Text;

namespace exam_sales_reporter_kata.Model.Strategy;

public class ReportStrategy: DisplayStrategy
{
    public override string Display(string[] dataContentString)
    {
		StringBuilder stringBuilderProcessReport = new StringBuilder();
		
		//get all the lines without the header in the first line
    	 var otherLines = dataContentString.Skip(1);
    	 //declare variables for our conters
    	 int number1 = 0, number2 = 0;
    	 double number4 = 0.0, number5 = 0.0, number3 = 0;
    	 HashSet<string> clients = new HashSet<string>();
    	 DateTime last = DateTime.MinValue;
    	 //do the counts for each line
    	 foreach (var line in otherLines)
    	 { //get the cell values for the line
    	 	var cells = line.Split(',');
    	 	number1++;//increment the total of sales
    	 	//to count the number of clients, we put only distinct names in a hashset //then we'll count the number of entries
    	 	if (!clients.Contains(cells[1])) clients.Add(cells[1]);  
    	 	number2 += int.Parse(cells[2]);//we sum the total of items sold here
    	 	number3 += double.Parse(cells[3]);//we sum the amount of each sell
    	 	//we compare the current cell date with the stored one and pick the higher
    	 	last = DateTime.Parse(cells[4]) > last ? DateTime.Parse(cells[4]) : last;  
    	 }
    	 //we compute the average basket amount per sale
    	 number4 = Math.Round(number3 / number1,2);
    	 //we compute the average item price sold
    	 number5 = Math.Round(number3 / number2,2);
    	 stringBuilderProcessReport.AppendLine($"+{new String('-',45)}+");
    	 stringBuilderProcessReport.AppendLine($"| {" Number of sales".PadLeft(30)} | {number1.ToString().PadLeft(10)} |");
    	 stringBuilderProcessReport.AppendLine($"| {" Number of clients".PadLeft(30)} | {clients.Count.ToString().PadLeft(10)} |");
    	 stringBuilderProcessReport.AppendLine($"| {" Total items sold".PadLeft(30)} | {number2.ToString().PadLeft(10)} |");
    	 stringBuilderProcessReport.AppendLine($"| {" Total sales amount".PadLeft(30)} | {Math.Round(number3,2).ToString().PadLeft(10)} |");
    	 stringBuilderProcessReport.AppendLine($"| {" Average amount/sale".PadLeft(30)} | {number4.ToString().PadLeft(10)} |");
    	 stringBuilderProcessReport.AppendLine($"| {" Average item price".PadLeft(30)} | {number5.ToString().PadLeft(10)} |");
    	 stringBuilderProcessReport.AppendLine($"+{new String('-',45)}+");
         return stringBuilderProcessReport.ToString();
    }
}