using System.ComponentModel;
using System.Diagnostics;

namespace MainGUI_Proto {
    internal class TestClass : INotifyPropertyChanged {

        public TestClass() {

        }

        public TestClass(string testName, int teststep) {
            this.Filename = testName;
            this.testStep = teststep;
        }

        private string filename;
        public string Filename { get => filename; set => filename = value; }

        private int testStep;
        public int TestStep {
            get => testStep;
            set {
                this.testStep = value;
                OnPropertyChanged("TestStep");
                OnPropertyChanged("BackButtonVisibility");
            }
        }
        
        public string BackButtonVisibility { get => this.testStep > 1 ? "Visible" : "Hidden"; }


        private bool isRunning;
        public bool IsRunning {
            get => isRunning;
            set {
                if (value != this.isRunning) {
                    this.isRunning = value;
                    OnPropertyChanged("IsRunning");
                    OnPropertyChanged("IsRunningString");
                    OnPropertyChanged("IsNotRunning");
                }
            }
        }

        //Workaround für enabled und disablen des Test-Starten Buttons im View
        public bool IsNotRunning { get => !(this.IsRunning);}

        private string isRunningString;
        public string IsRunningString {
            get => this.isRunning ? this.isRunningString = "Test läuft" : "Test hier starten";
        }

        

        private string testResult;
        public string TestResult {
            get {
                if(this.TestExitCode != null) {
                    if(this.TestExitCode == 0) {
                         return "Test erfolgreich abgeschlossen";
                    }
                    else {
                        return "Test fehlerhaft abgeschlossen";
                    }
                }
                else {
                    return string.Empty;
                }
            }
            set => testResult = value;
        }
        

        private int? testExitCode = null;  //Nullable int Typ
        public int? TestExitCode {
            get => testExitCode;
            set {
                if (value != this.TestExitCode) {
                    this.testExitCode = value;
                    OnPropertyChanged("TestExitCode");
                    OnPropertyChanged("TestResult");
                }
            }
        }
       

        private bool hasFinished;
        public bool HasFinished { get => hasFinished; set => hasFinished = value; }
        

        private CommonHelper helper;

        public void InitTest() {
            helper = new CommonHelper(filename);
            this.IsRunning = helper.openTargetFile(ProcessExited);
        }

        private void ProcessExited(object sender, System.EventArgs e) {
            //System.Windows.MessageBox.Show("Process wurde geschlossen");
            var p = sender as Process;
            //System.Windows.MessageBox.Show("Process wurde geschlossen mit Exit Code" + p.ExitCode);
            this.IsRunning = false;
            this.HasFinished = true;
            this.TestExitCode = p.ExitCode;
        }

        //------------------------Data-Binding Notifier-----------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        //--------------------------------------------------------------------------------------
    }
}