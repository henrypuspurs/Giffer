using System.Collections.Generic;

namespace Giffer
{
    public class Options
    {
        public static string[] options()
        {
            string gifName = "test.gif";
            string filepath = "G:\\Users\\Henry\\Pictures\\gifs\\1";
            string destPath = "C:\\Users\\Henry\\Desktop";
            string resize = "8";
            string framerate = "25";
            var imgoptions = new string[5] { gifName, filepath, resize, framerate, destPath };
            return imgoptions;
        }
    }
}