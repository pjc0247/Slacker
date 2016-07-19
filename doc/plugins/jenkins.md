Jenkins
====

```cs
static string endpoint = "http://1.1.1.1/";
static string id = "pjc";
static string password = "asdf";

[Subscribe("jenkins")]
public void OnJenkins(Message msg){
    var jenkins = Jenkins.Create(endpoint, id, password);
    var job = jenkins.GetJob("test_");

    job.Build(
        new Dictionary<string, object>() {
            {"asdf", "Asdf"}
        },
        (_) => {
          msg.Reply("Done");
        });
}
```
