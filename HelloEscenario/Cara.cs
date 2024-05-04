using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace HelloEscenarioRotatorio
{
    class Cara
    {
        public Dictionary<string, Vector> ListaDeVertices;
        public Color Color;
        public Vector Centro;
        public Vector vectorTraslacion = new Vector(0f, 0f, 0f);
      

        public Cara(Dictionary<string, Vector> listaDeVertices, Color color, Vector centro)
        {
            this.ListaDeVertices = listaDeVertices;
            this.Color = color;
            this.Centro = centro;
        }

        public void Adicionar(string key, Vector verticeAdicionar)
        {
            ListaDeVertices.Add(key, verticeAdicionar);
        }

        public void Eliminar(string key, Vector verticeEliminar)
        {
            ListaDeVertices.Remove(key);
        }

        public void SetCentro(Vector centro)
        {
            this.Centro = centro;
        }

        public Vector GetCentro()
        {
            return Centro;
        }

        public void Rotacion(float anguloX, float anguloY, float anguloZ)
        {
            anguloX = MathHelper.DegreesToRadians(anguloX);
            anguloY = MathHelper.DegreesToRadians(anguloY);
            anguloZ = MathHelper.DegreesToRadians(anguloZ);

            //matrizDeRotaciones = Matrix4.CreateRotationX(anguloX) * Matrix4.CreateRotationY(anguloY) * Matrix4.CreateRotationZ(anguloZ);


            foreach (var vertice in ListaDeVertices)
            {
                vertice.Value.SetVector(RotacionX(vertice.Value, anguloX));
                vertice.Value.SetVector(RotacionY(vertice.Value, anguloY));
                vertice.Value.SetVector(RotacionZ(vertice.Value, anguloZ));
            }
        }

        public Vector RotacionX(Vector vertice, float angulo)
        {
            Matrix3 matriz = Matrix3.CreateRotationX(angulo);
            return vertice * matriz;
        }

        public Vector RotacionY(Vector vertice, float angulo)
        {
            Matrix3 matriz = Matrix3.CreateRotationY(angulo);
            return vertice * matriz;
        }

        public Vector RotacionZ(Vector vertice, float angulo)
        {
            Matrix3 matriz = Matrix3.CreateRotationZ(angulo);
            return vertice * matriz;
        }

        public void Traslacion(float x, float y, float z)
        {
            //matrizDeTraslacion = Matrix4.CreateTranslation(x, y, z);
            Vector vectorTraslacion = new Vector(x, y, z);

            foreach (var vertice in ListaDeVertices)
            {
                vertice.Value.SetVector(vertice.Value + vectorTraslacion);
            }
        }

        public void Escalacion(float x, float y, float z)
        {
            //matrizDeEscalacion = Matrix4.CreateScale(x, y, z);
            Matrix3 matriz = Matrix3.CreateScale(x, y, z);
            foreach (var vertice in ListaDeVertices)
            {
                vertice.Value.SetVector(vertice.Value * matriz);
            }
        }

        public void Dibujar()
        {
            GL.Color4(Color);
            GL.Begin(PrimitiveType.Polygon);

            //matrizDeTransformacion = matrizDeRotaciones * matrizDeEscalacion * matrizDeTraslacion;

            foreach (var vertice in ListaDeVertices)
            {
                //Vector transformacion = vertice.Value * matrizDeTransformacion;
                GL.Vertex3(vertice.Value.X + Centro.X, vertice.Value.Y + Centro.Y, vertice.Value.Z + Centro.Z);
            }
            
            GL.End();
        }

    }
}
