namespace CoworkingApi.Models
{
    public class Sala
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public string Equipamentos { get; set; }
        public bool Disponivel { get; set; } = true;
    }
}