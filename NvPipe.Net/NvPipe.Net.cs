using System;
using System.Runtime.InteropServices;

namespace NvPipe.Net
{
    /// <summary>
    /// Available video codecs in NvPipe.
    /// </summary>
    public enum NvPipe_Codec
    {    
        NvPipe_H264,
        NvPipe_HEVC
    }


    /// <summary>
    /// Compression type used for encoding. Lossless produces larger output.
    /// </summary>
    public enum NvPipe_Compression
    {
        NvPipe_LOSSY,
        NvPipe_LOSSLESS
    }


    /// <summary>
    /// Format of the input frame.
    /// </summary>
    public enum NvPipe_Format
    {
        NvPipe_BGRA32,
        NvPipe_UINT4,
        NvPipe_UINT8,
        NvPipe_UINT16,
        NvPipe_UINT32
    }

    public class NvPipe
    {

        /// <summary>
        /// Returns the Version of the wrapper for NvPipe.dll.
        /// </summary>
        public static Version Version()
        {
            return new Version(0, 1, 0);
        }

        /// <summary>
        /// Creates a new encoder instance.
        /// </summary>
        /// <param name="format">Format of input frame.</param>
        /// <param name="codec">Possible codecs are H.264 and HEVC if available.</param>
        /// <param name="compression">Lossy or lossless compression.</param>
        /// <param name="bitrate">Bitrate in bit per second, e.g., 32 * 1000 * 1000 = 32 Mbps (for lossy compression only).</param>
        /// <param name="targetFrameRate">At this frame rate the effective data rate approximately equals the bitrate (for lossy compression only).</param>
        /// <returns>null on error</returns>
        [DllImport("NvPipe.dll")]
        public static extern IntPtr NvPipe_CreateEncoder(NvPipe_Format format, NvPipe_Codec codec, NvPipe_Compression compression, ulong bitrate, uint targetFrameRate);



        /// <summary>
        /// Reconfigures the encoder with a new bitrate and target frame rate.
        /// </summary>
        /// <param name="nvp">Encoder instance.</param>
        /// <param name="bitrate">Bitrate in bit per second, e.g., 32 * 1000 * 1000 = 32 Mbps (for lossy compression only).</param>
        /// <param name="targetFrameRate">At this frame rate the effective data rate approximately equals the bitrate (for lossy compression only).</param>
        [DllImport("NvPipe.dll")]
        public static extern void NvPipe_SetBitrate(IntPtr nvp, ulong bitrate, uint targetFrameRate);


        ///// <summary>
        ///// Encodes a single frame from device or host memory.
        ///// </summary>
        ///// <param name="nvp">Encoder instance.</param>
        ///// <param name="src">Device or host memory pointer.</param>
        ///// <param name="srcPitch">Pitch of source memory.</param>
        ///// <param name="dst">Host memory pointer for compressed output.</param>
        ///// <param name="dstSize">Available space for compressed output.</param>
        ///// <param name="width">Width of input frame in pixels.</param>
        ///// <param name="height">Height of input frame in pixels.</param>
        ///// <param name="forceIFrame">Enforces an I-frame instead of a P-frame.</param>
        ///// <returns>Size of encoded data in bytes or 0 on error.</returns>
        //[DllImport("NvPipe.dll")]
        //public static extern ulong NvPipe_Encode(IntPtr nvp, void* src, ulong srcPitch, uint8_t* dst, ulong dstSize, uint width, uint height, bool forceIFrame);

        ///// <summary>
        ///// Encodes a single frame from an OpenGL texture.
        ///// </summary>
        ///// <param name="nvp">Encoder instance.</param>
        ///// <param name="texture">OpenGL texture ID.</param>
        ///// <param name="target">OpenGL texture target.</param>
        ///// <param name="dst">Host memory pointer for compressed output.</param>
        ///// <param name="dstSize">Available space for compressed output. Will be overridden by effective compressed output size.</param>
        ///// <param name="width">Width of frame in pixels.</param>
        ///// <param name="height">Height of frame in pixels.</param>
        ///// <param name="forceIFrame">Enforces an I-frame instead of a P-frame.</param>
        ///// <returns>Size of encoded data in bytes or 0 on error.</returns>
        //[DllImport("NvPipe.dll")]
        //public static extern ulong NvPipe_EncodeTexture(IntPtr nvp, uint texture, uint target, uint8_t* dst, ulong dstSize, uint width, uint height, bool forceIFrame);


