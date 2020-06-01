using System.Web;

namespace AutoDealer.Utilities.FileTools
{
    public class FilePath
    {
        #region ImageCars Files

        public static string ImagePath = "/Images/Cars/";
        public static string ThumbImagePath = "/Images/Cars/Thumb/";
        public static string ThumbImageServerPath = HttpContext.Current.Server.MapPath("/Images/Cars/Thumb/");
        public static string ImageServerPath = HttpContext.Current.Server.MapPath("/Images/Cars/");

        #endregion

        #region BlogImage File
        public static string BlogImagePath = "/Images/Blogs/";
        public static string BlogThumbImagePath = "/Images/Blogs/Thumb/";
        public static string BlogThumbImageServerPath = HttpContext.Current.Server.MapPath("/Images/Blogs/Thumb/");
        public static string BlogImageServerPath = HttpContext.Current.Server.MapPath("/Images/Blogs/");


        #endregion
    }
}