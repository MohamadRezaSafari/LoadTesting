using NBomber.CSharp;
using NBomber.Http.CSharp;
using System.Net.Http;


using var httpClient = new HttpClient();

var scenario = Scenario.Create("http_scenario", async context =>
{
    var request =
        Http.CreateRequest("GET", "http://localhost:5105/WeatherForecast")
            .WithHeader("Content-Type", "application/json");
    // .WithBody(new StringContent("{ some JSON }", Encoding.UTF8, "application/json"));

    var response = await Http.Send(httpClient, request);

    return response;
})
.WithLoadSimulations(
    Simulation.Inject(
        rate: 2000,
        interval: TimeSpan.FromSeconds(1),
        during: TimeSpan.FromSeconds(30))
);

NBomberRunner
    .RegisterScenarios(scenario)
    .Run();