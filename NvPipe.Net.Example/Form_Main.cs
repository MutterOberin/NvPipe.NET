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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NvPipe.Net.Example
{
    public partial class Form_Main : Form
    {
        private bool created_encoder;
        private bool created_decoder;

        private string error_message;

        private IntPtr nvp;

        public Form_Main()
        {
            InitializeComponent();

            Console.WriteLine("Wrapper Version: " + NvPipe.Version().ToString());

            this.NvPipe_Init();
            this.NvPipe_Destroy();
        }

        private void NvPipe_Init()
        {
            this.nvp = NvPipe.NvPipe_CreateEncoder(NvPipe_Format.NvPipe_BGRA32, NvPipe_Codec.NvPipe_H264, NvPipe_Compression.NvPipe_LOSSY, 32 * 1000 * 1000, 24);

            error_message = NvPipe.NvPipe_GetError(this.nvp);

            if (error_message.Contains("Error"))
            {
                Pnl_Info.BackColor = Color.LightCoral;
            }
            else
            {
                Pnl_Info.BackColor = SystemColors.ControlDark;
            }

            this.Lbl_ErrorMessage.Text = error_message;

            Console.WriteLine("Init: Error: " + error_message);
        }

        private void NvPipe_Destroy()
        {
            NvPipe.NvPipe_Destroy(this.nvp);
        }
    }
}
