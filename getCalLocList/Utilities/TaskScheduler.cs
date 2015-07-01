using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.TaskScheduler;
using System.Reflection;

namespace Utilities
{
    public class TaskScheduler
    {
        
        public static void AddTask( string _title,  string _arguments,  string _description )
        {
            string file  =Assembly.GetExecutingAssembly().CodeBase;
            string path = System.IO.Path.GetDirectoryName(file);
            file = System.IO.Path.GetFileName(file);
            AddTask(file, path, _title, _arguments, _description);
        }

        public static void AddTask( string _file, string _workingdir, string _title, string _arguments, string _description )
        {
            try
            {
                // Get the service on the local machine
                using (TaskService ts = new TaskService())
                {
                    // Create a new task definition and assign properties
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = _description;

                    // Create a trigger that will fire the task at this time every other day
                    td.Triggers.Add(new DailyTrigger { DaysInterval = 7 });

                    // Create an action that will launch Notepad whenever the trigger fires
                    td.Actions.Add(new ExecAction(_file, _arguments, _workingdir));

                    // Register the task in the root folder
                    ts.RootFolder.RegisterTaskDefinition(_title, td);
                }
            }
            catch (Exception e)
            {
                Logging.Log(e, "Error occurred on creating TaskScheduler Task!");
            }
        }

        public static void RemoveTask(string _title)
        {
            try
            {
                // Get the service on the local machine
                using (TaskService ts = new TaskService())
                {
                    // Remove the task we just created
                    ts.RootFolder.DeleteTask(_title);
                }
            }
            catch (Exception e)
            {
                Logging.Log(e, "Error occurred on removing TaskScheduler Task!");
            }
        }
    }
}
