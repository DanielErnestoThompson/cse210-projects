using System;

class BalanceSheet
{
    public double CurrentAssets { get; set; }
    public double CurrentLiabilities { get; set; }
    public double TotalAssets { get; set; }
    public double TotalEquity { get; set; }
    public double TotalLiabilities { get; set; }
}

class IncomeStatement
{
    public double Revenue { get; set; }
    public double CostOfGoodsSold { get; set; }
    public double OperatingExpenses { get; set; }
    public double NetIncome { get; set; }
}

class Ratios
{
    public double CalculateCurrentRatio(BalanceSheet bs)
    {
        return bs.CurrentAssets / bs.CurrentLiabilities;
    }

    public double CalculateSolvencyRatio(BalanceSheet bs)
    {
        return bs.TotalEquity / bs.TotalAssets;
    }

    public double CalculateProfitMargin(IncomeStatement ismt)
    {
        return ismt.NetIncome / ismt.Revenue;
    }

    public double CalculateAssetTurnover(IncomeStatement ismt, BalanceSheet bs)
    {
        return ismt.Revenue / bs.TotalAssets;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create synthetic data
        BalanceSheet bs = new BalanceSheet
        {
            CurrentAssets = 10000,
            CurrentLiabilities = 5000,
            TotalAssets = 20000,
            TotalEquity = 15000,
            TotalLiabilities = 5000
        };

        IncomeStatement ismt = new IncomeStatement
        {
            Revenue = 30000,
            CostOfGoodsSold = 10000,
            OperatingExpenses = 10000,
            NetIncome = 8000
        };

        // Calculate ratios
        Ratios ratios = new Ratios();
        double currentRatio = ratios.CalculateCurrentRatio(bs);
        double solvencyRatio = ratios.CalculateSolvencyRatio(bs);
        double profitMargin = ratios.CalculateProfitMargin(ismt);
        double assetTurnover = ratios.CalculateAssetTurnover(ismt, bs);

        // Output results
        Console.WriteLine($"Current Ratio: {currentRatio:F2}");
        Console.WriteLine($"Solvency Ratio: {solvencyRatio:F2}");
        Console.WriteLine($"Profit Margin: {profitMargin:F2}");
        Console.WriteLine($"Asset Turnover: {assetTurnover:F2}");
    }
}
