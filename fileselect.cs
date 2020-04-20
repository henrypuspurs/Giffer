using System;
using System.IO;

namespace Giffer
{
    public class fileselect
    {
        public string[] sourceimg(String filepath)
        {
            string[] sourcelist = Directory.GetFiles(filepath);
            return sourcelist;
        }
    }
}