using Newtonsoft.Json;

namespace StudentManagementSystem.Persistence.Context;

public class JsonConverter
{
    public static string ToJson(object obj)
    {
        return JsonConvert.SerializeObject(obj, Formatting.Indented);
    }

    //Deserialize
    public static T FromJson<T>(string json)
    {
        return JsonConvert.DeserializeObject<T>(json);
    }
}
