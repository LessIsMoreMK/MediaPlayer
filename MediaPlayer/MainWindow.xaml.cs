using System;
using System.Windows;
using System.Windows.Threading;

namespace MediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer mTimer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void VideoClipPlayHandler(object sender, RoutedEventArgs e)
        {
            videoClip.Play();
            if (mTimer != null)
                mTimer.Start();
        }
        private void VideoClipPauseHandler(object sender, RoutedEventArgs e)
        {
            videoClip.Pause();
            if (mTimer != null)
                mTimer.Stop();
        }
        private void VideoClipStopHandler(object sender, RoutedEventArgs e)
        {
            videoClip.Stop();
            if (mTimer != null)
                mTimer.Stop();
        }

        private void VideoClip_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show(e.ErrorException.Message);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            videoClip.ScrubbingEnabled = true;
            videoClip.Stop();
        }

        private void VideoClip_MediaOpened(object sender, RoutedEventArgs e)
        {
            TimeSlider.Maximum = videoClip.NaturalDuration.TimeSpan.TotalSeconds;

            mTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            mTimer.Tick += Timer_Tick;

            totalTimeOfVideo.Content = videoClip.NaturalDuration.TimeSpan.ToString();

            videoClip.Play();
            videoClip.Pause();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSlider.Value = videoClip.Position.TotalSeconds;
        }

        private void TimeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            videoClip.Position = TimeSpan.FromSeconds(TimeSlider.Value);
        }

        private void TimeSlider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            videoClip.Pause();
            if (mTimer != null)
                mTimer.Stop();

        }

        private void TimeSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            videoClip.Play();
            mTimer.Start();
        }
    }
}
