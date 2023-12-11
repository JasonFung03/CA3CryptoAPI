using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using System.Text.RegularExpressions;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task MyTest()
    {
        await Page.GotoAsync("https://jasonfung03.github.io/CA3CryptoAPI/");

        await Page.GetByRole(AriaRole.Row, new() { Name = "Bitcoin" }).GetByRole(AriaRole.Button).ClickAsync();

        await Expect(Page).ToHaveTitleAsync(new Regex("bitcoin"));

        // var max_supply = Page.Locator("#max_supply");
        // await Expect(max_supply).ToHaveTextAsync("21000000.0");

        // await Page.GetByText("21000000.0").ClickAsync();

        // await Page.GotoAsync("https://jasonfung03.github.io/CA3CryptoAPI/");

        // await Page.GetByPlaceholder("Enter a coin...").ClickAsync();

        // await Page.GetByPlaceholder("Enter a coin...").PressAsync("CapsLock");

        // await Page.GetByPlaceholder("Enter a coin...").FillAsync("B");

        // await Page.GetByPlaceholder("Enter a coin...").PressAsync("CapsLock");

        // await Page.GetByPlaceholder("Enter a coin...").FillAsync("Bitcoin");

        // await Page.GetByRole(AriaRole.Button, new() { Name = "Search" }).ClickAsync();

        // await Page.GetByRole(AriaRole.Row, new() { Name = "Bitcoin View More Details", Exact = true }).GetByRole(AriaRole.Button).ClickAsync();

        // await Page.GetByRole(AriaRole.Heading, new() { Name = "Bitcoin" }).ClickAsync();

    }
}
