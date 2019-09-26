
## Getting Started
- Install Unity (using 2018.2.8f1)
- Download and compile `OpenCV 4.1.2` from https://opencv.org/
- Download and compile `Dlib 19.17` from http://dlib.net/

- Follow the directions at https://github.com/NeuralVFX/realtime-head-pose-open-cv/ to compile `head-pose-opencv.dll` (Using the included might not work on all systems)

- Clone this repo:

```bash
git clone https://github.com/NeuralVFX/unity-head-pose-example.git
```

## Setting Up Plugin

#### Plugin DLLs
- Copy `.dll` files from `OpenCV` `Bin` folder into `unity-head-pose-example\Assets\Plugins`
- Copy `head-pose-opencv.dll` into  `unity-head-pose-example\Assets\Plugins`
#### Models
- Download the `SSD` and `Landmark Detection` models and place into `unity-head-pose-example`

| **Model**                    | **Link**                                  |
|------------------------------|--------------------------------------------|
| `Face Detection SSD Meta`                   | [deploy.prototxt](https://github.com/spmallick/learnopencv/blob/master/FaceDetectionComparison/models/deploy.prototxt) |
| `Face Detection SSD Model`                  |    [res10_300x300_ssd_iter_140000_fp16.caffemodel](https://github.com/spmallick/learnopencv/raw/master/FaceDetectionComparison/models/res10_300x300_ssd_iter_140000_fp16.caffemodel)                                        |
| `Landmark Detection Model`     |      [shape_predictor_68_face_landmarks.dat](https://github.com/italojs/facial-landmarks-recognition-/blob/master/shape_predictor_68_face_landmarks.dat)|

## Usage
- Open `unity-head-pose-example` as a Unity project
- Within the project, open the scene `\Assets\Scenes\SampleScene.unity`
- Press Play, and the Bull should snap to your face

## Included Scripts Usage


| **Component Script**         | **Purpose**                                                        |  **Usage**             |
|------------------------------|--------------------------------------------------------------------|-------------------------|
| `OpenCVFaceDetection.cs`     |  Initiates OpenCV, performs facial detection and storage of frame. |   Add to Camera, Set `Cam Id` depending on which Camera you want to use. Set `Detect Ratio` to change fidelity of landmark detection.                      |
| `GetFrame.cs`                |  Retrieves the latest frame and assigns it as texture to object.  |   Add to background plane geo.                      |
| `GetHeadTransform.cs`      |  Retrieves the latest face transform, and applies to object.       |   Add to face object.                   |

