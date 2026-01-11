using MediaService.Client.Components.Pages;

namespace MediaService.Client.Extensions;

internal static class ImageFormatExtensions
{
    extension(Home.ImageFormat format)
    {
        public string GetFileExtension()
        {
            return format switch
            {
                Home.ImageFormat.JpegXl => "jxl",
                Home.ImageFormat.WebP => "webp",
                Home.ImageFormat.Jpeg => "jpg",
                _ => throw new ArgumentOutOfRangeException(nameof(format), format, null)
            };
        }

        public int GetMinimumQuality()
        {
            return format switch
            {
                Home.ImageFormat.WebP => 0,
                Home.ImageFormat.Jpeg => 1,
                _ => throw new ArgumentOutOfRangeException(nameof(format), format, null)
            };
        }
    }
}