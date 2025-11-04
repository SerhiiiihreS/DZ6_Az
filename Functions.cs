using System.Net.Mime;
using System.Reflection.Metadata;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace DZ6_Az
{
    public class Functions
    {
        /*
        public void Proccess([QueueTrigger("images")] string message, ILogger logger, 
            [Blob("big-images/{queueTrigger}", FileAccess.Read)] Stream inputImage,
            [Blob("small-images/grayscale-{queueTrigger}", FileAccess.Write)] Stream outputImage)
        {
            logger.LogWarning($"Image with name {message} was read, Lenght: {inputImage.Length} bytes");
            using (Image image = Image.Load(inputImage))
            {
                image.Mutate(x => x.Grayscale(0.8f));
                image.Save(outputImage, new PngEncoder());
                logger.LogWarning($"Image with name {message} was proccessed, Lenght: {inputImage.Length} bytes");
            }
        }
        */



        public void Proccess([QueueTrigger("images")] string message, ILogger logger,
            [Blob("original-images/{queueTrigger}", FileAccess.Read)] Stream inputImage,
            [Blob("small-images/{queueTrigger}", FileAccess.Write)] Stream outputImage)
        {
            //logger.LogWarning($"Image with name {message} was read, Lenght: {inputImage.Length} bytes");
            using (Image image = Image.Load(inputImage))
            {
                image.Mutate(x => x.Resize(200, 100));
                image.Save(outputImage, new PngEncoder());
                //logger.LogWarning($"Image with name {message} was proccessed, Lenght: {inputImage.Length} bytes");
            }
        }
    }
}
