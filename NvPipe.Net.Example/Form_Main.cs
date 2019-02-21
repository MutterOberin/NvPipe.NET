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
        public Form_Main()
        {
            InitializeComponent();

            // Init
            Console.WriteLine("Init: Version: " + NvPipe.Version().ToString());

            IntPtr nvp = NvPipe.NvPipe_CreateEncoder(NvPipe_Format.NvPipe_BGRA32, NvPipe_Codec.NvPipe_H264, NvPipe_Compression.NvPipe_LOSSY, 32 * 1000 * 1000, 24);

            Console.WriteLine("Init: Error: " + NvPipe.NvPipe_GetError(nvp));

            NvPipe.NvPipe_Destroy(nvp);
        }
    }
}
