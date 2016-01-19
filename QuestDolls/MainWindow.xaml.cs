using System.Windows;
using QuestDolls.ViewModel;

namespace QuestDolls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void btnMinimaze_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Maximized)
            {
                var style = this.FindResource("MaximizeBtnStyle") as Style;
                btnMaximize.Style = style;
                this.WindowState = System.Windows.WindowState.Normal;
            }
            else
            {
                var style = this.FindResource("RestoreBtnStyle") as Style;
                btnMaximize.Style = style;
                this.WindowState = System.Windows.WindowState.Maximized;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}