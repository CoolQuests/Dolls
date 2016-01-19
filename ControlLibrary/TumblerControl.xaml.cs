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
    /// Interaction logic for TumblerControl.xaml
    /// </summary>
    public partial class TumblerControl : UserControl
    {
        public TumblerControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof (bool), typeof (TumblerControl), new PropertyMetadata(default(bool)));

        public bool Value
        {
            get { return (bool) GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            "Header", typeof (string), typeof (TumblerControl), new PropertyMetadata(default(string)));

        public string Header
        {
            get { return (string) GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        private void Tumblr_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            /*
             this.Dispatcher.InvokeAsync(
                Windows.UI.Core.CoreDispatcherPriority.Low,
                (s, a) => this.TheCount += 1,
                this,
                null);*/
            this.Value = !this.Value;
        }
    }
}
