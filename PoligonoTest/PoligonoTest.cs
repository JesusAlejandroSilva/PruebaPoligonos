using Microsoft.VisualStudio.TestTools.UnitTesting;
using OPPExercise;
using System;
using System.Collections.Generic;

namespace PoligonoTest
{
    [TestClass]
    public class PoligonoTest
    {
        [TestMethod]
        public void Constructor_Validar()
        {

            var vertices = new List<(double X, double Y)>
            {
                (0, 0),
                (1, 0),
                (0, 1)
            };

            // Act
            var poligono = new Poligono(vertices);

            // Assert
            Assert.IsNotNull(poligono);
            Assert.AreEqual(3, poligono.Vertices.Count);
        }

        [TestMethod]
        public void IgualdadPoligonos()
        {
            var vertices1 = new List<(double X, double Y)>
        {
            (0, 0),
            (1, 0),
            (0, 1)
        };
            var poli1 = new Poligono(vertices1);

            var vertices2 = new List<(double X, double Y)>
        {
            (0, 0),
            (1, 0),
            (0, 1)
        };
            var poli2 = new Poligono(vertices2);

 
            var area = poli1.Equals(poli2);


            Assert.IsTrue(area);
        }

        [TestMethod]
        public void DiferenciaPoligonos()
        {

            var vertices1 = new List<(double X, double Y)>
        {
            (0, 0),
            (1, 0),
            (0, 1)
        };
            var poli1 = new Poligono(vertices1);

            var vertices2 = new List<(double X, double Y)>
        {
            (0, 0),
            (1, 0),
            (1, 1)
        };
            var poli2 = new Poligono(vertices2);

            var area = poli1.Equals(poli2);

            Assert.IsFalse(area);
        }

        [TestMethod]
        public void PuntoDentro()
        {
            var vertices = new List<(double X, double Y)>
        {
            (0, 0),
            (1, 0),
            (0, 1)
        };
            var polygon = new Polygon(vertices);

            // Act
            var isInside = polygon.PuntoDentro(0.5, 0.5);

            // Assert
            Assert.IsTrue(isInside);
        }

        [TestMethod]
        public void PuntoDentro()
        {
            // Arrange
            var vertices = new List<(double X, double Y)>
        {
            (0, 0),
            (1, 0),
            (0, 1)
        };
            var polygon = new Polygon(vertices);

            // Act
            var isInside = polygon.PuntoDentro(1.5, 1.5);

            // Assert
            Assert.IsFalse(isInside);
        }
    }

}
