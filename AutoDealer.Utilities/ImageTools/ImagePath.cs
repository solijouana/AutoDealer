using System.Web;

namespace AutoDealer
{
    public class ImagePath
    {
        #region Cars

        public static string Imagepath = "/Images/Cars/";
        public static string ThumbImagePath = "/Images/Cars/Thumb/";
        public static string ThumbImageServerPath = HttpContext.Current.Server.MapPath("/Images/Cars/Thumb/");
        public static string ImageServerPath = HttpContext.Current.Server.MapPath("/Images/Cars/");
        public static string NoPhoto = "/Images/Cars/";

        #endregion
    }
}