using System;
using System.Diagnostics;

namespace FivesRecordingSuite {
    
    public class SystemControl { //will use direct command line injection to run the video record command with various settings
        
        public static string ExecuteCommand(string command) { //this little guy allows me to send commands direct to unix
            string consoleLog = "";
            try {
                Process proc = new System.Diagnostics.Process ();
                proc.StartInfo.FileName = "/bin/bash";
                proc.StartInfo.Arguments = "-c \" " + command + " \"";
                proc.StartInfo.UseShellExecute = false; 
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start ();
                while (!proc.StandardOutput.EndOfStream) {
                    consoleLog = proc.StandardOutput.ReadLine ();
                    Console.WriteLine(consoleLog);//testing to push to user in real time
                }
                return consoleLog;
            } catch (Exception e) {
                Console.WriteLine("Error sending a command: "+e);
                return "failed to execute!";
            }
        }
    }
}
