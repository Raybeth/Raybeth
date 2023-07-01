using System;
using System.IO;

namespace DatosVehiculo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Seleccione los datos del vehículo:");

            Console.WriteLine("Marcas disponibles:");
            Console.WriteLine("1. Honda");
            Console.WriteLine("2. Toyota");
            Console.Write("Marca (Ingrese el número correspondiente): ");
            int opcionMarca = int.Parse(Console.ReadLine());

            string marca;
            switch (opcionMarca)
            {
                case 1:
                    marca = "Honda";
                    break;
                case 2:
                    marca = "Toyota";
                    break;
                default:
                    Console.WriteLine("Opción no válida. Seleccionando marca predeterminada: Honda");
                    marca = "Honda";
                    break;
            }

            Console.Write("Modelo: ");
            string modelo = Console.ReadLine();

            Console.Write("Año: ");
            int año = int.Parse(Console.ReadLine());

            Console.WriteLine("Colores disponibles:");
            Console.WriteLine("1. Rojo");
            Console.WriteLine("2. Negro");
            Console.Write("Color (Ingrese el número correspondiente): ");
            int opcionColor = int.Parse(Console.ReadLine());

            string color;
            switch (opcionColor)
            {
                case 1:
                    color = "Rojo";
                    break;
                case 2:
                    color = "Negro";
                    break;
                default:
                    Console.WriteLine("Opción no válida. Seleccionando color predeterminado: Rojo");
                    color = "Rojo";
                    break;
            }

            string nombreImagen = $"{marca}_{modelo}_{año}_{color}.jpg";
            string rutaImagen = Path.Combine(Environment.CurrentDirectory, "Imagenes", nombreImagen);

            if (File.Exists(rutaImagen))
            {
                // Crear el contenido del archivo HTML
                string contenidoHtml = $@"
                    <!DOCTYPE html>
                    <html>
                    <head>
                        <title>Datos del Vehículo</title>
                    </head>
                    <body>
                        <h1>Datos del Vehículo</h1>
                        <p>Marca: {marca}</p>
                        <p>Modelo: {modelo}</p>
                        <p>Año: {año}</p>
                        <p>Color: {color}</p>
                        <img src=""Imagenes/{nombreImagen}"" alt=""Imagen del Vehículo"" />
                    </body>
                    </html>
                ";

                // Guardar el contenido en un archivo HTML
                string nombreArchivo = "datos_vehiculo.html";
                File.WriteAllText(nombreArchivo, contenidoHtml);

                Console.WriteLine($"Se ha creado el archivo {nombreArchivo} con los datos del vehículo.");
                Console.WriteLine("Presione cualquier tecla para abrir el archivo con la imagen.");
                Console.ReadKey();

                // Abrir el archivo HTML en el navegador predeterminado
                System.Diagnostics.Process.Start(nombreArchivo);
            }
            else
            {
                Console.WriteLine("No se encontró una imagen correspondiente a los datos ingresados.");
            }
        }
    }
}
