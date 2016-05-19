// example_gist.csx
//   루비 소스를 올리면 해당 소스를 기스트에 업로드하는 예제

using System.Collections.Generic;

[Subscribe(MessageType.File, name: ".*\\.rb")]
public void OnRubyScript(Message msg){
    Http.Get(
        msg.file.url_private_download,
        Http.CreateSlackAuthorizedHeader(),
        (code, body) => {
           Gist.Create(
                "Slacker HTTP+Gist API Test", true,
                new Dictionary<string, string>() {
                    {msg.file.name, body}
                },
                (dynamic resp) => {
                    msg.Reply((string)resp.html_url);
                }); 
        });
}
