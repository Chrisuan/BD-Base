using System;
using System.Collections.Generic;
using System.Globalization;
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
        

        TestClass test1 = new TestClass("ErsterTestschritt", 1);
        TestClass test2 = new TestClass("ZweiterTestschritt", 2);

        TestClass currentTest;

        int currentStep = 1;
        
        public MainWindow()
        {
            InitializeComponent();
            currentTest = test1;
            this.DataContext = currentTest;
            
        }

        private void FirstProgrammButton_Click(object sender, RoutedEventArgs e) {
            test1.InitTest();
        }

        private void NextStepButton_Click(object sender, RoutedEventArgs e) {
            //MessageBox.Show("Nächster Schritt");
            initStep2();
        }

        private void initStep2() {
            this.DataContext = test2;
            this.currentTest = test2;
            this.currentStep = 2;
        }
    }
   
}
