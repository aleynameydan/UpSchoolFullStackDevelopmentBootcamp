using System.Net.Http.Json;
using Microsoft.AspNetCore.SignalR.Client;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using UpSchool.Domain.Dtos;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

Thread.Sleep(5000);

new DriverManager().SetUpDriver(new ChromeConfig());

IWebDriver driver = new ChromeDriver();

var hubConnection = new HubConnectionBuilder()
    .WithUrl($"https://localhost:7296/Hubs/SeleniumLogHub")
    .WithAutomaticReconnect() // otomatik bağlanmayı sağlıyor
    .Build();

await hubConnection.StartAsync();

try
{
    //await hubConnection.InvokeAsync("SendLogNotificationAsync", CreateLog("Bot started."));

    var httpClient = new HttpClient();

    var apiSendNotificationDto = new SendLogNotificationApiDto(CreateLog("Bot started."), hubConnection.ConnectionId);

    await httpClient.PostAsJsonAsync("https://localhos:7296/api/SeleniumLogs", apiSendNotificationDto);
    
    driver.Navigate().GoToUrl("https://www.google.com");

    // We are waiting for fun. 
    Thread.Sleep(1500);

    IWebElement searchBox = driver.FindElement(By.Name("q"));
    searchBox.SendKeys("UpSchool");
    searchBox.Submit();

    // We are waiting for the results to load.
    Thread.Sleep(3000);

    // // UP School.io is the first result we want to click on.
    IWebElement firstResult = driver.FindElements(By.CssSelector("div.g")).FirstOrDefault();
    if (firstResult != null)
    {
        IWebElement link = firstResult.FindElement(By.TagName("a"));
        link.Click();
    }
    else
    {
        Console.WriteLine("No search results found.");
    }

    Console.ReadKey();


    driver.Quit();
}
catch (Exception exception)
{
    driver.Quit();
}

//create log işlemi
SeleniumLogDto CreateLog(string message) => new SeleniumLogDto(message);
