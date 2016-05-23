using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class Jenkins
{
    public class Job
    {
        public string endpoint { get; set; }
        public string auth { get; set; }
        
        public string name { get; set; }
        public string url { get; set; }
        public string state { get; set; }    
        
        public void Build(Action<bool> callback) {
            Http.Get(
                endpoint + "/job/" + name + "/build",
                new Dictionary<string, string>() {
                    {"Authorization", "Basic " + auth }
                },
                (int code, string body) => {
                    callback?.Invoke(code == 201);
                });
        }
        public void Build(Dictionary<string, object> p, Action<bool> callback) {
            Http.Post(
                endpoint + "/job/" + name + "/buildWithParameters?jenkins_status=1&jenkins_sleep=3",
                p,
                new Dictionary<string, string>() {
                    {"Authorization", "Basic " + auth }
                },
                (int code, string body) => {
                    callback?.Invoke(code == 201);
                });
        }
    }
    
    private string endpoint { get; set; }
    private string auth { get; set; }
    
    public static Jenkins Create(string endpoint, string id, string password) {
        var jenkins = new Jenkins();
        jenkins.endpoint = endpoint;
        jenkins.auth = Convert.ToBase64String(Encoding.ASCII.GetBytes(id + ":" + password));
        return jenkins;    
    }
    
    public Job GetJob(string name) {
        return new Job() {
            endpoint = endpoint,
            auth = auth,
            name = name,
            url = "",
            state = ""
        };
    }
    public void GetJobs(Action<List<Job>> callback) {
        Http.Get(
            endpoint + "/api/json",
            new Dictionary<string, string>() {
                {"Authorization", "Basic " + auth }
            },
            (int code, string response) => {
                if (code != 200) {
                    callback?.Invoke(null);
                    return;
                }
                
                 var obj = JObject.Parse(response);
                 var result = new List<Job>();
                 
                 foreach(var job in obj["jobs"]) {
                     result.Add(new Job(){
                        endpoint = endpoint,
                        auth = auth,
                        name = (string)job["name"],
                        state = (string)job["color"],
                        url = (string)job["url"]
                     });
                 }
                 
                 callback?.Invoke(result);
            });
    }
}
