
## Getting Started
- Install Unity (using 2018.2.8f1)
- Download and compile `OpenCV 4.1.1` from https://opencv.org/
- Download and compile `Dlib 19.17` from http://dlib.net/

- Clone this repo:

```bash
git clone https://github.com/NeuralVFX/unity-head-pose-example.git
```


## Setting Up Plugin

#### Plugin DLLs
- Copy `.dll` files from `OpenCV` `Bin` folder into `unity-head-pose-example\Assets\Plugins`
#### Models
- Download the following models and place into `unity-head-pose-examle`

- [deploy.prototxt](https://github.com/spmallick/learnopencv/blob/master/FaceDetectionComparison/models/deploy.prototxt)
- [res10_300x300_ssd_iter_140000_fp16.caffemodel](https://github.com/spmallick/learnopencv/raw/master/FaceDetectionComparison/models/res10_300x300_ssd_iter_140000_fp16.caffemodel)
- [shape_predictor_68_face_landmarks.dat](https://github.com/italojs/facial-landmarks-recognition-/blob/master/shape_predictor_68_face_landmarks.dat)

## Compile
- Compile in release mode
- `head-pose-opencv.dll` will be created in the `\x64\Release` directory

## Use
- `head-pose-opencv.dll` and OpenCV and Dlib `.dll` files must be added to Unity Plugins directory
- SSD and Landmark Detection models must be downloaded and placed into the Unity project directory
- Detailed instuction for using with Unity, and an example project using `head-pose-opencv.dll` can be found here:  https://github.com/NeuralVFX/unity-head-pose-example

