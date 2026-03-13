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
        WebcamService webcamService;
        MainViewModel mainViewModel;
        public MainWindow() // Constructor
        {
            InitializeComponent();

            mainViewModel = new MainViewModel();
            DataContext = mainViewModel;

            // Initialize webcam
            webcamService = new WebcamService();
            webcamService.Start();
            webcamService.FrameReady += OnFrameReady; // Run OnFrameReady when invoked
        }
        private void OnFrameReady(BitmapSource bitmap)
        {
            Dispatcher.Invoke(() => mainViewModel.CurrentFrame = bitmap);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}