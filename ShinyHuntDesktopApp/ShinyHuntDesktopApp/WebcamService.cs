using OpenCvSharp;
using OpenCvSharp.WpfExtensions; // Needed for ToBitmapSource()
using System;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Windows.Media.Imaging;

public class WebcamService
{
	private VideoCapture videoCapture;
	private Thread thread;
	private bool running;
	private Mat currentFrame;
    public event Action<BitmapSource> FrameReady; // Declaration
    public WebcamService()
	{
		videoCapture = new VideoCapture(0);
		currentFrame = new Mat();
        thread = new Thread(CaptureLoop);
    }
	public void Start()
	{
		running = true;
		thread.Start();
	}
	public void Stop()
	{
		running = false;
		thread?.Join();
		videoCapture.Release();
	}
	private void CaptureLoop()
	{
		while (running == true)
		{
			if (videoCapture.Read(currentFrame) && !currentFrame.Empty())
			{
                BitmapSource bitmap = BitmapSourceConverter.ToBitmapSource(currentFrame);
                bitmap.Freeze(); // Required to pass across threads
				Console.WriteLine("Frame ready!");
                FrameReady?.Invoke(bitmap); // Fire the event
            }
		}
	}
}
