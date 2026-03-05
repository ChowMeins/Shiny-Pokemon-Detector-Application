using OpenCvSharp;
using OpenCvSharp.WpfExtensions; // Needed for ToBitmapSource()
using System.Text;
using System.Text.RegularExpressions;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ShinyHuntDesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private VideoCapture capture;
        private Mat frame;
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            // Initialize webcam
            capture = new VideoCapture(0); // 0 = default camera
            if (!capture.IsOpened())
            {
                MessageBox.Show("Could not open webcam!");
                return;
            }

            frame = new Mat();

            // Timer to update the Image control ~30 FPS
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(33)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            capture.Read(frame);
            if (!frame.Empty())
            {
                // Update Image control
                WebcamImage.Source = frame.ToBitmapSource();
            }
        }

        // Make sure to release resources when the window closes
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            timer.Stop();
            frame.Dispose();
            capture.Release();
        }
    }
}