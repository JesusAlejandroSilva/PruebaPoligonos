using OPPExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPoligonos
{
    public class PoligonoTest
    {
        [Fact]
        public void TestPoligonoArea()
        {
            var vertices = new List<(double X, double Y)>
        {
            (0, 0), (4, 0), (0, 3)
        };
            var polygon = new Poligono(vertices);

            Assert.Equal(6, polygon.Area(), 3);
        }

        [Fact]
        public void TestPoligonoLongitud()
        {
            var vertices = new List<(double X, double Y)>
        {
            (0, 0), (4, 0), (0, 3)
        };
            var poligono = new Poligono(vertices);
            Assert.Equal(12, poligono.Longitud(), 3);
        }

        [Fact]
        public void TestClonarPoligono()
        {

            var vertices = new List<(double X, double Y)>
        {
            (0, 0), (4, 0), (0, 3)
        };
            var polygon = new Poligono(vertices);
            var manager = new OperacionesPolig();

            manager.InsertPoligono(polygon);


            var clonedPolygon = manager.Clonar(polygon.ID);

  
            Assert.NotEqual(polygon.ID, clonedPolygon.ID);
            Assert.Equal(polygon.Area(), clonedPolygon.Area());
        }

        [Fact]
        public void TestRemoveDuplicates()
        {
            var vertices = new List<(double X, double Y)>
            {
                (0, 0), (4, 0), (0, 3)
            };

            var p1 = new Poligono(vertices);
            var p2 = new Poligono(vertices); 
            var operaciones = new OperacionesPolig();

            operaciones.InsertPoligono(p1);
            operaciones.InsertPoligono(p2);

            // Act
            operaciones.EliminarRepetidos();
        }

    }
}
