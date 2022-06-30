class Producto
{
    private string nombre;
    private DateTime fechaVencimiento;
    private float precio; //entre 1000 y 5000;
    private string tamanio;

    public string Nombre { get => nombre; set => nombre = value; }
    public DateTime FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
    public float Precio { get => precio; set => precio = value; }
    public string Tamanio { get => tamanio; set => tamanio = value; }

    public Producto()
    {
        var rnd = new Random();
        var names = new string[] { "Queso", "Jamón", "Salsa", "Galletas", "Caramelos", "Fideos", "Desodorante", "Gaseosa" };
        var sizes = new string[] { "Chico", "Mediano", "Grande" };

        nombre = names[rnd.Next(names.Length)];
        fechaVencimiento = new DateTime(rnd.Next(2022, 2033), rnd.Next(1, 13), rnd.Next(1, 29));
        precio = rnd.Next(1000, 5001);
        tamanio = sizes[rnd.Next(sizes.Length)];
    }
}
