using ApplicationCore.Enum;


namespace ApplicationCore.Specification.Filters
{
    public class ClienteFilter : BaseFilter
    {
        public Genero Genero { get; set; }
        public string Apellidos { get; set; }
        public string Codigo { get; set; }

    }
}
