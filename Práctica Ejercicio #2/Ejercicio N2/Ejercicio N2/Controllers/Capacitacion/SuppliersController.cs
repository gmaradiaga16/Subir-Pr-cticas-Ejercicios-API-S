using Microsoft.AspNetCore.Mvc;
using Ejercicio_N2.Models.Capacitacion;
using Ejercicio_N2.Services.Capacitacion;
using Ejercicio_N2.Util;

namespace Ejercicio_N2.Controllers.Capacitacion
{
    public class SuppliersController : Controller
    {
        private readonly IConfiguration _configuration;
        public SuppliersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Crea un suppliers nueva.
        /// </summary>
        /// <remarks>
        /// 
        /// Estructura JSON esperada
        ///
        ///     {
        ///         " tipo_operacion": int,
        ///         "supplier_id": int,
        ///         "company_name": string,
        ///         "contact_name": string,
        ///         "contact_title": string,
        ///         "city": string,
        ///         "region": string,
        ///         "postal_code": string,
        ///         "country": string,
        ///         "phone": string,
        ///         "home_page": string,
        ///         "address": string,
        ///         "fax": string
        ///        
        ///     }
        ///     
        /// Retorna una estructura JSON con siguiente estructura:
        /// 
        ///     {
        ///         "typeResult": int,
        ///         "codeResult": int,
        ///         "result": string,
        ///         "message": string
        ///     }
        ///
        /// <para>En la etiqueta typeResult, se retorna el estado de la ejecución del servicio [0: Exitoso | 1: Error Controlado | 2: Error no controlado]</para>
        /// <para>En la etiqueta codeResult, se retorna un detalle del TypeResult</para>
        /// <para>En la etiqueta result, se retorna las respuestas esperadas del servicio. Para este servicio se retornará el código de usuario creado.</para>
        /// <para>En la etiqueta message, se retorna un mensaje de tipo informativo, error o éxito.</para>
        ///
        /// </remarks>
        /// <returns>
        /// </returns>
        /// <response code="200">OK. Servicio ejecutado correctamente.</response>
        /// <response code="400">BadRequest. Ocurrió un error en la ejecución del servicio.</response>
        [HttpPost("b/v1/suppliers")]
        public IActionResult CrearSuppliers([FromBody] SuppliersModel model)
        {
            string nombreMetodo = "CrearSuppliers" + "/SuppliersController";
            string constring = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            var response = new CustomJSONResult();
            try
            {
                response = SuppliersService.GestionSuppliers(constring, model, 1);
                return Ok(response);
            }
            catch
            {
                return BadRequest(response);
            }
        }



        [HttpPut("b/v1/suppliers")]
        public IActionResult ModificarSuppliers([FromBody] SuppliersModel model)
        {
            string nombreMetodo = "ModificarSuppliers" + "/SuppliersController";
            string constring = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            var response = new CustomJSONResult();
            try
            {
                response = SuppliersService.GestionSuppliers(constring, model, 2);
                return Ok(response);
            }
            catch
            {
                return BadRequest(response);
            }
        }

        [HttpDelete("b/v1/suppliers")]
        public IActionResult EliminarSuppliers([FromBody] SuppliersModel model)
        {
            string nombreMetodo = "EliminarSuppliers" + "/SuppliersController";
            string constring = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            var response = new CustomJSONResult();
            try
            {
                response = SuppliersService.GestionSuppliers(constring, model, 3);
                return Ok(response);
            }
            catch
            {
                return BadRequest(response);
            }
        }


    }

}
