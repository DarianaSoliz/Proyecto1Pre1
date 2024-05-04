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
    class Game : GameWindow
    {

        public Escenario escenario;
        public Dictionary<string, Objeto> objeto = new Dictionary<string, Objeto>();
        public Dictionary<string, Objeto> objeto2 = new Dictionary<string, Objeto>();
        public Dictionary<string, Objeto> objeto3 = new Dictionary<string, Objeto>();

        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }


        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color4.Khaki);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            GL.Ortho(-600, 600, -600, 600, -600, 600);

            base.OnLoad(e);

        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Enable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            escenario.Dibujar();

            SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }

    }
}
