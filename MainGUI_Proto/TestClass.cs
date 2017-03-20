using System.ComponentModel;


namespace MainGUI_Proto {
    internal class TestClass : INotifyPropertyChanged {

        public TestClass() {

        }

        public TestClass(string testName) {
            this.Filename = testName;

        }

        private string filename;
        public string Filename { get => filename; set => filename = value; }
       

        private bool isRunning;
        public bool IsRunning {
            get => isRunning;
            set {
                if (value != this.isRunning) {
                    this.isRunning = value;
                    OnPropertyChanged("IsRunning");
                }
            }
        }
        

        private string testResult;
        public string TestResult { get => testResult; set => testResult = value; }


        private CommonHelper helper;

        public void InitTest() {
            helper = new CommonHelper(filename);
            this.IsRunning = helper.openTargetFile(ProcessExited);
        }

        private void ProcessExited(object sender, System.EventArgs e) {
            //System.Windows.MessageBox.Show("Process wurde geschlossen");
            this.IsRunning = false;
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