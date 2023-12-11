using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using System.Text.RegularExpressions;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task CheckTopCoinButtonClickAndRedirect()
    {
        await Page.GotoAsync("https://jasonfung03.github.io/CA3CryptoAPI/");
        await Page.GetByRole(AriaRole.Row, new() { Name = "Bitcoin" }).GetByRole(AriaRole.Button).ClickAsync();
        await Expect(Page).ToHaveTitleAsync(new Regex("bitcoin"));
        var max_supply = Page.Locator("#max_supply");
        await Expect(max_supply).ToHaveTextAsync("21000000.0");
    }

    [Test]
    public async Task TestSearchFunction() {
        await Page.GotoAsync("https://jasonfung03.github.io/CA3CryptoAPI/");
        await Page.GetByPlaceholder("Enter a coin...").FillAsync("Eth");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Search" }).ClickAsync();
        await Page.GetByRole(AriaRole.Row, new() { Name = "Ethereum View More Details", Exact = true }).GetByRole(AriaRole.Button).ClickAsync();
        await Expect(Page).ToHaveTitleAsync(new Regex("ethereum"));
        var max_supply = Page.Locator("#max_supply");
        await Expect(max_supply).ToHaveTextAsync("");
    }
    
    [Test]
    public async Task PriceCalculationShouldBeCorrect()
    {
        await Page.GotoAsync("https://jasonfung03.github.io/CA3CryptoAPI/bitcoin");
        var priceText = await Page.InnerTextAsync("#price");
        var priceValue = decimal.Parse(priceText.Replace("€", ""));
        var calculatedAmountText = await Page.InnerTextAsync(".mt-3");
        var calculatedAmount = decimal.Parse(calculatedAmountText.Split('|')[0].Trim()).ToString("N8");
        Console.WriteLine(calculatedAmount);
        var expectedCalculatedAmount = 100 / priceValue;
        var expectString = expectedCalculatedAmount.ToString("N8");
        Assert.AreEqual(expectString, calculatedAmount);
    }
}
