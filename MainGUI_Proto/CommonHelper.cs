using System;
using System.ComponentModel;
using System.Diagnostics;

namespace MainGUI_Proto {
    internal class CommonHelper {

        public CommonHelper() {

        }

        public CommonHelper(string fileName) {
            this.fileName = fileName;
        }

        private string fileName;
        
      

        private ProcessStartInfo stinfo = new ProcessStartInfo();

        public bool openTargetFile(EventHandler onFileClosed) {
            bool loadedSuccessfully = false;
            stinfo.FileName = this.getTargetFilePath();
            stinfo.UseShellExecute = true;
            stinfo.CreateNoWindow = true;
            try {
                var currentProcess = Process.Start(stinfo.FileName);
                currentProcess.EnableRaisingEvents = true;
                currentProcess.Exited += onFileClosed;
                loadedSuccessfully = true;
            } catch(Exception e) {
                Console.WriteLine("failed to open file" + e.StackTrace);
            }

            return loadedSuccessfully;
        }        

        private string getTargetFilePath() {
            string targetFilePath = "";
            string currentDirectory = Environment.CurrentDirectory;
            targetFilePath = currentDirectory + "\\" + this.fileName;
            
            return targetFilePath;
        }

        public string getCurrentDirectory() {
            return Environment.CurrentDirectory;
        }



    }
}