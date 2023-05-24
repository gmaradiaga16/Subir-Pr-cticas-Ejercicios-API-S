namespace Ejercicio_N2.Models.Capacitacion
{
    public class ProductoModel
    {
        public int tipo_operacion { get; set; }
        public int product_id { get; set; }
        public string product_name { get; set; }
        public int supplier { get; set; }
        public int category_id { get; set; }
        public string category_per_unit { get; set; }
        public decimal price { get; set; }
        public int units_in_stock { get; set; }
        public int units_on_order { get; set; }
        public int reorder_level { get; set; }
        public bool discontinued { get; set; }


    }

    

    


}
