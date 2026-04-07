namespace TextGenerator.Infrastructure.EdgeAI;

public class ModelDownloader
{
    public static async Task DownloadModelIfNotExists(string url, string localPath)
    {
        if (File.Exists(localPath)) return;
        using var client = new HttpClient();
        var response = await client.GetAsync(url);
        using var fs = new FileStream(localPath, FileMode.CreateNew);
        await response.Content.CopyToAsync(fs);
    }
}