        ///// <summary>
        ///// Encodes a single frame from an OpenGL pixel buffer object (PBO).
        ///// </summary>
        ///// <param name="nvp">Encoder instance.</param>
        ///// <param name="pbo">OpenGL PBO ID.</param>
        ///// <param name="dst">Host memory pointer for compressed output.</param>
        ///// <param name="dstSize">Available space for compressed output. Will be overridden by effective compressed output size.</param>
        ///// <param name="width">Width of frame in pixels.</param>
        ///// <param name="height">Height of frame in pixels.</param>
        ///// <param name="forceIFrame">Enforces an I-frame instead of a P-frame.</param>
        ///// <returns>Size of encoded data in bytes or 0 on error.</returns>
        //[DllImport("NvPipe.dll")]
        //public static extern ulong NvPipe_EncodePBO(IntPtr nvp, uint pbo, uint8_t* dst, ulong dstSize, uint width, uint height, bool forceIFrame);


        ///// <summary>
        ///// Creates a new decoder instance.
        ///// </summary>
        ///// <param name="format">Format of output frame.</param>
        ///// <param name="codec">Possible codecs are H.264 and HEVC if available.</param>
        ///// <returns>NULL on error.</returns>
        //[DllImport("NvPipe.dll")]
        //public static extern IntPtr NvPipe_CreateDecoder(NvPipe_Format format, NvPipe_Codec codec);


        ///// <summary>
        ///// Decodes a single frame to device or host memory.
        ///// </summary>
        ///// <param name="nvp">Decoder instance.</param>
        ///// <param name="src">Compressed frame data in host memory.</param>
        ///// <param name="srcSize">Size of compressed data.</param>
        ///// <param name="dst">Device or host memory pointer.</param>
        ///// <param name="width">Width of frame in pixels.</param>
        ///// <param name="height">Height of frame in pixels.</param>
        ///// <returns>Size of decoded data in bytes or 0 on error.</returns>
        //[DllImport("NvPipe.dll")]
        //public static extern ulong NvPipe_Decode(IntPtr nvp, uint8_t* src, ulong srcSize, void* dst, uint width, uint height);

        ///// <summary>
        ///// Decodes a single frame to an OpenGL texture.
        ///// </summary>
        ///// <param name="nvp">Decoder instance.</param>
        ///// <param name="src">Compressed frame data in host memory.</param>
        ///// <param name="srcSize">Size of compressed data.</param>
        ///// <param name="texture">OpenGL texture ID.</param>
        ///// <param name="target">OpenGL texture target.</param>
        ///// <param name="width">Width of frame in pixels.</param>
        ///// <param name="height">Height of frame in pixels.</param>
        ///// <returns>Size of decoded data in bytes or 0 on error.</returns>
        //[DllImport("NvPipe.dll")]
        //public static extern ulong NvPipe_DecodeTexture(IntPtr nvp, uint8_t* src, ulong srcSize, uint texture, uint target, uint width, uint height);


        ///// <summary>
        ///// Decodes a single frame to an OpenGL pixel buffer object (PBO).
        ///// </summary>
        ///// <param name="nvp">Decoder instance.</param>
        ///// <param name="src">Compressed frame data in host memory.</param>
        ///// <param name="srcSize">Size of compressed data.</param>
        ///// <param name="pbo">OpenGL PBO ID.</param>
        ///// <param name="width">Width of frame in pixels.</param>
        ///// <param name="height">Height of frame in pixels.</param>
        ///// <returns>Size of decoded data in bytes or 0 on error.</returns>
        //[DllImport("NvPipe.dll")]
        //public static extern ulong NvPipe_DecodePBO(IntPtr nvp, uint8_t* src, ulong srcSize, uint pbo, uint width, uint height);




        /// <summary>
        /// Cleans up an encoder or decoder instance.
        /// </summary>
        /// <param name="nvp">The encoder or decoder instance to destroy.</param>
        [DllImport("NvPipe.dll")]
        public static extern void NvPipe_Destroy(IntPtr nvp);


        /// <summary>
        /// Returns an error message for the last error that occured.
        /// </summary>
        /// <param name="nvp">Encoder or decoder. Use NULL to get error message if encoder or decoder creation failed.</param>
        /// <returns>Returned string must not be deleted.</returns>
        [DllImport("NvPipe.dll")]
        public static extern string NvPipe_GetError(IntPtr nvp);        
    }
}
