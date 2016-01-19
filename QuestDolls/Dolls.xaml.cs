using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuestDolls.ViewModel;

namespace QuestDolls
{
    /// <summary>
    /// Interaction logic for Dolls.xaml
    /// </summary>
    public partial class Dolls : UserControl
    {
        #region Doors
        public static readonly DependencyProperty Door0Property = DependencyProperty.Register(
            "Door0", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool Door0
        {
            get { return (bool)GetValue(Door0Property); }
            set { SetValue(Door0Property, value); }
        }

        public static readonly DependencyProperty Door1Property = DependencyProperty.Register(
            "Door1", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool Door1
        {
            get { return (bool)GetValue(Door1Property); }
            set { SetValue(Door1Property, value); }
        }

        public static readonly DependencyProperty Door2Property = DependencyProperty.Register(
            "Door2", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool Door2
        {
            get { return (bool)GetValue(Door2Property); }
            set { SetValue(Door2Property, value); }
        }

        public static readonly DependencyProperty Door3Property = DependencyProperty.Register(
            "Door3", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool Door3
        {
            get { return (bool)GetValue(Door3Property); }
            set { SetValue(Door3Property, value); }
        }

        public static readonly DependencyProperty Door4Property = DependencyProperty.Register(
            "Door4", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool Door4
        {
            get { return (bool)GetValue(Door4Property); }
            set { SetValue(Door4Property, value); }
        }

        public static readonly DependencyProperty Door5Property = DependencyProperty.Register(
            "Door5", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool Door5
        {
            get { return (bool)GetValue(Door5Property); }
            set { SetValue(Door5Property, value); }
        }

        public static readonly DependencyProperty Door6Property = DependencyProperty.Register(
            "Door6", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool Door6
        {
            get { return (bool)GetValue(Door6Property); }
            set { SetValue(Door6Property, value); }
        }

        public static readonly DependencyProperty Door7Property = DependencyProperty.Register(
            "Door7", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool Door7
        {
            get { return (bool)GetValue(Door7Property); }
            set { SetValue(Door7Property, value); }
        }

        public static readonly DependencyProperty Door8Property = DependencyProperty.Register(
            "Door8", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool Door8
        {
            get { return (bool)GetValue(Door8Property); }
            set { SetValue(Door8Property, value); }
        }

        public static readonly DependencyProperty Door9Property = DependencyProperty.Register(
            "Door9", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool Door9
        {
            get { return (bool)GetValue(Door9Property); }
            set { SetValue(Door9Property, value); }
        }
        #endregion

        #region Inputs

        public static readonly DependencyProperty In00Property = DependencyProperty.Register(
            "In00", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool In00
        {
            get { return (bool)GetValue(In00Property); }
            set { SetValue(In00Property, value); }
        }

        public static readonly DependencyProperty In01Property = DependencyProperty.Register(
            "In01", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool In01
        {
            get { return (bool)GetValue(In01Property); }
            set { SetValue(In01Property, value); }
        }

        public static readonly DependencyProperty In02Property = DependencyProperty.Register(
            "In02", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool In02
        {
            get { return (bool)GetValue(In02Property); }
            set { SetValue(In02Property, value); }
        }

        public static readonly DependencyProperty In03Property = DependencyProperty.Register(
            "In03", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool In03
        {
            get { return (bool)GetValue(In03Property); }
            set { SetValue(In03Property, value); }
        }

        public static readonly DependencyProperty In04Property = DependencyProperty.Register(
            "In04", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool In04
        {
            get { return (bool)GetValue(In04Property); }
            set { SetValue(In04Property, value); }
        }

        public static readonly DependencyProperty In05Property = DependencyProperty.Register(
            "In05", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool In05
        {
            get { return (bool)GetValue(In05Property); }
            set { SetValue(In05Property, value); }
        }

        public static readonly DependencyProperty In06Property = DependencyProperty.Register(
            "In06", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool In06
        {
            get { return (bool)GetValue(In06Property); }
            set { SetValue(In06Property, value); }
        }

        public static readonly DependencyProperty In07Property = DependencyProperty.Register(
            "In07", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool In07
        {
            get { return (bool)GetValue(In07Property); }
            set { SetValue(In07Property, value); }
        }

        public static readonly DependencyProperty In08Property = DependencyProperty.Register(
            "In08", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool In08
        {
            get { return (bool)GetValue(In08Property); }
            set { SetValue(In08Property, value); }
        }

        public static readonly DependencyProperty In09Property = DependencyProperty.Register(
            "In09", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool In09
        {
            get { return (bool)GetValue(In09Property); }
            set { SetValue(In09Property, value); }
        }

        public static readonly DependencyProperty In10Property = DependencyProperty.Register(
            "In10", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool In10
        {
            get { return (bool)GetValue(In10Property); }
            set { SetValue(In10Property, value); }
        }

        public static readonly DependencyProperty In11Property = DependencyProperty.Register(
            "In11", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool In11
        {
            get { return (bool)GetValue(In11Property); }
            set { SetValue(In11Property, value); }
        }

        public static readonly DependencyProperty In12Property = DependencyProperty.Register(
            "In12", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool In12
        {
            get { return (bool)GetValue(In12Property); }
            set { SetValue(In12Property, value); }
        }

        public static readonly DependencyProperty In13Property = DependencyProperty.Register(
            "In13", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool In13
        {
            get { return (bool)GetValue(In13Property); }
            set { SetValue(In13Property, value); }
        }

        public static readonly DependencyProperty In14Property = DependencyProperty.Register(
            "In14", typeof(bool), typeof(Dolls), new PropertyMetadata(default(bool)));

        public bool In14
        {
            get { return (bool)GetValue(In14Property); }
            set { SetValue(In14Property, value); }
        }

        #endregion


        public Dolls()
        {
            InitializeComponent();
        }
    }
}
