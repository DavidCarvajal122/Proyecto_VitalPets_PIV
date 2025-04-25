namespace Proyecto_VitalPets_PIV.Models
{
    // Models/Mascota.cs
    public class Mascota
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public int Edad { get; set; }
        public float Peso { get; set; }
        public string FotoUrl { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }

}
