// See https://aka.ms/new-console-template for more information
using System.Text;
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

var apiKey = "YOUR_API_KEY";
var client = new HttpClient();
client.DefaultRequestHeaders.Add("api-key", apiKey);

var data = new
{
    to = new[] { new { email = "recipient@example.com" } },
    sender = new { email = "SENDER_EMAIL" },
    subject = "Hello World",
    htmlContent = "<p>Hello World</p>"
};

var json = JsonConvert.SerializeObject(data);
var content = new StringContent(json, Encoding.UTF8, "application/json");

var response = await client.PostAsync("https://api.sendinblue.com/v3/smtp/email", content);

if (response.IsSuccessStatusCode)
{
    Console.WriteLine("Email sent successfully");
}
else
{
    Console.WriteLine("Error sending email: " + await response.Content.ReadAsStringAsync());
}