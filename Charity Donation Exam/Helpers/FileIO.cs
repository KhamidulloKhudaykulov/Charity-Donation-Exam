using Newtonsoft.Json;

namespace Charity_Donation_Exam.Helpers;

public class FileIO
{
    public static async ValueTask<List<T>> ReadAsync<T>(string path)
    {
        var content = await File.ReadAllTextAsync(path);
        if (content is null)
            return new List<T>();

        try
        {
            return JsonConvert.DeserializeObject<List<T>>(content);
        }
        catch
        {
            var json = JsonConvert.DeserializeObject<T>(content);
            var retList = new List<T>();
            retList.Add(json);
            return retList;
        }
    }

    public static async Task WriteAsync<T>(string path, List<T> values)
    {
        var json = JsonConvert.SerializeObject(values, Formatting.Indented);
        await File.WriteAllTextAsync(path, json);
    }
}
