using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace HelloEscenarioRotatorio
{
    class CargadorJson
    {
        public static void Guardar(string path, Objeto objetoAGuardar)
        {
            string output = JsonConvert.SerializeObject(objetoAGuardar);
            File.WriteAllText(path, output);
        }

        public static Objeto Cargar(string path)
        {
            string output = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Objeto>(output);
        }
    }
}
