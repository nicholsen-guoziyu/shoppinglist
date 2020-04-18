using System;

namespace ShoppingList.Core.Web.Image
{
    public static class ImageHelper
    {
        public static string GetContentType(string fileExtension)
        {
            switch(fileExtension)
            {
                case ".jpg":
                case ".jpeg":
                default:
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                case ".bmp":
                    return "image/bmp";
            }
        }
    }
}
