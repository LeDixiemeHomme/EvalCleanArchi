using System.Text;

namespace exam_sales_reporter_kata.Model.Strategy;

public class PrintStrategy: DisplayStrategy
{
    public override string Display(string[] dataContentString)
    {
        StringBuilder stringBuilderProcessPrint = new StringBuilder();
		
        //get the header line  
        string line1 = dataContentString[0];
        //get other content lines
        var otherLines = dataContentString.Skip(1);
        var columnInfos = new List<(int index, int size, string name)>();
        //build the header of the table with column names from our data file
        int i = 0;
        foreach (var columName in line1.Split(','))
        {
            columnInfos.Add((i++, columName.Length, columName));
        }
    
        var headerString  = String.Join(" | ", columnInfos.Select(x=>x.name)
            .Select((val,ind) => val.PadLeft(16)));
		
        stringBuilderProcessPrint.AppendLine("+" + new String('-', headerString.Length + 2) + "+");
        stringBuilderProcessPrint.AppendLine("| " + headerString + " |");
        stringBuilderProcessPrint.AppendLine("+" + new String('-', headerString.Length + 2 ) + "+");
		
        //then add each line to the table  
        foreach (string line in otherLines)
        { 
            //extract columns from our csv line and add all these cells to the line  
            var cells = line.Split(',');
            var tableLine  = String.Join(" | ", line.Split(',')
                .Select((val,ind) => val.PadLeft(16)));
            stringBuilderProcessPrint.AppendLine($"| {tableLine} |");
        } 
        stringBuilderProcessPrint.AppendLine("+" + new String('-', headerString.Length+2) + "+");
        return stringBuilderProcessPrint.ToString();
    }
}