namespace exam_sales_reporter_kata.Model.Strategy;

public class DisplayHelper
{
    private DisplayStrategy _displayStrategy;

    public DisplayHelper(DisplayStrategy displayStrategy)
    {
        _displayStrategy = displayStrategy;
    }

    public String Display(string[] dataContentString) 
    { 
        return _displayStrategy.Display(dataContentString);
    }
}