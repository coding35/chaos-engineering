// See https://aka.ms/new-console-template for more information

using CoreApp;
using Polly;
using Polly.Retry;

const string url = "http://ip.jsontest.com/?callback=showMyIP";

var client = new Client(new HttpClient(), Policy
    .Handle<Exception>()
    .WaitAndRetryAsync(new[]
    {
        TimeSpan.FromSeconds(1),
        TimeSpan.FromSeconds(2),
        TimeSpan.FromSeconds(3)
    }));

var response = await client.GetAsync(url);

Console.WriteLine(response);