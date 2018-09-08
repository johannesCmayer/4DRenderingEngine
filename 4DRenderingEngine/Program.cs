using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using OpenTK;
using OpenGL;
using System.Numerics;

namespace _4DRenderingEngine
{
    class Program : OpenTK.GameWindow
    {
        public Program program;
        public Program()
        {
            program = this;
        }

        ShaderProgram shader;

        VAO quad;
        Matrix4 projectionMatrix = Matrix4.CreateOrthographic(100, 100, 1f, 1000f);
        string vertexShader =
        @"
in vec3 in_position;
uniform mat4 projection_matrix;

void main(){
    gl_Position = vec4(in_position,0);
}
";
        string fragmentShader = @"

void main(){
    gl_FragColor = vec4(1,1,1,0.5);
}

";
        static void Main(string[] args) => new Program().Run();

        protected override void OnLoad(EventArgs e)
        {
            shader = new ShaderProgram(vertexShader, fragmentShader);
            Console.WriteLine(shader.VertexShader.ShaderLog);
            Console.WriteLine(shader.FragmentShader.ShaderLog);
            //quad = Geometry.CreateQuad(shader, new System.Numerics.Vector2(0,0), new System.Numerics.Vector2(100, 100));
            //shader["projection_matrix"].SetValue(projectionMatrix);
            VBO<Vector3> vertex = new VBO<Vector3>(new Vector3[]
            {
                new Vector3(0,0,0),
                new Vector3(1,1,0),
                new Vector3(0,1,0),
                new Vector3(1,0,0)
            });
            VBO<int> element = new VBO<int>(new int[]{
                0,1,2,0,2,3
            });
            quad = new VAO(shader, vertex, element);
            base.OnLoad(e);
        }

        protected override void OnRenderFrame(OpenTK.FrameEventArgs e)
        {
            quad.Draw();
            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(OpenTK.FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            quad.Dispose();
            shader.Dispose();
            Dispose();
        }
    }
}
