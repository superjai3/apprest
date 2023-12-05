namespace apprest.Models
{   
    public class Ingrediente
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Plato> Platos { get; set; }
    }
}
