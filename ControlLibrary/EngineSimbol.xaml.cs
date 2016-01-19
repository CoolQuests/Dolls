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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlLibrary
{
    /// <summary>
    /// Interaction logic for EngineSimbol.xaml
    /// </summary>
    public partial class EngineSimbol : Image
    {
        public static readonly DependencyProperty FillProperty = DependencyProperty.Register(
            "Fill", typeof (Brush), typeof (EngineSimbol), new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        public Brush Fill
        {
            get { return (Brush) GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        public static readonly DependencyProperty BorderFillProperty = DependencyProperty.Register(
            "BorderFill", typeof(Brush), typeof(EngineSimbol), new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        public Brush BorderFill
        {
            get { return (Brush) GetValue(BorderFillProperty); }
            set { SetValue(BorderFillProperty, value); }
        }

        public EngineSimbol()
        {
            InitializeComponent();
        }
    }
}
