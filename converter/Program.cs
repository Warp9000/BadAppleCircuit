using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace converter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] frames = Directory.GetFiles("../frames/");

            byte[] bytes = new byte[frames.Length * 8];

            for (int i = 0; i < frames.Length; i++)
            {
                var image = Image.Load<Rgba32>(frames[i]);

                image.Mutate(x => x.Resize(8, 8));
                image.Mutate(x => x.Grayscale());
                image.Mutate(x => x.BinaryThreshold(0.5f));
                image.Mutate(x => x.Invert());

                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {

                        var pixel = image[x, y];

                        if (pixel.R == 0)
                        {
                            bytes[i * 8 + y] |= (byte)(1 << x);
                        }
                        else
                        {
                            bytes[i * 8 + y] &= (byte)~(1 << x);
                        }
                    }
                }
            }

            File.WriteAllBytes("../frames.bin", bytes);
        }
    }
}