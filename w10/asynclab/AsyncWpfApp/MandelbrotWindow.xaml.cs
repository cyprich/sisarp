using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AsyncWpfApp
{
    /// <summary>
    /// Interaction logic for MandelbrotWindow.xaml
    /// </summary>
    public partial class MandelbrotWindow : Window
    {
        private const int MaxIterations = 100;

        // Koordináty komplexnej roviny
        private double xmin = -2.5, xmax = 1.0;
        private double ymin = -1.5, ymax = 1.5;

        private Point? lastDragPoint = null;

        public MandelbrotWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(DrawMandelbrot), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DrawMandelbrot();
        }

        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Point mousePos = e.GetPosition(ImageCanvas);

            double relativeX = mousePos.X / ImageCanvas.ActualWidth;
            double relativeY = mousePos.Y / ImageCanvas.ActualHeight;

            double xCenter = xmin + (xmax - xmin) * relativeX;
            double yCenter = ymin + (ymax - ymin) * relativeY;

            double zoomFactor = e.Delta > 0 ? 0.8 : 1.25;

            double newWidth = (xmax - xmin) * zoomFactor;
            double newHeight = (ymax - ymin) * zoomFactor;

            xmin = xCenter - newWidth * relativeX;
            xmax = xmin + newWidth;
            ymin = yCenter - newHeight * relativeY;
            ymax = ymin + newHeight;

            DrawMandelbrot();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lastDragPoint = e.GetPosition(this);
            Cursor = Cursors.Hand;
            CaptureMouse();
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            lastDragPoint = null;
            Cursor = Cursors.Arrow;
            ReleaseMouseCapture();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (lastDragPoint.HasValue && e.LeftButton == MouseButtonState.Pressed)
            {
                Point pos = e.GetPosition(this);
                double dx = pos.X - lastDragPoint.Value.X;
                double dy = pos.Y - lastDragPoint.Value.Y;

                int width = (int)this.ActualWidth;
                int height = (int)this.ActualHeight;

                double deltaX = (xmax - xmin) * dx / width;
                double deltaY = (ymax - ymin) * dy / height;

                xmin -= deltaX;
                xmax -= deltaX;
                ymin -= deltaY;
                ymax -= deltaY;

                lastDragPoint = pos;
                DrawMandelbrot();
            }
        }

        // TODO: Prerobte, aby sa vykonávalo paralelne
        private void DrawMandelbrot()
        {
            int width = (int)this.ActualWidth;
            int height = (int)this.ActualHeight;

            if (width <= 1 || height <= 1)
                return;

            WriteableBitmap bitmap = new(width, height, 96, 96, PixelFormats.Bgra32, null);
            int[] pixels = new int[width * height];

            Parallel.For(0, height, py =>
            {
                Parallel.For(0, width, px =>
                {
                    double x0 = xmin + px * (xmax - xmin) / (width - 1);
                    double y0 = ymin + py * (ymax - ymin) / (height - 1);

                    double x = 0, y = 0;
                    int iteration = 0;

                    while (x * x + y * y <= 4 && iteration < MaxIterations)
                    {
                        double xtemp = x * x - y * y + x0;
                        y = 2 * x * y + y0;
                        x = xtemp;
                        iteration++;
                    }

                    int color;
                    if (iteration == MaxIterations)
                    {
                        color = (255 << 24); // čierna
                    }
                    else
                    {
                        int r = (iteration * 9) % 256;
                        int g = (iteration * 7) % 256;
                        int b = (iteration * 5) % 256;
                        color = (255 << 24) | (r << 16) | (g << 8) | b;
                    }

                    pixels[py * width + px] = color;
                });
            });

            bitmap.WritePixels(new Int32Rect(0, 0, width, height), pixels, width * 4, 0);
            ImageCanvas.Source = bitmap;
        }
    }
}
