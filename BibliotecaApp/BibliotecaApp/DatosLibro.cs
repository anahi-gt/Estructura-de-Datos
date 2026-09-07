namespace BibliotecaApp
{
    public class DatosLibro
    {
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int Anio { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public bool Disponible { get; set; } = true;
    }
}