namespace apprest.Models
{   
    public class Ingrediente
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }

        // Marcar la propiedad con Nullable si puede ser nula
        public virtual ICollection<Plato>? Platos { get; set; }
    }
}
