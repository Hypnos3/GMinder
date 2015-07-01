/// Copyright (c) 2009, Greg Todd
/// All rights reserved.
///
/// Redistribution and use in source and binary forms, with or without modification,
/// are permitted provided that the following conditions are met:
/// 
/// * Redistributions of source code must retain the above copyright notice,
///   this list of conditions and the following disclaimer.
///   
/// * Redistributions in binary form must reproduce the above copyright notice,
///   this list of conditions and the following disclaimer in the documentation
///   and/or other materials provided with the distribution.
///   
/// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
/// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
/// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
/// IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
/// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
/// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
/// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
/// LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE
/// OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
/// OF THE POSSIBILITY OF SUCH DAMAGE.

using System;
using System.Text;
using System.Windows.Forms;

#if DEBUG
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.IO;
#endif

namespace ReflectiveCode.GMinder
{
    /// <summary>
    /// Provides logging services
    /// </summary>
    public static class Logging
    {
        private const string ERROR_LOG = "ErrorLog.txt";
        private const string NORMAL_LOG = "Log.txt";

        [DebuggerStepThrough]
        public static void LogException( bool alert, Exception e, params string[] details )
        {
            try {
                // Prepare to write to the error log file
                var logMessage = new StringBuilder();

                // Prepare the timestamp
                string prefix = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss - ");

                // Write each detail
                foreach (string detail in details) {
                    logMessage.Append(prefix);
                    prefix = "                      ";
                    logMessage.AppendLine(detail.Replace(Environment.NewLine, prefix + Environment.NewLine));
                }

                // Write exception message
                LogException(prefix, logMessage, e);

                // Open the log file for writing
                Storage.AppendText(ERROR_LOG, logMessage.ToString());

            }
            catch (Exception ex) {
#if DEBUG
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
#endif
            }

            // Display a message box if requested
            if (alert)
                DisplayAlert(e, details);
        }

        [DebuggerStepThrough]
        private static void LogException(string prefix, StringBuilder logMessage, Exception e )
        {
#if DEBUG
            Debug.Indent();
            Debug.WriteLine(e.Message);
#endif
            logMessage.Append(prefix);
            logMessage.AppendLine(e.Message);
            if (!string.IsNullOrEmpty(e.StackTrace)) {
                logMessage.Append(prefix);
                logMessage.AppendLine(e.StackTrace);
#if DEBUG
                Debug.WriteLine(e.StackTrace);
#endif
            }

            if (e.InnerException != null) {
                LogException(prefix, logMessage, e.InnerException);
            }
#if DEBUG
            Debug.Unindent();
#endif
        }

        public static void AppendText(string text, params string[] details)
        {

            Console.WriteLine(text, details);
            using (var stream = new IsolatedStorageFileStream(NORMAL_LOG, FileMode.Append))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.WriteLine(text, details);
                    writer.Flush();
                }
            }
        }

        [DebuggerStepThrough]
        private static void DisplayAlert(Exception e, string[] details)
        {
            try {
                var errorMessage = new StringBuilder();

                // Write each detail
                foreach (string detail in details)
                    errorMessage.AppendLine(detail);

                // Write exception message
                errorMessage.AppendLine();
                errorMessage.AppendLine("Exception:");
                errorMessage.AppendLine(e.Message);

                // Display alert
                MessageBox.Show(
                    errorMessage.ToString(),
                    Properties.Resources.ErrorGenericExceptionTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex) {
#if DEBUG
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
#endif
            }
        }
    }
}