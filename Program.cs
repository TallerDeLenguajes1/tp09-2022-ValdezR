using System.Text.Json;
namespace ListadoProductos
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string nombreJson = "productos.json";//declaro el nombre del archivo JSON de salida

            var rnd = new Random();//declaro variable random

            var listaProductos = new List<Producto>();//instacio una nueva lista de productos

            int cant = rnd.Next(1, 16);//declaro la variable cantidad y la inicializo con valor aleatorio
            Console.WriteLine($"\nCantidad de productos: {cant}");

            CreacionProductos(listaProductos, cant);//Funcion para crear productos

            string lista = Serializacion(listaProductos);//declaro una variable para la serializacion

            EscribirArchivo(nombreJson, lista);//muestro por pantalla el archivo JSON creado y cargado

            string texto = File.ReadAllText(nombreJson);//decalro una varialble donde se guardara todo el texto del archivo JSON creado en forma de string

            var info = JsonSerializer.Deserialize<List<Producto>>(texto);//varaible para volver a serializar en archivo JSON

            MostrarProductos(info);//muestro por pantalla los productos 
        }

        //FUNCIONES
        private static void MostrarProductos(List<Producto>? info)
        {
            Console.WriteLine("\nMuestra de productos:");
            foreach (var item in info)
            {
                Console.WriteLine($"\nNombre del producto: {item.Nombre}");
                Console.WriteLine($"Fecha de vencimiento: {item.FechaVencimiento}");
                Console.WriteLine($"Precio: ${item.Precio}");
                Console.WriteLine($"Tamaño: {item.Tamanio}");
            }
        }

        private static void EscribirArchivo(string nombreJson, string lista)
        {
            Console.WriteLine("\nEscribiendo archivo Json...");
            var escribir = new StreamWriter(File.Open(nombreJson, FileMode.Create));
            escribir.WriteLine(lista);
            escribir.Close();
            Console.WriteLine("Escritura exitosa");
        }

        private static string Serializacion(List<Producto> listaProductos)
        {
            Console.WriteLine("\nSerializando...");
            string lista = JsonSerializer.Serialize(listaProductos);
            Console.WriteLine("Serialización exitosa");
            return lista;
        }

        private static void CreacionProductos(List<Producto> listaProductos, int cant)
        {
            for (int i = 0; i < cant; i++)
            {
                var produ = new Producto();
                listaProductos.Add(produ);
            }
        }
    }
}