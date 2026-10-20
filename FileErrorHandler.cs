using System;

using System.IO;

using System.Windows.Forms;

namespace boabab_ridge_wildlife_reserve

{

    public static class FileErrorHandler

    {

        public static bool TryRun(string activity, Action operation)

        {

            try

            {

                operation();

                return true;

            }

            catch (Exception ex)

            {

                Show(activity, ex);

                return false;

            }

        }

        public static void Show(string activity, Exception ex)

        {

            string message;

            if (ex is FileNotFoundException ||

                ex is DirectoryNotFoundException)

            {

                message = "A required file or folder was not found. " +

                          "Check that animals.txt exists.";

            }

            else if (ex is UnauthorizedAccessException)

            {

                message = "Access denied. Check the file permissions.";

            }

            else if (ex is IOException)

            {

                message = "The file could not be read or written. " +

                          "Check whether another program is using it.";

            }

            else

            {

                message = "An unexpected error occurred: " + ex.Message;

            }

            MessageBox.Show(

                "Could not " + activity + ".\n\n" + message,

                "Application Error",

                MessageBoxButtons.OK,

                MessageBoxIcon.Error);

        }

    }

}
