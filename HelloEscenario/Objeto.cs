using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace HelloEscenarioRotatorio
{
    class Objeto
    {
        public Dictionary<string, Cara> ListaDeCaras;
        public Vector Centro;

        public Objeto(Dictionary<string, Cara> listaDeCaras, Vector centro)
        {
            this.ListaDeCaras = listaDeCaras;
            this.Centro = centro;

            foreach (var cara in ListaDeCaras)
            {
                cara.Value.Centro = Centro + cara.Value.GetCentro();
            }
        }

        public void Adicionar(string key, Cara verticeAdicionar)
        {
            ListaDeCaras.Add(key,verticeAdicionar);
        }

        public void Eliminar(string key, Cara verticeEliminar)
        {
            ListaDeCaras.Remove(key);
        }

        public void SetCentro(Vector centro)
        {
            this.Centro = centro;       
        }

        public Vector GetCentro()
        {
            return Centro;
        }

        public Cara GetCara(string key)
        {
            return ListaDeCaras[key];
        }

        public Dictionary<String, Cara> GetListaDeCaras()
        {
            return ListaDeCaras;
        }

        public void Rotacion(float x, float y, float z)
        {
            foreach (var cara in ListaDeCaras)
            {
                //cara.Value.SetCentro(Centro + cara.Value.Centro);
                cara.Value.Rotacion(x, y, z);
            }
        }

        public void Traslacion(float x, float y, float z)
        {
            foreach (var cara in ListaDeCaras)
            {
                cara.Value.Traslacion(x, y, z);
            }
        }

        public void Escalacion(float x, float y, float z)
        {
            foreach (var cara in ListaDeCaras)
            {
                cara.Value.Escalacion(x, y, z);
            }
        }
        public void Dibujar()
        {

            foreach (var cara in ListaDeCaras)
            {
                cara.Value.Dibujar();
            }
        }

    }
}
