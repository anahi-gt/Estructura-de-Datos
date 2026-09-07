using System;

namespace BibliotecaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Biblioteca biblio = new Biblioteca();

            // Registro de datos de prueba
            biblio.RegistrarLibro("978-0131103627", "The C Programming Language", "Kernighan & Ritchie", 1988, "Programación");
            biblio.RegistrarLibro("978-0134685991", "Effective Java", "Joshua Bloch", 2017, "Programación");
            biblio.RegistrarLibro("978-0132350884", "Clean Code", "Robert C. Martin", 2008, "Software");

            // Intento de duplicado
            biblio.RegistrarLibro("978-0131103627", "Duplicado Test", "Desconocido", 2020, "Programación");

            // Reportería
            biblio.ReporteGeneral();
            biblio.ReportePorCategorias();
            biblio.ConsultarPorIsbn("978-0132350884");
        }
    }
}