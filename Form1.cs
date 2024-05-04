
using HelloEscenarioRotatorio;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloEscenarioForm
{
    public partial class Form1 : Form
    {
        private Escenario escenario;
        private  Dictionary<string, Objeto> objeto = new Dictionary<string, Objeto>();

        Game game;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            escenario = new Escenario(new Vector(-100f, -100f, -100f));
            escenario.Adicionar("CUBO", CargadorJson.Cargar("../../Objetos/cubo.json"));
            escenario.Adicionar("PIRAMIDE", CargadorJson.Cargar("../../Objetos/piramide.json"));

            Thread hilo = new Thread(Ejecutar);
            hilo.Start();


            comboBox1.Items.Add("ESCENARIO");
            foreach (var objeto in escenario.ListaDeObjetos.Keys)
                comboBox1.Items.Add(objeto);

            comboBox1.SelectedIndex = 0;
            RetornarCaras();
        }

        private void Ejecutar()
        {
            game = new Game(600, 700, "LearnOpenTK");
            game.escenario = this.escenario;
            game.Run();
        }

        private void RetornarCaras()
        {
            comboBox2.Items.Clear();
            if (comboBox1.SelectedItem.ToString() == "ESCENARIO")
            {
                comboBox2.Enabled = false;
                return;
            }
            comboBox2.Enabled = true;
            comboBox2.Items.Add("OBJETO");
            foreach (var cara in escenario.GetObjeto(comboBox1.SelectedItem.ToString()).GetListaDeCaras().Keys)
            {
                comboBox2.Items.Add(cara);
            }
            comboBox2.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float x = float.Parse(textBox1.Text);
            float y = float.Parse(textBox2.Text);
            float z = float.Parse(textBox3.Text);

            if (comboBox1.SelectedItem.ToString() == "ESCENARIO")
            {
                escenario.Rotacion(x, y, z);
                return;
            }
            if (comboBox2.SelectedItem.ToString() == "OBJETO")
            {
                String llave = comboBox1.SelectedItem.ToString();
                escenario.GetObjeto(llave).Rotacion(x, y, z);
                return;
            }
            String llaveObjeto = comboBox1.SelectedItem.ToString();
            String cara = comboBox2.SelectedItem.ToString();
            Objeto objetoAuxiliar = escenario.GetObjeto(llaveObjeto);
            objetoAuxiliar.GetCara(cara).Rotacion(x, y, z);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RetornarCaras();
        }

        private void buttonTraslacion_Click(object sender, EventArgs e)
        {
            float x = float.Parse(textBox1.Text);
            float y = float.Parse(textBox2.Text);
            float z = float.Parse(textBox3.Text);

            if (comboBox1.SelectedItem.ToString() == "ESCENARIO")
            {
                escenario.Traslacion(x, y, z);
                return;
            }
            if (comboBox2.SelectedItem.ToString() == "OBJETO")
            {
                String llave = comboBox1.SelectedItem.ToString();
                escenario.GetObjeto(llave).Traslacion(x, y, z);
                return;
            }
            String llaveObjeto = comboBox1.SelectedItem.ToString();
            String cara = comboBox2.SelectedItem.ToString();
            Objeto objetoAuxiliar = escenario.GetObjeto(llaveObjeto);
            objetoAuxiliar.GetCara(cara).Traslacion(x, y, z);
        }

        private void buttonEscalacion_Click(object sender, EventArgs e)
        {
            float x = float.Parse(textBox1.Text);
            float y = float.Parse(textBox2.Text);
            float z = float.Parse(textBox3.Text);

            if (comboBox1.SelectedItem.ToString() == "ESCENARIO")
            {
                escenario.Escalacion(x, y, z);
                return;
            }
            if (comboBox2.SelectedItem.ToString() == "OBJETO")
            {
                String llave = comboBox1.SelectedItem.ToString();
                escenario.GetObjeto(llave).Escalacion(x, y, z);
                return;
            }
            String llaveObjeto = comboBox1.SelectedItem.ToString();
            String cara = comboBox2.SelectedItem.ToString();
            Objeto objetoAuxiliar = escenario.GetObjeto(llaveObjeto);
            objetoAuxiliar.GetCara(cara).Escalacion(x, y, z);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
           
        }
    }
}
