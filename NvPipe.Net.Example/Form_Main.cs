/* MIT License
 * Copyright(c) 2019 MutterOberin
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
 * to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
 * and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions: 
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
 * DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace NvPipe.Net.Example
{
    public partial class Form_Main : Form
    {
        private Stopwatch watch;

        private bool created_encoder;
        private bool created_decoder;

        private bool glLoaded;
        private float glAspectRatio;

        private Vector3 glCamPosCar;
        private Vector3 glCamPosCtr;
        private Vector3 glCamPosPol;

        private IntPtr nvp;

        public Form_Main()
        {
            InitializeComponent();

            Application.Idle += this.Application_Idle;

            this.watch = new Stopwatch();

            glCamPosPol.X = MathHelper.Pi / 4.0f;
            glCamPosPol.Y = MathHelper.Pi / 2.0f + MathHelper.Pi;
            glCamPosPol.Z = 15.0f;

            glCamPosCtr = Vector3.Zero;

            Console.WriteLine("Wrapper Version: " + NvPipe.Version().ToString());

            this.NvPipe_Init();
            this.NvPipe_Destroy();
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            GLControl.Invalidate();
        }

        private void NvPipe_Init()
        {
            this.nvp = NvPipe.CreateEncoder(NvPipe_Format.BGRA32, NvPipe_Codec.HEVC, NvPipe_Compression.Lossless, 32 * 1000 * 1000, 24);

            if (this.nvp == IntPtr.Zero)
            {
                string error_message = NvPipe.GetError(this.nvp);

                this.Pnl_Info.BackColor = Color.LightCoral;
                this.Lbl_Info.Text = error_message;

                Console.WriteLine("Init: Error: " + error_message);

                return;
            }
            else
            {
                this.Pnl_Info.BackColor = Color.YellowGreen;
                this.Lbl_Info.Text = "Info: Handle: " + this.nvp.ToString();
            }

            this.created_encoder = true;
        }

        private void NvPipe_Destroy()
        {
            NvPipe.Destroy(this.nvp);
        }

        private void GLControl_Load(object sender, EventArgs e)
        {
            // Background Color
            GL.ClearColor(0.227f, 0.227f, 0.227f, 1.0f);

            // Backface Culling            
            GL.Enable(EnableCap.CullFace);

            // Multisampling            
            GL.Enable(EnableCap.Multisample);

            // Line / Point Smooth            
            GL.Enable(EnableCap.PointSmooth);
            GL.Enable(EnableCap.LineSmooth);

            // Line / Point Smooth Nicest
            GL.Hint(HintTarget.PointSmoothHint, HintMode.Nicest);
            GL.Hint(HintTarget.LineSmoothHint, HintMode.Nicest);

            // Always Cull Backfaces
            GL.CullFace(CullFaceMode.Back);

            // Depth Test
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Lequal);

            // Blending Function
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            this.glLoaded = true;

            this.Setup_Viewport();
        }

        private void GLControl_Paint(object sender, PaintEventArgs e)
        {
            if (!this.glLoaded)
                return;

            this.watch.Restart();

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            this.Setup_Camera();

            GL.Color3(Color.LightCoral);

            // Not anything fancy ... just a plane
            
            #region - Plane -

            GL.Begin(PrimitiveType.LineLoop);

            GL.Vertex3(+5, +5, 0);
            GL.Vertex3(+5, -5, 0);
            GL.Vertex3(-5, -5, 0);
            GL.Vertex3(-5, +5, 0);

            GL.End();

            #endregion

            // Not anything fancy ... just a plane moving

            #region - Plane Moving UpDown -

            GL.Begin(PrimitiveType.LineLoop);

            GL.Vertex3(+3, +3, (float)Math.Sin(glCamPosPol.Y) * 3);
            GL.Vertex3(+3, -3, (float)Math.Sin(glCamPosPol.Y) * 3);
            GL.Vertex3(-3, -3, (float)Math.Sin(glCamPosPol.Y) * 3);
            GL.Vertex3(-3, +3, (float)Math.Sin(glCamPosPol.Y) * 3);

            GL.End();

            #endregion

            #region - Plane Connections -

            GL.Begin(PrimitiveType.LineLoop);

            GL.Vertex3(+3, +3, 0);
            GL.Vertex3(+3, -3, 0);
            GL.Vertex3(-3, -3, 0);
            GL.Vertex3(-3, +3, 0);

            GL.End();

            GL.Begin(PrimitiveType.Lines);

            GL.Vertex3(+3, +3, 0);
            GL.Vertex3(+3, +3, (float)Math.Sin(glCamPosPol.Y) * 3);

            GL.Vertex3(+3, -3, 0);
            GL.Vertex3(+3, -3, (float)Math.Sin(glCamPosPol.Y) * 3);

            GL.Vertex3(-3, -3, 0);
            GL.Vertex3(-3, -3, (float)Math.Sin(glCamPosPol.Y) * 3);

            GL.Vertex3(-3, +3, 0);
            GL.Vertex3(-3, +3, (float)Math.Sin(glCamPosPol.Y) * 3);

            GL.Vertex3(+5, +5, 0);
            GL.Vertex3(+3, +3, 0);

            GL.Vertex3(+5, -5, 0);
            GL.Vertex3(+3, -3, 0);

            GL.Vertex3(-5, -5, 0);
            GL.Vertex3(-3, -3, 0);

            GL.Vertex3(-5, +5, 0);
            GL.Vertex3(-3, +3, 0);

            GL.End();

            #endregion

            // Temp
            this.glCamPosPol.Y += 0.0004f;

            if (this.glCamPosPol.Y > MathHelper.Pi * 2.0f)
                this.glCamPosPol.Y = 0;

            // Blocks until GL Calls are finished
            GL.Finish();

            this.watch.Stop();

            // FPS Counter
            //this.glFrameTime += watch.ElapsedTicks;
            //this.glFrameCount += 1;

            this.GLControl.SwapBuffers();
        }

        private void GLControl_Resize(object sender, EventArgs e)
        {
            if (!this.glLoaded)
                return;

            this.Setup_Viewport();
        }

        private void Setup_Viewport()
        {
            int w = GLControl.ClientSize.Width;
            int h = GLControl.ClientSize.Height;

            this.glAspectRatio = (float)w / (float)h;

            GL.Viewport(0, 0, w, h);
        }

        private void Setup_Camera()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            Matrix4 proj = Matrix4.CreatePerspectiveFieldOfView((float)(Math.PI / 3), this.glAspectRatio, 1, 1000);

            GL.MultMatrix(ref proj);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            // Calculate from Polar Coordinates
            ToCartesian(ref this.glCamPosPol, out this.glCamPosCar);

            // Shift by Center
            this.glCamPosCar += this.glCamPosCtr;

            // Create LookAt
            Matrix4 lookAt = Matrix4.LookAt(this.glCamPosCar.X,
                                            this.glCamPosCar.Y,
                                            this.glCamPosCar.Z,
                                            this.glCamPosCtr.X,
                                            this.glCamPosCtr.Y,
                                            this.glCamPosCtr.Z,
                                            0, 0, 1);

            GL.MultMatrix(ref lookAt);
        }

        public static void ToCartesian(ref Vector3 polar, out Vector3 output)
        {
            output.X = (float)(polar.Z * Math.Sin(polar.X) * Math.Cos(polar.Y));
            output.Y = (float)(polar.Z * Math.Sin(polar.X) * Math.Sin(polar.Y));
            output.Z = (float)(polar.Z * Math.Cos(polar.X));
        }
    }
}
