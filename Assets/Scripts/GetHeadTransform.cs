
using UnityEngine;


public class GetHeadTransform : MonoBehaviour
{
    // Storage for previos frame transform
    Quaternion rotation_old;
    Vector3 position_old;

    void Start()
    {

    }

    void Update()
    {
        // Use velocity to make transform geuss
        Vector3 position_guess = Vector3.LerpUnclamped(position_old, transform.position, (float)2.0);
        Quaternion rotation_guess = Quaternion.LerpUnclamped(rotation_old, transform.rotation, (float)2.0);

        rotation_old = transform.rotation;
        position_old = transform.position;

        // Buid transform from OpenCV
        Quaternion rotation = Quaternion.LookRotation(new Vector3(OpenCVFaceDetection.rot_f.x, OpenCVFaceDetection.rot_f.y, OpenCVFaceDetection.rot_f.z),
            new Vector3(-OpenCVFaceDetection.rot_u.x, OpenCVFaceDetection.rot_u.y, OpenCVFaceDetection.rot_u.z));
        Vector3 trans = new Vector3(OpenCVFaceDetection.trans.x, -OpenCVFaceDetection.trans.y, OpenCVFaceDetection.trans.z);

        // Average the two together
        transform.position = Vector3.Lerp(position_guess, trans, .7f);
        transform.rotation = Quaternion.Lerp(rotation_guess, rotation, .7f);

    }
}