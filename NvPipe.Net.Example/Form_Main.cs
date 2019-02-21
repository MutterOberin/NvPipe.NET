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
