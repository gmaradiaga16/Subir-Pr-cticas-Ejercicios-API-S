using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ejercicio_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Roxny", "Javier", "Gaby", "Giselh", "Gabriela"
    };

        private static readonly string[] Summaries1 = new[]
        {
        "Barahona", "Ramos", "Maradiaga", "Amador", "Zeron"
    };

        private readonly ILogger<WeatherForecastController> _logger;
       

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            
        }

        [HttpGet("GetWeatherForecast")]
        public List<WeatherForecast> Get(int Nombres)
        {
            List<WeatherForecast> nuevoModelo = new List<WeatherForecast>();

            if
                (Nombres == 1)

            {
                nuevoModelo.Add(new WeatherForecast

                {
                    Nombre = "Gabriela",
                    Apellido = "Maradiaga",
                    Date = DateTime.Now,
                });

            }
            else if (Nombres == 2)
            {
                nuevoModelo.Add(new WeatherForecast
                {
                    Nombre = "Giselh",
                    Apellido = "Amador",
                    Date = DateTime.Now,
                });
            }

            else if (Nombres == 3)

            {
                nuevoModelo.Add(new WeatherForecast
                {
                    Nombre = "Gaby",
                    Apellido = "Zeron",
                    Date = DateTime.Now,
                });
            }
            return nuevoModelo;
        }
        //**************************************************************************************************************

        [HttpPut("PutWeatherForecast")]
        public String Put([FromBody] WeatherForecast parametro1)
        {
            List<WeatherForecast>forecast = new List<WeatherForecast>();
            forecast.Add(new WeatherForecast

            {
                Nombre = "Roxny",
                Apellido = "Barahona",
                Date = DateTime.Now,
            });

            return JsonConvert.SerializeObject(forecast);
        }


        //**************************************************************************************************************

        [HttpPost("PostWeatherForecast")]
        public String Post([FromBody] WeatherForecast parametro2)
        {
            List<WeatherForecast> forecast = new List<WeatherForecast>();
            forecast.Add(new WeatherForecast

            {
                Nombre = "Javier",
                Apellido = "Ramos",
                Date = DateTime.Now,
            });

            return JsonConvert.SerializeObject(forecast);
        }

        //**************************************************************************************************************

        [HttpDelete("DeleteWeatherForecast")]
        public String Delete([FromBody] WeatherForecast parametro)
        {
            List<WeatherForecast> forecast = new List<WeatherForecast>();
            forecast.Add(new WeatherForecast

            {
                Nombre = "Javi",
                Apellido = "Ramos",
                Date = DateTime.Now,
            });

            return JsonConvert.SerializeObject(forecast);
        }




    }
    }