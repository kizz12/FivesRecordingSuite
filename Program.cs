using System;

namespace FivesRecordingSuite {
    
    class MainClass {
        private static string userResponse;
        private static bool exit = false;

        public static void Main(string[] args) { //same as update
            while (!exit) {
                intro();
                userResponse = getInput();
                switch (userResponse) {
                    case "1":
                        CameraControl.record();
                        break;
                    case "2":
                        string settingChoice = "";
                        settingsMenu();
                        settingChoice = getInput();
                        handleSettings(settingChoice);

                        break;
                    case "3":
                        Console.WriteLine("Exiting!");
                        Console.Clear();
                        exit=true;
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
                if (!exit) {
                    Console.WriteLine("Press enter to continue...");
                    getInput();
                    Console.Clear();
            }
        }
    }

        public static void intro() { //intro loop for FRS
            Console.WriteLine("Welcome to the Fives Recording Suite for Udoo Quad.");
            Console.WriteLine(" ");
            Console.WriteLine("~~~~~~~~~~~~~~~Current Settings~~~~~~~~~~~~~~~");
            Console.WriteLine("Record Time: "+CameraControl.recordTimeSeconds);
            Console.WriteLine("FPS: "+CameraControl.cameraFPS);
            Console.WriteLine("Base File Name: "+CameraControl.baseName);
            Console.WriteLine(" ");
            Console.WriteLine("~~~~~~~~~~~~~~~Program Options~~~~~~~~~~~~~~~");
            Console.WriteLine("Please select an option below:");
            Console.WriteLine("1: Record Now");
            Console.WriteLine("2: Change a setting");
            Console.WriteLine("3: Exit");

        }

        public static void settingsMenu() {
            Console.WriteLine("Please choose an option to change:");
            Console.WriteLine("1. Change record time");
            Console.WriteLine("2. Change base name");
            Console.WriteLine("3. Change FPS");
            if (CameraControl.namingType == "numerical"){
                Console.WriteLine("4. Change numerical index (Current Index: "+CameraControl.numericalNamingIndex+")");
                Console.WriteLine("5. Return to main menu");
            } else {
                Console.WriteLine("4. Return to main menu");
            }

        }

        public static void handleSettings(string choice) {
            switch (choice) {
                case "1":
                    Console.WriteLine("Please enter new record duration in seconds:");
                    string newRecordTime = getInput();
                    try {
                       int checkTime = Convert.ToInt32(newRecordTime);
                        if ((checkTime>0) && (checkTime<=76800)) {
                            CameraControl.recordTimeSeconds = checkTime;
                        } else {
                            Console.WriteLine("You must insert an integer between 1 and 76800");
                        }
                    } catch (Exception) {
                        Console.WriteLine("You must insert an integer between 1 and 76800");
                    }
                    break;
                case "2":
                    Console.WriteLine("Please enter a new base file name:");
                    string newBaseName = getInput();
                    CameraControl.baseName = newBaseName;
                    Console.WriteLine("Name changed to: "+CameraControl.baseName);
                    break;
                case "3":
                    Console.WriteLine("Not implemented yet.");
                    break;
                case "4":
                    if (CameraControl.namingType == "numerical"){
                        Console.WriteLine("Please enter the desired index for the next recording");
                        string newIndex = getInput();
                        try {
                            int convertedIndex = Convert.ToInt32(newIndex);
                            CameraControl.numericalNamingIndex = convertedIndex; //no checkes needed, if user wants to start at -69 then let them be stupid.  
                        } catch (Exception) {
                            Console.WriteLine("You must insert an integer between 1 and 76800");
                        }
                    } 
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        public static string getInput() { //grabs input from user
            string userResult = Console.ReadLine();
            return userResult;
        }
    }
}
