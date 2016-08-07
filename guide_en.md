Slacker Guide
====

* `guide_en` is not complete. Some examples may not be up to date.*
* Other Languages : [Korean](https://github.com/pjc0247/Slacker), [Japanes](https://github.com/pjc0247/Slacker/blob/master/guide_jp.md)

Set-up
----
Create `token` file on bot directory and put your Slack access token.<br>
(You can find Slack access token [here](https://api.slack.com/docs/oauth-test-tokens))<br>
<br>
or If you want to use a `Bot token`, please refer to [this guide](https://api.slack.com/bot-users).

Bootstrap
----
Once recompiled, Slacker will invoke bootstrap methods.
```cs
[Bootstrap]
public void OnBootstrap() {
  // This method will be executed in initialization sequence.
}
```

Multiple `Bootstrap` methods are allowed.
```cs
[Bootstrap]
public void OnBootstrap1() { }

[Bootstrap]
public void OnBootstrap2() { }
```
* There is no method to specify order between `Bootstrap` methods.

Add bot commands
----
__Basic command__<br>
Create a `WHATEVERYOUWANT.csx` file under `plugins/` directory and write code below.
```cs
using System;
using Slacker.Exports;

[Subscribe("hello")]
public void OnHello(Message msg) {
  msg.Reply("Hi, " + msg.sender);
  
  // `Reply` is a shortcut method,
  // the below line will perform a exactly same action
  // Slack.SendMessage(msg.channel, "Hi, " + msg.sender);
}
```
All `.csx` file under `plugins/` directory will be automatically reloaded when changed. (which means, you don't have to restart your bot.)

__SendImage__<br>
The example below decribes how to send a image message via `SendImage` method,
```cs
var imageURL = "https://github.com/pjc0247/Slacker/raw/master/slack.png";

// Note that title is an optional parameter.
// You can send images without titles.
Slack.SendImage(msg.channel, imageURL, title: "IMAGE_TITLE");
```

__Using regular expressions__<br>
You can also use a regular expression, and match result will be filled in `msg` object. This is useful when you want to create a flexible/fluent commands.
```cs
[Subscribe("^echo\\s(.+)$")]
public void OnEcho(Message msg){
    // captured values can be accessed though `matchData.Groups` property.
    Slack.SendMessage(msg.channel, msg.matchData.Groups[1].Value);
}
```
<br>
https://msdn.microsoft.com/ko-kr/library/system.text.regularexpressions.match(v=vs.90).aspx

Receive Files
----
```cs
// `mimeType` is optional parameter.
//   If you want to receive all file types, please do not specify it.
[Subscribe(MessageType.File, mimeType: "image/*")]
public void OnReceiveImage(Message msg){
  // below link decribes structure of the `file` object
  //   * https://api.slack.com/types/file
  var fileInfo = msg.file;
}
```

Scheduler
----
In some cases, your bot may need to execute background tasks (Such as web-crawling, ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~).
```cs
[Schedule(10)]
public void OnSchedule() {
  // this method will be executed every 10ms.
}
```
Also, there is an API which enables you to schedule tasks manually.
```cs
Scheduler.SetInterval(() => {
    Console.WriteLine("AFTER 1000MS");
}, 1000);
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

Concurrency
-----
Since there is a GL(Global Lock), all methods executed by `Slacker` are thread-safe. It makes users can write scripts without any threading concerns. However you SHOULD NOT ues synchronous APIs in `Subscribe` or `Schedule` methods. If your code have any BLOCKING routines in these methods, entire program will be hung till it ends.<br>
The example below shows how to handle synchronous task without hangs.
```cs
[Subscribe("hi")]
public void OnHi(Message msg) {
  // Slacker-Managed thread.
  //   DO : access global vars
  //   DONT : sync calls
  
  new Thread(() => {
    // Non-Slacker-Managed thread
    //   DO : sync calls 
    //   DONT : access global vars
    var result = SomeSyncCall();
    
    Bot.RunOnBotContext(() => {
      // will be executed on Slacker-Managed thread again.
      msg.Reply(result);  
    });
  }).Start();
}
```
* ~~Currently, `async/await` is not supported.~~ `async/await` feature is also supported since [v.1.2.0](https://github.com/pjc0247/Slacker/releases/tag/v.1.2.0)

Deploy your bot on Heroku
----
.Net assemblies can be deployed & executed on Heroku.<br>
Please refer to [this](https://github.com/pjc0247/slacker_buildpack) repo.

Remarks
----
__Slacker__ is not an Open-Source project. If you have any feature requests, please let me know.
