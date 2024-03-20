using Lab01_Discrete_Math.ViewModels;
using System;
using System.Linq;
using Wpf.Ui.Controls;

namespace Lab01_Discrete_Math
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : FluentWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            OperationTypeComboBox.ItemsSource = Enum.GetValues(typeof(SetOperationType)).Cast<SetOperationType>();
        }
    }
}
