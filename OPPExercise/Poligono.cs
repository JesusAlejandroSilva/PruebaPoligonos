namespace OPPExercise
{
    public class Poligono
    {
        #region Atributos 
        public Guid ID { get;  set; }
        public List<(double x, double y)> Vertices { get;  set; }
        public double area { get; set; }  
        public double longitud { get; set; }
        #endregion

        #region Contructor sin parametros
        public Poligono()
        {
            Vertices = new List<(double X, double Y)>();
        }
        #endregion

        #region Constructor con parametros
        public Poligono(List<(double X, double Y)> vertices)
        {
            if(vertices.Count < 3)
            {
                Console.WriteLine("Un Poligono debe tener minimo 3 puntos");

            }
                ID = Guid.NewGuid();
                Vertices = vertices; 
        }
        #endregion

        #region Metodo para calcular el area de los polígono
        public double Area()
        {
            int Vn = Vertices.Count;
            area = 0;

            for (int i = 0; i < Vn; i++)
            {
                var (x1, y1) = Vertices[i];
                var (x2, y2) = Vertices[(i + 1) % Vn];
                area += x1 * y2 - x2 * y1;
            }
            return Math.Abs(area) / 2.0;
        }
        #endregion

        #region Metodo para calcular la longitud del poligono
        public double Longitud()
        {
            longitud = 0;
            int ln = Vertices.Count;

            for (int i = 0; i < ln; i++)
            {
                var (x1, y1) = Vertices[i];
                var (x2, y2) = Vertices[(i + 1) % ln];
                longitud += Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            }

            return longitud;
        }

        #endregion

        #region Metodo para validar si un poligono es convexo o concavo
        public bool ConcatAndConvex()
        {
            bool esPositivo = false;
            int n = Vertices.Count;

            for (int i = 0; i < n; i++)
            {
                var (x1, y1) = Vertices[i];
                var (x2, y2) = Vertices[(i + 1) % n];
                var (x3, y3) = Vertices[(i + 2) % n];

                var crossProduct = (x2 - x1) * (y3 - y2) - (y2 - y1) * (x3 - x2);

                if (i == 0)
                    esPositivo = crossProduct > 0;
                else if ((crossProduct > 0) != esPositivo)
                    return false;  // concavo
            }
            return true;  // convexo
        }

        #endregion

        #region Metodo para validar puntos dentro del poligono
        public bool PuntoDentro(double px, double py)
        {
            double sumaAngulos = 0;
            int n = Vertices.Count;

            for (int i = 0; i < n; i++)
            {
                var (x1, y1) = Vertices[i];
                var (x2, y2) = Vertices[(i + 1) % n];

                double dx1 = x1 - px;
                double dy1 = y1 - py;

                double dx2 = x2 - px;
                double dy2 = y2 - py;

                double angulo = Math.Atan2(dx1 * dy2 - dy1 * dx2, dx1 * dx2 + dy1 * dy2);
                sumaAngulos += angulo;
            }

            return Math.Abs(sumaAngulos) > Math.PI;
        }
        #endregion

        #region Metodo para clonar un Poligono
        public Poligono Clonar()
        {
            var cVertices = new List<(double X, double Y)>(Vertices);
            return new Poligono(cVertices);
        }
        #endregion

        #region Metodo para validar dos poligonos iguales con una tolerancia 0.001
        public bool IgualdadPoligonos(Poligono poligono)
        {
            double tolerancia = 0.001;
            if (Vertices.Count != poligono.Vertices.Count)
                return false;

            var ordenarvertices1 = Vertices.OrderBy(v => v.x).ThenBy(v => v.y).ToList();
            var ordenarvertices2 = poligono.Vertices.OrderBy(v => v.x).ThenBy(v => v.y).ToList();

            for (int i = 0; i < ordenarvertices1.Count; i++)
            {
                if (Math.Abs(ordenarvertices1[i].x - ordenarvertices2[i].x) > tolerancia ||
                    Math.Abs(ordenarvertices1[i].y - ordenarvertices2[i].y) > tolerancia)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion


    }
}
