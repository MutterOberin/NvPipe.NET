﻿/* MIT License
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
using System.Reflection;
using System.Runtime.InteropServices;

using OpenTK.Graphics.OpenGL;

namespace NvPipe.Net
{
    /// <summary>
    /// Available video codecs in NvPipe.
    /// </summary>
    public enum NvPipe_Codec
    {    
        H264,
        HEVC
    }


    /// <summary>
    /// Compression type used for encoding. Lossless produces larger output.
    /// </summary>
    public enum NvPipe_Compression
    {
        Lossy,
        Lossless
    }


    /// <summary>
    /// Format of the input frame.
    /// </summary>
    public enum NvPipe_Format
    {
        BGRA32,
        uint4,
        uint8,
        uint16,
        uint32
    }


    /// <summary>
    /// Static Wrapper Class for communication with NvPipe.dll
    /// </summary>
    public static class NvPipe
    {
        /// <summary>
        /// Returns the Version of the wrapper for NvPipe.dll.
        /// </summary>
        public static Version Version()
        {
            return Assembly.GetExecutingAssembly().GetName().Version;
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
        [DllImport("NvPipe.dll", EntryPoint = "NvPipe_CreateEncoder")]
        public static extern IntPtr CreateEncoder(NvPipe_Format format, NvPipe_Codec codec, NvPipe_Compression compression, ulong bitrate, uint targetFrameRate);



        /// <summary>
        /// Reconfigures the encoder with a new bitrate and target frame rate.
        /// </summary>
        /// <param name="nvp">Encoder instance.</param>
        /// <param name="bitrate">Bitrate in bit per second, e.g., 32 * 1000 * 1000 = 32 Mbps (for lossy compression only).</param>
        /// <param name="targetFrameRate">At this frame rate the effective data rate approximately equals the bitrate (for lossy compression only).</param>
        [DllImport("NvPipe.dll", EntryPoint = "NvPipe_SetBitrate")]
        public static extern void SetBitrate(IntPtr nvp, ulong bitrate, uint targetFrameRate);


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

        /// <summary>
        /// Encodes a single frame from an OpenGL texture.
        /// </summary>
        /// <param name="nvp">Encoder instance.</param>
        /// <param name="texture">OpenGL texture ID.</param>
        /// <param name="target">OpenGL texture target.</param>
        /// <param name="dst">Host memory pointer for compressed output.</param>
        /// <param name="dstSize">Available space for compressed output. Will be overridden by effective compressed output size.</param>
        /// <param name="width">Width of frame in pixels.</param>
        /// <param name="height">Height of frame in pixels.</param>
        /// <param name="forceIFrame">Enforces an I-frame instead of a P-frame.</param>
        /// <returns>Size of encoded data in bytes or 0 on error.</returns>
        [DllImport("NvPipe.dll", EntryPoint = "NvPipe_EncodeTexture")]
        public static extern ulong EncodeTexture(IntPtr nvp, uint texture, TextureTarget target, byte[] dst, ulong dstSize, uint width, uint height, bool forceIFrame);

        /// <summary>
        /// Encodes a single frame from an OpenGL texture.
        /// </summary>
        /// <param name="nvp">Encoder instance.</param>
        /// <param name="texture">OpenGL texture ID.</param>
        /// <param name="target">OpenGL texture target.</param>
        /// <param name="dst">Host memory pointer for compressed output.</param>
        /// <param name="dstSize">Available space for compressed output. Will be overridden by effective compressed output size.</param>
        /// <param name="width">Width of frame in pixels.</param>
        /// <param name="height">Height of frame in pixels.</param>
        /// <param name="forceIFrame">Enforces an I-frame instead of a P-frame.</param>
        /// <returns>Size of encoded data in bytes or 0 on error.</returns>
        [DllImport("NvPipe.dll", EntryPoint = "NvPipe_EncodeTexture")]
        public static extern ulong EncodeTexture(IntPtr nvp, uint texture, TextureTarget target, IntPtr dst, ulong dstSize, uint width, uint height, bool forceIFrame);


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
        [DllImport("NvPipe.dll", EntryPoint = "NvPipe_Destroy")]
        public static extern void Destroy(IntPtr nvp);


        /// <summary>
        /// Returns an error message for the last error that occured.
        /// </summary>
        /// <param name="nvp">Encoder or decoder. Use NULL to get error message if encoder or decoder creation failed.</param>
        /// <returns>Returned string must not be deleted.</returns>
        [DllImport("NvPipe.dll", EntryPoint = "NvPipe_GetError")]
        public static extern string GetError(IntPtr nvp);        
    }
}
