namespace IndexadorJSON // Note: actual namespace depends on the project name.
{
    public class IndexArchivos
    {
        private int numero;
        private string nombre;
        private string extension;

        public int Numero { get => numero; set => numero = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Extension { get => extension; set => extension = value; }


        public IndexArchivos(int num, string name, string ext)
        {
            numero = num;
            nombre = name;
            extension = ext;
        }
        public IndexArchivos()
        {

        }
    }
}