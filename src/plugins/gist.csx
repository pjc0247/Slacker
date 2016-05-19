using System.Collections.Generic;

public class Gist {
    private static readonly string Endpoint = "https://api.github.com/";

    public static void Create(
        string description,
        bool isPublic,
        Dictionary<string, string> files,
        Action<dynamic> callback)
    {
        var path = Endpoint + "gists";
        var fileList = new Dictionary<string, Dictionary<string, string>>();
        
        foreach (var file in files) {
            fileList.Add(
                file.Key,
                new Dictionary<string, string>() {
                    {"content", file.Value} 
                });
        } 
        
        var req = new Dictionary<string, object>() {
            {"description", description},
            {"public", isPublic},
            {"files", fileList}
        };
        
        Http.Post(
            path, req,
            new Dictionary<string, string>() {
                {"User-Agent", "SlackerGistClient"}
            },
            (code, body) => {
                if (code != 201)
                    callback(null);
                else
                    callback(Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(body));
            });
    }
}
