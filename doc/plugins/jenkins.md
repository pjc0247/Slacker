Jenkins
====

```cs
static string endpoint = "http://1.1.1.1/";
static string id = "pjc";
static string password = "asdf";

[Subscribe("jenkins")]
public void OnJenkins(Message msg){
    var jenkins = Jenkins.Create(endpoint, id, password);
    var job = jenkins.GetJob("BUILD_ITEM_NAME");

    job.Build(
        new Dictionary<string, object>() {
            {"build_param", "value"}
        },
        (done) => {
            if (done == true)
                msg.Reply("Done");
            else
                msg.Reply("Failed");
        });
}
```
