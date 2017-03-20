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

namespace MainGUI_Proto {
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        

        TestClass test1 = new TestClass("ErsterTestschritt");

        TestClass currentTest;
        
        public MainWindow()
        {
            InitializeComponent();
            currentTest = test1;
            this.DataContext = currentTest;
            
        }

        private void FirstProgrammButton_Click(object sender, RoutedEventArgs e) {
            test1.InitTest();
        }
    }
}
