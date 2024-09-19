using OPPExercise;

class Program
{
    static void Main(string[] args)
    {

        var vertices = new List<(double X, double Y)>
        {
            (0, 0), (4, 0), (4, 3), (0, 3)
        };

        Poligono polygon = new Poligono(vertices);
        Console.WriteLine($"Área del polígono: {polygon.Area()}");
        Console.WriteLine($"Longitud del polígono: {polygon.Longitud()}");
        Console.WriteLine($"Es convexo: {polygon.ConcatAndConvex()}");

        OperacionesPolig manager = new OperacionesPolig();
        manager.InsertPoligono(polygon);

        bool puntoDentro = polygon.PuntoDentro(2, 2);  
        Console.WriteLine($"El punto (2, 2) está dentro del polígono: {puntoDentro}");

        manager.GuardarXML("poligonos.xml");
        Console.WriteLine("Polígonos guardados en poligonos.xml");

        manager.CargarXML("poligonos.xml");
        Console.WriteLine("Polígonos cargados desde poligonos.xml");
    }
}