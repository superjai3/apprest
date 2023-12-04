namespace apprest.Models
{   
    public class Plato
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Pais { get; set; }
        public string? Tipo_Comida { get; set; }
        public bool Disponibilidad { get; set; }
        public decimal Price { get; set; }
    }
}