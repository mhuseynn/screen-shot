
using System.Drawing;
using System.Drawing.Imaging;

List<string> names = new List<string>(); 
string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
string imagesFolderPath = Path.Combine(desktopPath, "Images");

if (!Directory.Exists(imagesFolderPath))
{
    Directory.CreateDirectory(imagesFolderPath);
}

const int screen_width = 1920; 
const int screen_height = 1080;
static string ss_and_save(string path,List<string> names)
{
    DateTime now = DateTime.Now;
    string fileName = $"screenshot_{now:MM_dd_yyyy}.png";
    string filePath = Path.Combine(path, fileName);
    names.Add(fileName);
    using (var bitmap = new Bitmap(screen_width ,screen_height))
    {
        using (var graphics = Graphics.FromImage(bitmap))
        {
            graphics.CopyFromScreen(0, 0, 0, 0, new Size(screen_width, screen_height));
        }

        bitmap.Save(filePath, ImageFormat.Png);
    }

    return filePath;
}

static void get_files(List<string> names)
{
    Console.WriteLine("Names: ");
    foreach (var item in names)
    {
        Console.Write("File: ");
        Console.WriteLine(item);
    }
}
while (true)
{
    Console.WriteLine("Press enter for screenshot or [l] view files names or any key stop...");
    ConsoleKeyInfo key = Console.ReadKey();
    if (key.Key == ConsoleKey.Enter)
    {
        ss_and_save(imagesFolderPath,names);
        Console.WriteLine("Saved");
    }
    else if (key.Key == ConsoleKey.L)
    {
        get_files(names);
    }
    else
        break;
}