using System.Web;

namespace AutoDealer.Utilities.FileTools
{
    public class FilePath
    {
        #region Images Files

        public static string ImagePath = "/Images/Cars/";
        public static string ThumbImagePath = "/Images/Cars/Thumb/";
        public static string ThumbImageServerPath = HttpContext.Current.Server.MapPath("/Images/Cars/Thumb/");
        public static string ImageServerPath = HttpContext.Current.Server.MapPath("/Images/Cars/");

        #endregion
    }
}