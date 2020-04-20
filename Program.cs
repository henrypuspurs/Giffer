namespace Giffer
{
    class GifferMain
    {
        static void Main(string[] args)
        {
            var imgOptions = Options.options();
            var fileselect = new fileselect();
            var files = fileselect.sourceimg(imgOptions[1]);
            var imgconvert = new ImgConvert();
            imgconvert.ImgToGif(files, imgOptions);
        }
    }
}
