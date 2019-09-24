using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class GetFrame : MonoBehaviour
{
    // Texture data
    private Texture2D tex;
    private Color32[] pixel32;

    // Pointer
    private GCHandle pixel_handle;
    private IntPtr pixel_ptr;

    void Start()
    {
        InitTexture();
        gameObject.GetComponent<Renderer>().material.mainTexture = tex;
    }

    void Update()
    {
        CVFrameToTexture();
    }

    void InitTexture()
    {
        tex = new Texture2D(512, 512, TextureFormat.ARGB32, false, false);
        pixel32 = tex.GetPixels32();
        // Pin pixel32 array
        pixel_handle = GCHandle.Alloc(pixel32, GCHandleType.Pinned);
        // Get the pinned address
        pixel_ptr = pixel_handle.AddrOfPinnedObject();
    }

    void CVFrameToTexture()
    {
        // Retreive frame
        OpenCVFaceDetection.GetFrame(pixel_ptr, tex.width, tex.height);
        // Set texture with frame data
        tex.SetPixels32(pixel32);
        tex.Apply();
    }

    void OnApplicationQuit()
    {
        // Free handle
        pixel_handle.Free();
    }
}
