using System;
namespace FivesRecordingSuite {
    
    public class CameraControl { //handles controlling settings for camera recording
        
        public static int cameraFPS = 30; //seems to be most reliable at 30fps, but settings up to 90 produce video (some frames may be duplicated, not sure if changing this setting actually changes hardware shutter rate)
        public static int recordTimeSeconds = 900; //15 min
        public static string baseName = "VideoRecord"; //default name of file before attaching shit to it
        public static string namingType = "numerical"; //numerical, time, date, timedate
        public static int numericalNamingIndex = 1; //where do we start if numerical
        public static string finalName = "";
        private static int bufferDefault = 30; //30 buffer = ~1 second

        public static void record() { //starts recording video
            switch (namingType) {
                case "numerical":
                    finalName = baseName+numericalNamingIndex;
                    numericalNamingIndex++;
                    break;
                case "time":
                    Console.WriteLine("Not Implemented, using base name only. WILL OVERWRITE!");
                    break;
                case "date":
                    Console.WriteLine("Not Implemented, using base name only. WILL OVERWRITE!");
                    break;
                case "timedate":
                    Console.WriteLine("Not Implemented, using base name only. WILL OVERWRITE!");
                    break;  
            }

            string baseCommand = "gst-launch-1.0 imxv4l2videosrc imx-capture-mode=0 num-buffers="+(bufferDefault*recordTimeSeconds)+" ! videorate ! video/x-raw,framerate="+cameraFPS+"/1 !  jpegenc ! avimux ! filesink location="+finalName+".avi";
            Console.WriteLine("Attempting to Record...");
            string returnData = SystemControl.ExecuteCommand(baseCommand);
            //Console.WriteLine(returnData);
        }
    }
}
