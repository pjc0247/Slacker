Jenkins
====

바이너리와 함께 배포되는 __Jenkins__ 모듈의 사용법을 보여줍니다.<br>
https://github.com/pjc0247/Slacker/blob/master/src/plugins/jenkins.csx
```cs
static string endpoint = "http://1.1.1.1/";
static string id = "pjc";
static string password = "asdf";

[Subscribe("jenkins")]
public void OnJenkins(Message msg){
    var jenkins = Jenkins.Create(endpoint, id, password);
    var job = jenkins.GetJob("BUILD_ITEM_NAME");

    job.Build(
        // 빌드 파라미터입니다.
        //  만약 빌드 파라미터가 없는 경우 빈 Dictionary / null
        //  를 넣지 마시고, 파라미터를 아예 스킵해주세요.
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
