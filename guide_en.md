Slacker Guide
====

Bootstrap
----
Once recompiled, Slacker will invoke bootstrap methods.
```cs
[Bootstrap]
public void OnBootstrap() {
  // This method will be executed in initialization sequence.
}
```

Add commands
----
__Basic command__
```cs
[Subscribe("hello")]
public void OnHello(Message msg) {
  Slack.SendMessage(msg.channel, "Hi, " + msg.sender);
}
```

__Using regular expressions__<br>
You can pass a regular expression, and match result will be filled in `msg` object.
```cs
[Subscribe("^echo\\s(.+)$")]
public void OnEcho(Message msg){
    Slack.SendMessage(msg.channel, msg.matchData.Groups[1].Value);
}
```
<br>
https://msdn.microsoft.com/ko-kr/library/system.text.regularexpressions.match(v=vs.90).aspx


Deploy your bot on Heroku
----
.Net assemblies can be deployed & executed on Heroku.<br>
Please refer to [this](https://github.com/pjc0247/slacker_buildpack) repo.
