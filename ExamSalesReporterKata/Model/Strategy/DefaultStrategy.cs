using System.Text;

namespace exam_sales_reporter_kata.Model.Strategy;

public class DefaultStrategy: DisplayStrategy
{
    public override string Display(string[] dataContentString)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("[ERR] your command is not valid ");
        stringBuilder.AppendLine("Help: ");
        stringBuilder.AppendLine("    - [print]  : show the content of our commerce records in data.csv");
        stringBuilder.AppendLine("    - [report] : show a summary from data.csv records ");
        return stringBuilder.ToString();
    }
}