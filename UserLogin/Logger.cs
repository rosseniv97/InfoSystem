using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace UserLogin
{
    static class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();
        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"
                + LoginValidation.currentUserUsername + ";"
                + LoginValidation.currentUserRole + ";"
                + activity + "\n";
            if (File.Exists("UserLogs.txt"))
            {
                File.AppendAllText("UserLogs.txt", activityLine);
               
            }
            
            currentSessionActivities.Add(activityLine);
        }
        static public void ViewLogActivity()
        {
            StreamReader reader = new StreamReader("UserLogs.txt");
            string line="";
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                Console.WriteLine(line);
            }
            reader.Close();
        }
        static public void GetCurrentSessionActivities()
        {
            StringBuilder sb = new StringBuilder();
            foreach(string line in currentSessionActivities)
            {
                sb.Append(line);
            }
            Console.Write(sb.ToString());
        }
    }
}
