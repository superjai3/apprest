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
        public int? IngredienteId { get; set; }  
        public Ingrediente? Ingrediente { get; set; }  // Asegúrate de que Ingrediente sea nullable
    }
}
