using System.Data;
using System.Data.SqlClient;
using Ejercicio_N2.Models.Capacitacion;
using Ejercicio_N2.Util;



namespace Ejercicio_N2.Services.Capacitacion
{
    public class SuppliersService
    {
        ///<summary>
        /// Método el cual consume el procedimiento almacenado que gestiona un suppliers
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
        /// En la etiqueta result, se retorna el código de suppliers recien creado para la operación crear, etc..
        /// En la etiqueta message, se retorna un mensaje de tipo informativo, error o éxito.
        /// </returns>
        public static CustomJSONResult GestionSuppliers(string constring, SuppliersModel modelo, int tipo_operacion)
        {
            string nombreMetodo = "GestionSuppliers" + "/SuppliersService";
            CustomJSONResult Rslt = new CustomJSONResult();
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(ReferenciaBD.SP_GESTION_SUPPLIERS, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pnTipoOperacion", SqlDbType.Int).Value = tipo_operacion;
                cmd.Parameters.Add("@pnSupplierID", SqlDbType.Int).Value = modelo.supplier_id;
                cmd.Parameters.Add("@pcCompanyName", SqlDbType.NVarChar).Value = modelo.company_name;
                cmd.Parameters.Add("@pcContactName", SqlDbType.NVarChar).Value = modelo.contact_name;
                cmd.Parameters.Add("@pcContactTitle", SqlDbType.NVarChar).Value = modelo.contact_title;
                cmd.Parameters.Add("@pcCity", SqlDbType.NVarChar).Value = modelo.city;
                cmd.Parameters.Add("@pcRegion", SqlDbType.NVarChar).Value = modelo.region;
                cmd.Parameters.Add("@pcPostalCode", SqlDbType.NVarChar).Value = modelo.postal_code;
                cmd.Parameters.Add("@pcCountry", SqlDbType.NVarChar).Value = modelo.country;
                cmd.Parameters.Add("@pcPhone", SqlDbType.NVarChar).Value = modelo.phone;
                cmd.Parameters.Add("@pcHomePage", SqlDbType.NVarChar).Value = modelo.home_page;
                cmd.Parameters.Add("@pcAddress", SqlDbType.NVarChar).Value = modelo.address;
                cmd.Parameters.Add("@pcFax", SqlDbType.NVarChar).Value = modelo.fax;





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
                string pcResult = (cmd.Parameters["@pcResult"].Value.ToString() == "null") ? null : cmd.Parameters["@pcResult"].Value.ToString();
                string pcMessage = (cmd.Parameters["@pcMessage"].Value.ToString() == "null") ? null : cmd.Parameters["@pcMessage"].Value.ToString();

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
                Rslt.Message = "Ocurrió un error" + ex.Message;

                return Rslt;
            }
        }


    }





}
