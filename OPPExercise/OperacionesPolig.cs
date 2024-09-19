using System.Xml.Serialization;

namespace OPPExercise
{
    public class OperacionesPolig
    {
        #region Atributos
        private List<Poligono> poligonos;
        
        #endregion

        #region Constructor
        public OperacionesPolig()
        {
            poligonos = new List<Poligono>();
        }
        #endregion

        #region Metodo para insertar un nuevo poligono
        public void InsertPoligono(Poligono poligono)
        {
            poligonos.Add(poligono);
        }
        #endregion

        #region Metodo Para obtener un poligono por ID
        public Poligono ObtenerPoligono(Guid id)
        {
            return poligonos.FirstOrDefault(p => p.ID == id);
        }
        #endregion

        #region Metodo para eliminar un poligono por su ID
        public void EliminarPoligono(Guid id)
        {
            var poligono = ObtenerPoligono(id);
            if (poligono != null)
                poligonos.Remove(poligono);
        }
        #endregion

        #region Metodo para clonar un poligono e insertarlo con un nuevo ID
        public Poligono Clonar(Guid id)
        {
            var poligono = ObtenerPoligono(id);
            if (poligono == null)
                Console.WriteLine("Polígono no encontrado.");

            var clonar = poligono.Clonar();
            InsertPoligono(clonar);
            return clonar;
        }

        #endregion

        #region Metodo Para Obtener el area total de todos los poligonos
        public double AreaTotal()
        {
            return poligonos.Sum(a => a.Area());
        }
        #endregion

        #region Metodo para eliminar poligonos duplicados
        public void EliminarRepetidos()
        {
            var poligonoUnico = new List<Poligono>();

            foreach(var poligono in poligonos)
            {
                if(!poligonoUnico.Any(a => a.IgualdadPoligonos(poligono)))
                {
                    poligonoUnico.Add(poligono);
                }
            }
            poligonos = poligonoUnico;
        }

        #endregion

        #region Metodo para guardar los poligonos en .XML
        public void GuardarXML(string archivo)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Poligono>));
            using (StreamWriter writer = new StreamWriter(archivo))
            {
                serializer.Serialize(writer, poligonos);
            }
        }
        #endregion

        #region Metodo para cargar los poligonos en un archivo .XML
        public void CargarXML(string archivo)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Poligono>));
            using (StreamReader reader = new StreamReader(archivo))
            {
                poligonos = (List<Poligono>)serializer.Deserialize(reader);
            }
        }
        #endregion

        #region Metodo que comprueba si algun poligono en el conjunto de datos se cruza con otro
        public bool Interseccion()
        {
            for (int i = 0; i < poligonos.Count; i++)
            {
                var A = Delimitador(poligonos[i]);

                for (int j = i + 1; j < poligonos.Count; j++)
                {
                    var B = Delimitador(poligonos[j]);

                    if (CInterseccion(A, B))
                        return true;
                }
            }
            return false;
        }

        private (double minX, double minY, double maxX, double maxY) Delimitador(Poligono poligono)
        {
            double minX = poligono.Vertices.Min(v => v.x);
            double minY = poligono.Vertices.Min(v => v.y);
            double maxX = poligono.Vertices.Max(v => v.x);
            double maxY = poligono.Vertices.Max(v => v.y);
            return (minX, minY, maxX, maxY);
        }

        private bool CInterseccion((double minX, double minY, double maxX, double maxY) boxA, (double minX, double minY, double maxX, double maxY) boxB)
        {
            return !(boxA.maxX < boxB.minX || boxA.minX > boxB.maxX || boxA.maxY < boxB.minY || boxA.minY > boxB.maxY);
        }
        #endregion
    }
}
