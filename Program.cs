using System;
using System.Collections.Generic;

namespace MetodosAnonimos
{
    // ---------- Delegados ----------
    delegate int Multiplicar(int a, int b);
    delegate bool VerificarPalindromo(string texto);
    delegate double ConvertirTemperatura(double celsius);
    delegate bool EsMayorQueDiez(int n);
    delegate bool CompararLongitud(string a, string b);
    delegate long CalcularFactorial(int n);
    delegate int ContarCaracteres(string texto);
    delegate bool Operacion(int n);                 // Ej 8
    delegate bool Filtro(Producto p);               // Ej 9
    delegate bool FiltroEmpleado(Empleado e);       // Ej 10
    delegate bool FiltroLibros(Libro l);            // Ej 11
    delegate bool FiltroVehiculo(Vehiculo v);       // Ej 12

    // ---------- Clases ----------
    class Producto
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
    }

    class Empleado
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }

    class Libro
    {
        public string Titulo { get; set; }
        public string Categoria { get; set; }
    }

    class Vehiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnioFabricacion { get; set; }
    }

    class Program
    {
        // Ej 8
        static void ProcesarNumero(int numero, Operacion op)
        {
            Console.WriteLine($"El número {numero} es par: {op(numero)}");
        }

        // Ej 9
        static void MostrarProductosFiltrados(List<Producto> lista, Filtro filtro)
        {
            foreach (var p in lista)
                if (filtro(p))
                    Console.WriteLine($"- {p.Nombre} (Cantidad: {p.Cantidad})");
        }

        // Ej 10
        static void FiltrarEmpleados(List<Empleado> lista, FiltroEmpleado filtro)
        {
            foreach (var e in lista)
                if (filtro(e))
                    Console.WriteLine($"- {e.Nombre} (Edad: {e.Edad})");
        }

        // Ej 11
        static void MostrarLibrosPorCategoria(List<Libro> lista, FiltroLibros filtro)
        {
            foreach (var l in lista)
                if (filtro(l))
                    Console.WriteLine($"- {l.Titulo}");
        }

        // Ej 12
        static void MostrarVehiculosAntiguos(List<Vehiculo> lista, FiltroVehiculo filtro)
        {
            foreach (var v in lista)
                if (filtro(v))
                    Console.WriteLine($"- {v.Marca} {v.Modelo} ({v.AnioFabricacion})");
        }

        static void Main()
        {
            // ----- Ejercicio 1 -----
            Multiplicar mult = delegate (int a, int b) { return a * b; };
            Console.WriteLine($"4 * 3 = {mult(4, 3)}");
            Console.WriteLine($"7 * 5 = {mult(7, 5)}");

            // ----- Ejercicio 2 -----
            VerificarPalindromo esPalindromo = delegate (string s)
            {
                char[] arr = s.ToCharArray();
                Array.Reverse(arr);
                return s == new string(arr);
            };
            Console.WriteLine($"'radar' es un palíndromo: {esPalindromo("radar")}");
            Console.WriteLine($"'puerta' es un palíndromo: {esPalindromo("puerta")}");

            // ----- Ejercicio 3 -----
            ConvertirTemperatura aF = delegate (double c) { return c * 9 / 5 + 32; };
            Console.WriteLine($"0°C -> {aF(0)}°F");
            Console.WriteLine($"30°C -> {aF(30)}°F");

            // ----- Ejercicio 4 -----
            EsMayorQueDiez mayorDiez = delegate (int n) { return n > 10; };
            Console.WriteLine($"8 es mayor que 10: {mayorDiez(8)}");
            Console.WriteLine($"15 es mayor que 10: {mayorDiez(15)}");

            // ----- Ejercicio 5 -----
            CompararLongitud mismaLongitud = delegate (string a, string b) { return a.Length == b.Length; };
            Console.WriteLine($"Las palabras 'gato' y 'perro' tienen la misma longitud: {mismaLongitud("gato", "perro")}");

            // ----- Ejercicio 6 -----
            CalcularFactorial factorial = delegate (int n)
            {
                long resultado = 1;
                for (int i = 2; i <= n; i++) resultado *= i;
                return resultado;
            };
            Console.WriteLine($"Factorial de 4 es {factorial(4)}");
            Console.WriteLine($"Factorial de 6 es {factorial(6)}");

            // ----- Ejercicio 7 -----
            ContarCaracteres contar = delegate (string s) { return s.Length; };
            Console.WriteLine($"La palabra 'mundo' tiene {contar("mundo")} caracteres");
            Console.WriteLine($"La palabra 'programa' tiene {contar("programa")} caracteres");

            // ----- Ejercicio 8 -----
            ProcesarNumero(4, delegate (int n) { return n % 2 == 0; });
            ProcesarNumero(7, delegate (int n) { return n % 2 == 0; });

            // ----- Ejercicio 9 -----
            var productos = new List<Producto>
            {
                new Producto { Nombre = "Televisor", Cantidad = 10 },
                new Producto { Nombre = "Radio", Cantidad = 3 },
                new Producto { Nombre = "Refrigerador", Cantidad = 7 }
            };
            Console.WriteLine("Productos con cantidad mayor a 5:");
            MostrarProductosFiltrados(productos, delegate (Producto p) { return p.Cantidad > 5; });

            // ----- Ejercicio 10 -----
            var empleados = new List<Empleado>
            {
                new Empleado { Nombre = "Ana", Edad = 35 },
                new Empleado { Nombre = "Pedro", Edad = 28 },
                new Empleado { Nombre = "Luis", Edad = 42 }
            };
            Console.WriteLine("Empleados mayores de 30 años:");
            FiltrarEmpleados(empleados, delegate (Empleado e) { return e.Edad > 30; });

            // ----- Ejercicio 11 -----
            var libros = new List<Libro>
            {
                new Libro { Titulo = "El Hobbit", Categoria = "Ficción" },
                new Libro { Titulo = "Breve historia del tiempo", Categoria = "Ciencia" },
                new Libro { Titulo = "Harry Potter", Categoria = "Ficción" }
            };
            Console.WriteLine("Libros de la categoría Ficción:");
            MostrarLibrosPorCategoria(libros, delegate (Libro l) { return l.Categoria == "Ficción"; });

            // ----- Ejercicio 12 -----
            var vehiculos = new List<Vehiculo>
            {
                new Vehiculo { Marca = "Toyota", Modelo = "Corolla", AnioFabricacion = 2005 },
                new Vehiculo { Marca = "Ford", Modelo = "Focus", AnioFabricacion = 2015 },
                new Vehiculo { Marca = "Honda", Modelo = "Civic", AnioFabricacion = 2008 }
            };
            Console.WriteLine("Vehículos fabricados antes de 2010:");
            MostrarVehiculosAntiguos(vehiculos, delegate (Vehiculo v) { return v.AnioFabricacion < 2010; });
        }
    }
}