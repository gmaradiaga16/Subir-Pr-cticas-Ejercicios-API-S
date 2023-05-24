using Microsoft.AspNetCore.Mvc;
using Ejercicio_N2.Models.Capacitacion;
using Ejercicio_N2.Services.Capacitacion;
using Ejercicio_N2.Util;


namespace Ejercicio_N2.Controllers.Capacitacion
{
    public class ProductoController : Controller
    {
        private readonly IConfiguration _configuration;
        public ProductoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Crea un producto nuevo.
        /// </summary>
        /// <remarks>
        /// 
        /// Estructura JSON esperada
        ///
        ///     {
        ///         " tipo_operacion": int,
        ///         "product_id": int,
        ///         "product_name": string,
        ///         "supplier": int,
        ///         "category_id": int,
        ///         "category_per_unit": string,
        ///         "price": decimal,
        ///         "units_in_stock": int,
        ///         "units_on_order": int,
        ///         "reorder_level": int,
        ///         "discontinued": bool
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
        [HttpPost("b/v1/producto")]
        public IActionResult CrearProducto([FromBody] ProductoModel model)
        {
            string nombreMetodo = "CrearProducto" + "/ProductoController";
            string constring = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            var response = new CustomJSONResult();
            try
            {
                response = ProductoService.GestionProducto(constring, model, 1);
                return Ok(response);
            }
            catch
            {
                return BadRequest(response);
            }
        }



        [HttpPut("b/v1/producto")]
        public IActionResult ModificarProducto([FromBody] ProductoModel model)
        {
            string nombreMetodo = "ModificarProducto" + "/ProductoController";
            string constring = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            var response = new CustomJSONResult();
            try
            {
                response = ProductoService.GestionProducto(constring, model, 2);
                return Ok(response);
            }
            catch
            {
                return BadRequest(response);
            }
        }

        [HttpDelete("b/v1/producto")]
        public IActionResult EliminarProducto([FromBody] ProductoModel model)
        {
            string nombreMetodo = "EliminarProducto" + "/ProductoController";
            string constring = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            var response = new CustomJSONResult();
            try
            {
                response = ProductoService.GestionProducto(constring, model, 3);
                return Ok(response);
            }
            catch
            {
                return BadRequest(response);
            }
        }


    }
    





}
