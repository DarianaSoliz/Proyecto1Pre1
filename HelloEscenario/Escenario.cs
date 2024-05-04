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
    class Escenario
    {
        public Dictionary<string,Objeto> ListaDeObjetos;
        public Vector Centro;

        public Escenario(Vector centro)
        {
            this.Centro = centro;
            ListaDeObjetos = new Dictionary<string, Objeto>(); 

        }
        public Escenario(Dictionary<string, Objeto> listaDeObjetos, Vector centro)
        {
            this.ListaDeObjetos = listaDeObjetos;
            this.Centro = centro;

            foreach (var objeto in listaDeObjetos)
            {
                Vector nuevoCentrObjeto = objeto.Value.GetCentro() + Centro;
                objeto.Value.Centro = nuevoCentrObjeto;

                foreach (var cara in objeto.Value.ListaDeCaras)
                {
                    Vector nuevoCentroCara = cara.Value.GetCentro() + nuevoCentrObjeto;
                    cara.Value.Centro = nuevoCentroCara;

                }
            }
        }

        
        public void Adicionar(string key, Objeto escenarioAdicionar)
        {
            ListaDeObjetos.Add(key, escenarioAdicionar);
        }

        public void Eliminar(String key, Objeto escenarioEliminar)
        {
            ListaDeObjetos.Remove(key);
        }

        public Objeto GetObjeto(String key)
        {
            return ListaDeObjetos[key];
        }

        public Dictionary<String, Objeto> GetListaObjetos()
        {
            return ListaDeObjetos;
        }

        
        public void Rotacion(float x, float y, float z)
        {
            foreach(var objeto in ListaDeObjetos)
            {
                objeto.Value.Rotacion(x, y, z);
            }
        }

        public void Traslacion(float x, float y, float z)
        {
            foreach (var objeto in ListaDeObjetos)
            {
                objeto.Value.Traslacion(x, y, z);
            }
        }
        public void Escalacion(float x, float y, float z)
        {
            foreach (var objeto in ListaDeObjetos)
            {
                objeto.Value.Escalacion(x, y, z);
            }
        }
        public void Dibujar()
        {
            foreach (var objeto in ListaDeObjetos)
            {
                objeto.Value.Dibujar();
            }
        }

    }
}
