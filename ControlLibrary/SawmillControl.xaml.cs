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
    /// Interaction logic for SawmillControl.xaml
    /// </summary>
    public partial class SawmillControl : UserControl
    {

        public static readonly DependencyProperty In00Property = DependencyProperty.Register(
            "In00", typeof (bool), typeof (SawmillControl), new PropertyMetadata(false));

        public bool In00
        {
            get { return (bool) GetValue(In00Property); }
            set
            {
                SetValue(In00Property, value);
            }
        }

        public static readonly DependencyProperty In01Property = DependencyProperty.Register(
            "In01", typeof (bool), typeof (SawmillControl), new PropertyMetadata(default(bool)));

        public bool In01
        {
            get { return (bool) GetValue(In01Property); }
            set { SetValue(In01Property, value); }
        }

        public static readonly DependencyProperty In02Property = DependencyProperty.Register(
            "In02", typeof (bool), typeof (SawmillControl), new PropertyMetadata(default(bool)));

        public bool In02
        {
            get { return (bool) GetValue(In02Property); }
            set { SetValue(In02Property, value); }
        }

        public static readonly DependencyProperty In03Property = DependencyProperty.Register(
            "In03", typeof (bool), typeof (SawmillControl), new PropertyMetadata(default(bool)));

        public bool In03
        {
            get { return (bool) GetValue(In03Property); }
            set { SetValue(In03Property, value); }
        }

        public static readonly DependencyProperty In04Property = DependencyProperty.Register(
            "In04", typeof (bool), typeof (SawmillControl), new PropertyMetadata(default(bool)));

        public bool In04
        {
            get { return (bool) GetValue(In04Property); }
            set { SetValue(In04Property, value); }
        }

        public static readonly DependencyProperty In05Property = DependencyProperty.Register(
            "In05", typeof (bool), typeof (SawmillControl), new PropertyMetadata(default(bool)));

        public bool In05
        {
            get { return (bool) GetValue(In05Property); }
            set { SetValue(In05Property, value); }
        }

        public static readonly DependencyProperty In06Property = DependencyProperty.Register(
            "In06", typeof (bool), typeof (SawmillControl), new PropertyMetadata(default(bool)));

        public bool In06
        {
            get { return (bool) GetValue(In06Property); }
            set { SetValue(In06Property, value); }
        }

        public static readonly DependencyProperty In07Property = DependencyProperty.Register(
            "In07", typeof (bool), typeof (SawmillControl), new PropertyMetadata(default(bool)));

        public bool In07
        {
            get { return (bool) GetValue(In07Property); }
            set { SetValue(In07Property, value); }
        }

        public static readonly DependencyProperty In08Property = DependencyProperty.Register(
            "In08", typeof (bool), typeof (SawmillControl), new PropertyMetadata(default(bool)));

        public bool In08
        {
            get { return (bool) GetValue(In08Property); }
            set { SetValue(In08Property, value); }
        }

        public static readonly DependencyProperty In09Property = DependencyProperty.Register(
            "In09", typeof (bool), typeof (SawmillControl), new PropertyMetadata(default(bool)));

        public bool In09
        {
            get { return (bool) GetValue(In09Property); }
            set { SetValue(In09Property, value); }
        }

        public static readonly DependencyProperty In10Property = DependencyProperty.Register(
            "In10", typeof (bool), typeof (SawmillControl), new PropertyMetadata(default(bool)));

        public bool In10
        {
            get { return (bool) GetValue(In10Property); }
            set { SetValue(In10Property, value); }
        }

        public static readonly DependencyProperty In11Property = DependencyProperty.Register(
            "In11", typeof (bool), typeof (SawmillControl), new PropertyMetadata(default(bool)));

        public bool In11
        {
            get { return (bool) GetValue(In11Property); }
            set { SetValue(In11Property, value); }
        }

        public static readonly DependencyProperty In12Property = DependencyProperty.Register(
            "In12", typeof (bool), typeof (SawmillControl), new PropertyMetadata(default(bool)));

        public bool In12
        {
            get { return (bool) GetValue(In12Property); }
            set { SetValue(In12Property, value); }
        }

        public static readonly DependencyProperty In13Property = DependencyProperty.Register(
            "In13", typeof (bool), typeof (SawmillControl), new PropertyMetadata(default(bool)));

        public bool In13
        {
            get { return (bool) GetValue(In13Property); }
            set { SetValue(In13Property, value); }
        }

        public static readonly DependencyProperty In14Property = DependencyProperty.Register(
            "In14", typeof (bool), typeof (SawmillControl), new PropertyMetadata(default(bool)));

        public bool In14
        {
            get { return (bool) GetValue(In14Property); }
            set { SetValue(In14Property, value); }
        }

        public SawmillControl()
        {
            InitializeComponent();
        }
    }
}
