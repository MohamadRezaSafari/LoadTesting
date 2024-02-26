namespace JmeterDsl;
using static Abstracta.JmeterDsl.JmeterDsl;

public class PerformanceTest
{
    [Fact]
    public void LoadTest()
    {
        var stats = TestPlan(
            ThreadGroup(2, 10,
                HttpSampler("http://localhost:5105/WeatherForecast")
            )
        ).Run();

        Assert.True(stats.Overall.SampleTimePercentile99 < TimeSpan.FromSeconds(5));
        //Assert.That(stats.Overall.SampleTimePercentile99, Is.LessThan(TimeSpan.FromSeconds(5)));
    }
}
