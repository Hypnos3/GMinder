using System;
using System.Text;

namespace Utilities
{
    public class Logging
    {
        public static void Log(string text = "", params string[] values)
        {
            Log(null, text, values);
        }

        public static void Log(Exception ex, string details = "", params string[] values)
        {
            try
            {
                // Prepare to write to the error log file
                var logMessage = new StringBuilder();

                // Prepare the timestamp
                string prefix = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss - ");
                logMessage.Append(prefix);

                if (values != null && values.Length > 0)
                    details = string.Format(details, values);

                if (!string.IsNullOrWhiteSpace(details))
                {
                    prefix = "                      ";
                    logMessage.Append(details.Replace(Environment.NewLine, prefix + Environment.NewLine));
                }

                if (ex != null)
                {
                    // Write exception message
                    LogException(prefix, logMessage, ex);
                }

                // Open the log file for writing
                OutPut.Text(logMessage.ToString());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        private static void LogException(string prefix, StringBuilder logMessage, Exception e)
        {
            logMessage.Append(prefix);
            logMessage.AppendLine(e.Message);
            if (!string.IsNullOrEmpty(e.StackTrace))
            {
                logMessage.Append(prefix);
                logMessage.AppendLine(e.StackTrace);
            }

            if (e.InnerException != null)
            {
                LogException(prefix, logMessage, e.InnerException);
            }
        }
    }
}
