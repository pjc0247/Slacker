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

__SendImage__
```cs
var imageURL = "https://github.com/pjc0247/Slacker/raw/master/slack.png";

// Note that title is an optional parameter.
Slack.SendImage(msg.channel, imageURL, title: "IMAGE_TITLE");
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


Scheduler
----
```cs
[Schedule(10)]
public void OnSchedule() {
}
```

Deploy your bot on Heroku
----
.Net assemblies can be deployed & executed on Heroku.<br>
Please refer to [this](https://github.com/pjc0247/slacker_buildpack) repo.

Remarks
----
__Slacker__ is not an Open-Source project. If you have any feature requests, please let me know.
