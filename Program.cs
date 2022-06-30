using System.Text.Json;
using IndexadorJSON;

Console.WriteLine("Ingrese el directorio");
int verif = 0;
string path;
do
{
    if (verif > 0)
    {
        Console.WriteLine("\nEl directorio ingresado no existe, ingrese de nuevo");
    }

    path = Console.ReadLine();
    verif++;
} while (!Directory.Exists(path));

if (Directory.GetFiles(path).Length > 0)
{
    List<string> archivos = Directory.GetFiles(path).ToList();

    Console.WriteLine("\nSerializando...");
    Console.WriteLine("\nArchivo serializado");

    int i = 1;
    var nombres = new List<IndexArchivos>();
    foreach (var item in archivos)
    {

        string arreglo = Path.GetFileNameWithoutExtension(item);
        string ext = Path.GetExtension(item);

        var cosa = new IndexArchivos(i, arreglo, ext);
        nombres.Add(cosa);//agrega a la variable nombres el valor de "cosa"
        i++;
    }

    var escribir = new StreamWriter(File.Open("index.json", FileMode.Create));
    string arc = JsonSerializer.Serialize(nombres);
    escribir.WriteLine(arc);

    escribir.Close();


    string texto = File.ReadAllText("index.json");

    Console.WriteLine(texto);

    var mostrar = JsonSerializer.Deserialize<List<IndexArchivos>>(texto);

    Console.WriteLine("\nArchivos insertados en index.json:\n");
    foreach (var item in mostrar)
    {

        Console.WriteLine("{0}, {1}, {2}", item.Numero.ToString(), item.Nombre, item.Extension);
    }

}
else
{
    Console.WriteLine("\nNo hay ningún archivo en esa carpeta");
}