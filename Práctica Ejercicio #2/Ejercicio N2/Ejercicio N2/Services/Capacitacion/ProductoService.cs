using System.Data;
using System.Data.SqlClient;
using Ejercicio_N2.Models.Capacitacion;
using Ejercicio_N2.Util;


namespace Ejercicio_N2.Services.Capacitacion
{
    public class ProductoService
    {
        ///<summary>
        /// Método el cual consume el procedimiento almacenado que gestiona un producto
        ///</summary>
        ///<remarks>
        ///Autor: by gmaradiaga 20230519 
        ///</remarks>
        ///<returns>
        /// Retorna una estructura JSON con siguiente estructura:
        /// 
        ///     {
        ///         "typeResult": int,
        ///         "codeResult": int,
        ///         "result": string,
        ///         "message": string
        ///     }
        ///
        /// En la etiqueta typeResult, se retorna el estado de la ejecución del servicio [0: Exitoso | 1: Error Controlado | 2: Error no controlado]
        /// En la etiqueta codeResult, se retorna un detalle del TypeResult
        /// En la etiqueta result, se retorna el código de producto recien creado para la operación crear, etc..
        /// En la etiqueta message, se retorna un mensaje de tipo informativo, error o éxito.
        /// </returns>
        public static CustomJSONResult GestionProducto(string constring, ProductoModel modelo, int tipo_operacion)
        {
            string nombreMetodo = "GestionProducto" + "/ProductoService";
            CustomJSONResult Rslt = new CustomJSONResult();
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(ReferenciaBD.SP_GESTION_PRODUCTO, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pnTipoOperacion", SqlDbType.Int).Value = tipo_operacion;
                cmd.Parameters.Add("@pnProductID", SqlDbType.Int).Value = modelo.product_id;
                cmd.Parameters.Add("@pcProductName", SqlDbType.NVarChar).Value = modelo.product_name;
                cmd.Parameters.Add("@pnSupplierID", SqlDbType.Int).Value = modelo.supplier;
                cmd.Parameters.Add("@pnCategoryID", SqlDbType.Int).Value = modelo.category_id;
                cmd.Parameters.Add("@pcQuantityPerUnit", SqlDbType.NVarChar).Value = modelo.category_per_unit;
                cmd.Parameters.Add("@pnUnitPrice", SqlDbType.Decimal).Value = modelo.price;
                cmd.Parameters.Add("@pnUnitsInStock", SqlDbType.Int).Value = modelo.units_in_stock;
                cmd.Parameters.Add("@pnUnitsOnOrder", SqlDbType.Int).Value = modelo.units_on_order;
                cmd.Parameters.Add("@pnReorderLevel", SqlDbType.Int).Value = modelo.reorder_level;
                cmd.Parameters.Add("@pnDiscontinued", SqlDbType.Bit).Value = modelo.discontinued;



                SqlParameter pcTypeResultparam = new SqlParameter();
                pcTypeResultparam.ParameterName = "@pnTypeResult";
                pcTypeResultparam.SqlDbType = SqlDbType.Int;
                pcTypeResultparam.Size = int.MaxValue;
                pcTypeResultparam.Direction = ParameterDirection.Output;



                SqlParameter pcCodeResultparam = new SqlParameter();
                pcCodeResultparam.ParameterName = "@pnCodeResult";
                pcCodeResultparam.SqlDbType = SqlDbType.Int;
                pcCodeResultparam.Size = int.MaxValue;
                pcCodeResultparam.Direction = ParameterDirection.Output;

                SqlParameter pcResultparam = new SqlParameter();
                pcResultparam.ParameterName = "@pcResult";
                pcResultparam.SqlDbType = SqlDbType.VarChar;
                pcResultparam.Size = int.MaxValue;
                pcResultparam.Direction = ParameterDirection.Output;

                SqlParameter pcMessageparam = new SqlParameter();
                pcMessageparam.ParameterName = "@pcMessage";
                pcMessageparam.SqlDbType = SqlDbType.VarChar;
                pcMessageparam.Size = int.MaxValue;
                pcMessageparam.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(pcTypeResultparam);
                cmd.Parameters.Add(pcCodeResultparam);
                cmd.Parameters.Add(pcResultparam);
                cmd.Parameters.Add(pcMessageparam);



                SqlDataReader reader = cmd.ExecuteReader();

                reader.Close();

                int pnTypeResult = (cmd.Parameters["@pnTypeResult"].Value.ToString() == "null") ? 0 : Convert.ToInt32(cmd.Parameters["@pnTypeResult"].Value);
                int pnCodeResult = (cmd.Parameters["@pnCodeResult"].Value.ToString() == "null") ? 0 : Convert.ToInt32(cmd.Parameters["@pnCodeResult"].Value);
                String pcResult = (cmd.Parameters["@pcResult"].Value.ToString() == "null") ? null : cmd.Parameters["@pcResult"].Value.ToString();
                String pcMessage = (cmd.Parameters["@pcMessage"].Value.ToString() == "null") ? null : cmd.Parameters["@pcMessage"].Value.ToString();

                conn.Close();

                Rslt.TypeResult = pnTypeResult;
                Rslt.CodeResult = pnCodeResult;
                Rslt.Result = pcResult;
                Rslt.Message = pcMessage;




                return Rslt;
            }
            catch (Exception ex)
            {
                Rslt.TypeResult = 2;
                Rslt.CodeResult = 1;
                Rslt.Message = "Ocurrió un error";

                return Rslt;
            }
        }


    }
    
    



}
