using Dapr.Client;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly DaprClient _daprClient;

		public IndexModel(ILogger<IndexModel> logger, DaprClient _daprClient)
		{
			_logger = logger;
			this._daprClient = _daprClient;
		}

		public async Task OnGet()
		{
			var forecasts = await
				_daprClient.InvokeMethodAsync<IEnumerable<WeatherForecast>>(
					HttpMethod.Get,
					"BackEnd",
					"weatherforecast");

			ViewData["WeatherForecastData"] = forecasts;
		}
	}
}