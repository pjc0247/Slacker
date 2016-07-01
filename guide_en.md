Slacker Guide
====

* `guide_en` is not complete. Some examples may not be up to date.

Set-up
----
Create `token` file on bot directory and put your Slack access token.<br>
(You can find Slack access token [here](https://api.slack.com/docs/oauth-test-tokens))<br>
<br>
or You can use a `Bot token`, please refer to [this guide](https://api.slack.com/bot-users).

Bootstrap
----
Once recompiled, Slacker will invoke bootstrap methods.
```cs
[Bootstrap]
public void OnBootstrap() {
  // This method will be executed in initialization sequence.
}
```

Add bot commands
----
__Basic command__
```cs
[Subscribe("hello")]
public void OnHello(Message msg) {
  Slack.SendMessage(msg.channel, "Hi, " + msg.sender);
}
```

__SendImage__<br>
You can send a image via `SendImage` method.
```cs
var imageURL = "https://github.com/pjc0247/Slacker/raw/master/slack.png";

// Note that title is an optional parameter.
Slack.SendImage(msg.channel, imageURL, title: "IMAGE_TITLE");
```

__Using regular expressions__<br>
You can also use a regular expression, and match result will be filled in `msg` object.
```cs
[Subscribe("^echo\\s(.+)$")]
public void OnEcho(Message msg){
    Slack.SendMessage(msg.channel, msg.matchData.Groups[1].Value);
}
```
<br>
https://msdn.microsoft.com/ko-kr/library/system.text.regularexpressions.match(v=vs.90).aspx

Receive Files
----
```cs
// MessageType을 File로 지정
// `mimeType` is optional parameter.
//   If you want to receive all file types, do not specify it.
[Subscribe(MessageType.File, mimeType: "image/*")]
public void OnReceiveImage(Message msg){
  // 수신한 파일의 정보를 가져옵니다.
  // https://api.slack.com/types/file
  var fileInfo = msg.file;
}
```

Scheduler
----
```cs
[Schedule(10)]
public void OnSchedule() {
}
```

Slack API
----
__me__
```cs
var me = Slack.me;

string id = me.id;
string name = me.name;
// whether current user is bot or not.
// if you use the `Bot token` this value will be set to `true`
bool isBot = me.isBot;
string email = me.email;
```

__Set presence__
```cs
Slack.SetActive();
Slack.SetAway();
```

__Channels__
```cs
var joinned = Slack.joinnedChannels;

// all channels in your team.
var all = Slack.channels;
```

Deploy your bot on Heroku
----
.Net assemblies can be deployed & executed on Heroku.<br>
Please refer to [this](https://github.com/pjc0247/slacker_buildpack) repo.

Remarks
----
__Slacker__ is not an Open-Source project. If you have any feature requests, please let me know.
