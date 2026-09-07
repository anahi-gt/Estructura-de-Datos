using System;
using System.Collections.Generic;

namespace BibliotecaApp
{
    public class Biblioteca
    {
        // Conjunto para evitar ISBNs duplicados O(1)
        private readonly HashSet<string> isbnRegistrados = new();

        // Mapa principal: ISBN -> Datos del libro
        private readonly Dictionary<string, DatosLibro> catalogoLibros = new();

        // Mapa secundario: Categoría -> Conjunto de ISBNs
        private readonly Dictionary<string, HashSet<string>> categoriasMap = new();

        public bool RegistrarLibro(string isbn, string titulo, string autor, int anio, string categoria)
        {
            if (isbnRegistrados.Contains(isbn))
            {
                Console.WriteLine($"\n[ERROR] El ISBN '{isbn}' ya se encuentra registrado.");
                return false;
            }

            isbnRegistrados.Add(isbn);

            catalogoLibros[isbn] = new DatosLibro
            {
                Titulo = titulo,
                Autor = autor,
                Anio = anio,
                Categoria = categoria,
                Disponible = true
            };

            if (!categoriasMap.ContainsKey(categoria))
            {
                categoriasMap[categoria] = new HashSet<string>();
            }
            categoriasMap[categoria].Add(isbn);

            Console.WriteLine($"\n[ÉXITO] Libro '{titulo}' registrado correctamente.");
            return true;
        }

        public void ConsultarPorIsbn(string isbn)
        {
            Console.WriteLine("\n=== CONSULTA DE LIBRO POR ISBN ===");
            if (!isbnRegistrados.Contains(isbn))
            {
                Console.WriteLine("[INFO] El ISBN ingresado no existe en el catálogo.");
                return;
            }

            var libro = catalogoLibros[isbn];
            string estado = libro.Disponible ? "Disponible" : "Prestado";

            Console.WriteLine($"ISBN: {isbn}\nTítulo: {libro.Titulo}\nAutor: {libro.Autor}\n" +
                              $"Año: {libro.Anio}\nCategoría: {libro.Categoria}\nEstado: {estado}");
        }

        public void ReporteGeneral()
        {
            Console.WriteLine("\n=================== REPORTE GENERAL DE CATÁLOGO ===================");
            if (catalogoLibros.Count == 0)
            {
                Console.WriteLine("El catálogo se encuentra vacío.");
                return;
            }

            Console.WriteLine($"{"ISBN",-15} | {"TÍTULO",-30} | {"AUTOR",-20} | {"CATEGORÍA",-15}");
            Console.WriteLine(new string('-', 88));

            foreach (var item in catalogoLibros)
            {
                var isbn = item.Key;
                var datos = item.Value;
                Console.WriteLine($"{isbn,-15} | {datos.Titulo,-30} | {datos.Autor,-20} | {datos.Categoria,-15}");
            }
        }

        public void ReportePorCategorias()
        {
            Console.WriteLine("\n================ REPORTE DE LIBROS POR CATEGORÍA ================");
            if (categoriasMap.Count == 0)
            {
                Console.WriteLine("No existen categorías registradas.");
                return;
            }

            foreach (var item in categoriasMap)
            {
                string cat = item.Key;
                HashSet<string> isbns = item.Value;

                Console.WriteLine($"\nCategoría: [{cat}] (Total: {isbns.Count} libros)");
                foreach (var isbn in isbns)
                {
                    var libro = catalogoLibros[isbn];
                    Console.WriteLine($"  - ISBN: {isbn} | Título: {libro.Titulo} ({libro.Anio})");
                }
            }
        }
    }
}