
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ELearning.Commons
{
    public class ImageHandler
    {


        public ImageHandler()
        {
        }

        public static async Task SaveImageAsync(IFormFile image, string folder, string filename, IWebHostEnvironment env)
        {
            string path = env.ContentRootPath + "/wwwroot/nhacungcap/" + folder;
            if (!Directory.Exists(path))
            {
                // Create the directory.
                Directory.CreateDirectory(path);
            }

            using (var memoryStream = new MemoryStream())
            {
                await image.CopyToAsync(memoryStream);

                using (var img = Image.FromStream(memoryStream))
                {
                    int width = img.Width;
                    int height = img.Height;
                    double aspectRatio = (double)width / height;

                    if (width > height && width > 1000)
                    {
                        width = 1000;
                        height = (int)(width / aspectRatio);
                    }
                    else if (height > width && height > 1000)
                    {
                        height = 1000;
                        width = (int)(height * aspectRatio);
                    }
                    else if (width == height && width > 1000)
                    {
                        width = 1000;
                        height = 1000;
                    }

                    using (var resizedImage = new Bitmap(img, width, height))
                    {
                        resizedImage.Save(path + filename + ".jpeg", ImageFormat.Jpeg);
                    }
                }
            }

        }
    }
}

