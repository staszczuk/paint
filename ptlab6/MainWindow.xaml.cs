using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ptlab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point point = new Point();
        private Brush brush = Brushes.Red;

        public MainWindow()
        {
            InitializeComponent();
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                brush = new SolidColorBrush(Color.FromRgb(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B));
            }
        }

        private void Canvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Line line = new Line()
                {
                    X1 = point.X,
                    Y1 = point.Y,
                    X2 = e.GetPosition(this).X,
                    Y2 = e.GetPosition(this).Y,
                    Stroke = brush,
                };
                point = e.GetPosition(this);
                canvas.Children.Add(line);
            }
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                point = e.GetPosition(this);
            }
        }
    }
}
