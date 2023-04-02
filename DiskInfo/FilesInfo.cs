namespace DiskInfo;

public static class FilesInfo
{
    public static string[] GetDisks()
    {
        return DriveInfo.GetDrives().Select(x => x.Name).ToArray();
    }
    
    public static string[] GetFiles(string path)
    {
        return Directory.GetFiles(path);
    }
    
    public static string[] GetFilesByExtension(string path, string extension)
    {
        return Directory.GetFiles(path, extension);
    }
    
    public static string[] GetAllFiles(string path)
    {
        return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
    }
    
    public static double GetFolderSize(string path)
    {
       return (double)new DirectoryInfo(path).EnumerateFiles("*").Sum(x => x.Length) * 1e-9;
    }
    
    public static double GetFolderSizeAll(string path)
    {
        return (double)new DirectoryInfo(path).EnumerateFiles("*", SearchOption.AllDirectories).Sum(x => x.Length) * 1e-9;
    }
    
    public static int GetFolderCount(string path)
    {
        return (int)new DirectoryInfo(path).EnumerateFiles("*", SearchOption.AllDirectories).Count();
    }
    
    public static void PrintDirectoryTree(string path, string prefix = "")
    {
        Console.WriteLine(prefix + Path.GetFileName(path) + "/");
        prefix += "  ";

        try
        {
            foreach (string subPath in Directory.GetDirectories(path))
            {
                PrintDirectoryTree(subPath, prefix);
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine(prefix + "Access to this directory is denied.");
        }

        try
        {
            foreach (string file in Directory.GetFiles(path))
            {
                Console.WriteLine(prefix + Path.GetFileName(file));
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine(prefix + "Access to the files in this directory is denied.");
        }
    }

}