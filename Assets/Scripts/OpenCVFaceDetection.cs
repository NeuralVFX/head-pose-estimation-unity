using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;


internal static class OpenCVInterop
{

    [DllImport("head-pose-opencv")]
    internal static extern int Init(ref int outCameraWidth, ref int outCameraHeight);

    [DllImport("head-pose-opencv")]
    internal static extern int Close();

    [DllImport("head-pose-opencv")]
    internal static extern void GetRawImageBytes(IntPtr data, int width, int height);

    [DllImport("head-pose-opencv")]
    internal unsafe static extern void Detect(TransformData* outFaces);
}


[StructLayout(LayoutKind.Sequential, Size = 9)]
public struct TransformData
{
    public float tX, tY, tZ, rfX, rfY, rfZ, ruX, ruY, ruZ;
}


public class OpenCVFaceDetection : MonoBehaviour
{
    // Storage for retrieved data
    public static Vector3 trans { get; private set; }
    public static Vector3 rot_u { get; private set; }
    public static Vector3 rot_f { get; private set; }

    private bool _ready = false;
    private TransformData faces;

    void Start()
    {
        // Initiate Open CV Wrapper
        int cam_width = 1920, cam_height = 1080;
        int result = OpenCVInterop.Init(ref cam_width, ref cam_height);

        // Setup camera
        float vfov = 2.0f * Mathf.Atan(0.5f * cam_height / cam_width) * Mathf.Rad2Deg;
        Camera cam = Camera.main;
        cam.fieldOfView = vfov;
        cam.aspect = (float)cam_width / (float)cam_height;

        trans = new Vector3();
        rot_u = new Vector3();
        rot_f = new Vector3();
        _ready = true;
    }

    void OnApplicationQuit()
    {
        if (_ready)
        {
            OpenCVInterop.Close();
        }
    }

    void Update()
    {
        if (!_ready)
            return;

        unsafe
        {
            fixed (TransformData* outFaces = &faces)
            {
                OpenCVInterop.Detect(outFaces);
            }
        }

        trans = new Vector3(faces.tX, faces.tY, faces.tZ);
        rot_u = new Vector3(faces.ruX, faces.ruY, faces.ruZ);
        rot_f = new Vector3(faces.rfX, faces.rfY, faces.rfZ);
    }

    public static void GetFrame(IntPtr pixelPtr, int width, int height)
    {
        OpenCVInterop.GetRawImageBytes(pixelPtr, width, height);
    }
}

