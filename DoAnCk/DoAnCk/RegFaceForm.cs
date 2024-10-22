#region Assembly FaceRecognition, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// C:\Nam 2\faceDetection\faceDetection\bin\Debug\FaceRecognition.dll
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
namespace DoAnCk
{

    public class RegFaceForm : Form
    {
        private double distance = 1E+19;

        private CascadeClassifier CascadeClassifier = new CascadeClassifier(Environment.CurrentDirectory + "/Haarcascade/haarcascade_frontalface_alt.xml");

        private Image<Bgr, byte> Frame = null;

        private Capture camera;

        private Mat mat = new Mat();

        private List<Image<Gray, byte>> trainedFaces = new List<Image<Gray, byte>>();

        private List<int> PersonLabs = new List<int>();

        private bool isEnable_SaveImage = false;

        private string ImageName;

        private PictureBox PictureBox_Frame;

        private PictureBox PictureBox_smallFrame;

        private string setPersonName;

        public bool isTrained = false;

        private List<string> Names = new List<string>();

        private EigenFaceRecognizer eigenFaceRecognizer;

        private IContainer components = null;

        public RegFaceForm()
        {
            InitializeComponent();
            if (!Directory.Exists(Environment.CurrentDirectory + "\\Image"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\Image");
            }
        }

        public void getPersonName(Control control)
        {
            Timer timer = new Timer();
            timer.Tick += timer_getPersonName_Tick;
            timer.Interval = 100;
            timer.Start();
            void timer_getPersonName_Tick(object sender, EventArgs e)
            {
                control.Text = setPersonName;
            }
        }

        public void openCamera(PictureBox pictureBox_Camera, PictureBox pictureBox_Trained)
        {
            PictureBox_Frame = pictureBox_Camera;
            PictureBox_smallFrame = pictureBox_Trained;
            camera = new Capture();
            camera.ImageGrabbed += Camera_ImageGrabbed;
            camera.Start();
        }

        public void openCamera(PictureBox pictureBox_Camera)
        {
            PictureBox_Frame = pictureBox_Camera;
            //   PictureBox_smallFrame = pictureBox_Trained;
            camera = new Capture();
            camera.ImageGrabbed += Camera_ImageGrabbed;
            camera.Start();
        }

        public void Save_IMAGE(string imageName)
        {
            ImageName = imageName;
            isEnable_SaveImage = true;
        }

        public void Camera_ImageGrabbed(object sender, EventArgs e)
        {
            camera.Retrieve(mat);
            Frame = mat.ToImage<Bgr, byte>().Resize(PictureBox_Frame.Width, PictureBox_Frame.Height, Inter.Cubic);
            detectFace();
            PictureBox_Frame.Image = Frame.Bitmap;
        }

        private void detectFace()
        {
            Image<Bgr, byte> image = Frame.Convert<Bgr, byte>();
            Mat mat = new Mat();
            CvInvoke.CvtColor(Frame, mat, ColorConversion.Bgr2Gray);
            CvInvoke.EqualizeHist(mat, mat);
            Rectangle[] array = CascadeClassifier.DetectMultiScale(mat, 1.1, 4);
            if (array.Length != 0)
            {
                Rectangle[] array2 = array;
                foreach (Rectangle rectangle in array2)
                {
                    CvInvoke.Rectangle(Frame, rectangle, new Bgr(Color.LimeGreen).MCvScalar, 2);
                    SaveImage(rectangle);
                    image.ROI = rectangle;
                    trainedIamge();
                    checkName(image, rectangle);
                }
            }
            else
            {
                setPersonName = "";
            }
        }



        private void SaveImage(Rectangle face)
        {
            if (isEnable_SaveImage)
            {
                Image<Bgr, byte> image = Frame.Convert<Bgr, byte>();
                image.ROI = face;
                image.Resize(100, 100, Inter.Cubic).Save(Environment.CurrentDirectory + "\\Image\\" + ImageName + ".jpg");
                isEnable_SaveImage = false;
                trainedIamge();
            }
        }

        private void trainedIamge()
        {
            try
            {
                int num = 0;
                trainedFaces.Clear();
                PersonLabs.Clear();
                Names.Clear();
                string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Image", "*.jpg", SearchOption.AllDirectories);
                string[] array = files;
                foreach (string text in array)
                {
                    Image<Gray, byte> item = new Image<Gray, byte>(text);
                    trainedFaces.Add(item);
                    PersonLabs.Add(num);
                    Names.Add(text);
                    num++;
                }

                eigenFaceRecognizer = new EigenFaceRecognizer(num, distance);
                eigenFaceRecognizer.Train(trainedFaces.ToArray(), PersonLabs.ToArray());
            }
            catch
            {
            }
        }
        private double threshold = 2000.0;
        //private void checkName(Image<Bgr, byte> resultImage, Rectangle face)
        //{
        //    try
        //    {
        //        if (isTrained)
        //        {
        //            Image<Gray, byte> image = resultImage.Convert<Gray, byte>().Resize(100, 100, Inter.Cubic);
        //            CvInvoke.EqualizeHist(image, image);
        //            FaceRecognizer.PredictionResult predictionResult = eigenFaceRecognizer.Predict(image);
        //            if (predictionResult.Label != -1 && predictionResult.Distance < distance && predictionResult.Distance > threshold)
        //            {
        //                PictureBox_smallFrame.Image = trainedFaces[predictionResult.Label].Bitmap;
        //                setPersonName = Names[predictionResult.Label].Replace(Environment.CurrentDirectory + "\\Image\\", "").Replace(".jpg", "");
        //                CvInvoke.PutText(Frame, setPersonName, new Point(face.X - 2, face.Y - 2), FontFace.HersheyPlain, 1.0, new Bgr(Color.LimeGreen).MCvScalar);

        //            }
        //            else
        //            {
        //                PictureBox_smallFrame.Image = null;
        //                CvInvoke.PutText(Frame, "Unknown", new Point(face.X - 2, face.Y - 2), FontFace.HersheyPlain, 1.0, new Bgr(Color.OrangeRed).MCvScalar);

        //            }

        //        }
        //    }
        //    catch
        //    {
        //    }
        //}
        private void checkName(Image<Bgr, byte> resultImage, Rectangle face)
        {
            try
            {
                if (isTrained)
                {
                    Image<Gray, byte> image = resultImage.Convert<Gray, byte>().Resize(100, 100, Inter.Cubic);
                    CvInvoke.EqualizeHist(image, image);
                    FaceRecognizer.PredictionResult predictionResult = eigenFaceRecognizer.Predict(image);
                    if (predictionResult.Label != -1 && predictionResult.Distance < distance && predictionResult.Distance > threshold)
                    {
                        PictureBox_smallFrame.Image = trainedFaces[predictionResult.Label].Bitmap;
                        setPersonName = Names[predictionResult.Label].Replace(Environment.CurrentDirectory + "\\Image\\", "").Replace(".jpg", "");
                        //CvInvoke.PutText(Frame, setPersonName, new Point(face.X - 2, face.Y - 2), FontFace.HersheyPlain, 1.0, new Bgr(Color.LimeGreen).MCvScalar);
                    }
                    else
                    {
                        PictureBox_smallFrame.Image = null;
                        CvInvoke.Rectangle(Frame, face, new Bgr(Color.Red).MCvScalar, 2); // Vẽ hình chữ nhật màu đỏ
                        //CvInvoke.PutText(Frame, "Unknown", new Point(face.X - 2, face.Y - 2), FontFace.HersheyPlain, 1.0, new Bgr(Color.Red).MCvScalar);
                    }
                }
            }
            catch
            {
            }
        }

        public string DetectName()
        {
            Image<Bgr, byte> image = Frame.Convert<Bgr, byte>();
            Mat mat = new Mat();
            CvInvoke.CvtColor(Frame, mat, ColorConversion.Bgr2Gray);
            CvInvoke.EqualizeHist(mat, mat);
            Rectangle[] array = CascadeClassifier.DetectMultiScale(mat, 1.1, 4);

            if (array.Length != 0)
            {
                foreach (Rectangle rectangle in array)
                {
                    CvInvoke.Rectangle(Frame, rectangle, new Bgr(Color.LimeGreen).MCvScalar, 2);
                    SaveImage(rectangle);
                    image.ROI = rectangle;
                    trainedIamge();
                    checkName(image, rectangle); // Cập nhật setPersonName từ checkName
                    if (!string.IsNullOrEmpty(setPersonName))
                    {
                        return setPersonName; // Trả về ngay khi tìm thấy tên
                    }
                }
            }
            else
            {
                setPersonName = "Unknow person"; // Đặt setPersonName khi không nhận diện được khuôn mặt
            }

            return setPersonName; // Trả về setPersonName nếu không tìm thấy trong vòng lặp
        }

        public string recognizeFace()
        {
            string recognizedName = "";
            try
            {
                Mat mat = new Mat();
                CvInvoke.CvtColor(Frame, mat, ColorConversion.Bgr2Gray);
                CvInvoke.EqualizeHist(mat, mat);
                Rectangle[] array = CascadeClassifier.DetectMultiScale(mat, 1.1, 4);
                if (array.Length != 0)
                {
                    Image<Bgr, byte> image = Frame.Convert<Bgr, byte>();
                    foreach (Rectangle rectangle in array)
                    {
                        image.ROI = rectangle;
                        Image<Gray, byte> recognizedFace = image.Convert<Gray, byte>().Resize(100, 100, Inter.Cubic);
                        FaceRecognizer.PredictionResult predictionResult = eigenFaceRecognizer.Predict(recognizedFace);
                        if (predictionResult.Label != -1 && predictionResult.Distance < distance && predictionResult.Distance > threshold)
                        {
                            recognizedName = Names[predictionResult.Label].Replace(Environment.CurrentDirectory + "\\Image\\", "").Replace(".jpg", "");
                            CvInvoke.PutText(Frame, recognizedName, new Point(rectangle.X - 2, rectangle.Y - 2), FontFace.HersheyPlain, 1.0, new Bgr(Color.LimeGreen).MCvScalar);
                            break;
                        }
                    }
                }
                else
                {
                    recognizedName = "Can not recognize";
                }
            }
            catch
            {
            }
            return recognizedName;
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FaceDetect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FaceDetect";
            this.Text = "FaceRec";
            this.Load += new System.EventHandler(this.FaceDetect_Load);
            this.ResumeLayout(false);

        }

        private void FaceDetect_Load(object sender, EventArgs e)
        {

        }
    }
}
#if false // Decompilation log
'134' items in cache
------------------
Resolve: 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Found single assembly: 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Load from: 'C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\mscorlib.dll'
------------------
Resolve: 'System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Found single assembly: 'System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Load from: 'C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\System.Windows.Forms.dll'
------------------
Resolve: 'Emgu.CV.World, Version=3.1.0.2282, Culture=neutral, PublicKeyToken=7281126722ab4438'
Found single assembly: 'Emgu.CV.World, Version=3.1.0.2282, Culture=neutral, PublicKeyToken=7281126722ab4438'
Load from: 'C:\Nam 2\faceDetection\faceDetection\packages\EmguCV.3.1.0.1\lib\net30\Emgu.CV.World.dll'
------------------
Resolve: 'System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Found single assembly: 'System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Load from: 'C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\System.dll'
------------------
Resolve: 'System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Found single assembly: 'System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Load from: 'C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\System.Drawing.dll'
#endif
