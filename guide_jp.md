Slacker ガイド
====

* `guide_jp`はまだ完成していません。

セットアップ
----
Slackトークン`token`ファイルで位置してくださ。 もしBot専用トークンを使いたい場合には[この](https://api.slack.com/bot-users)リンクのガイドを参考してください。

スクリプトの作成
----
`plugins/`フォルダーの下で`.csx`スクリプトを生成してください。<br>
後で作成したスクリプトで変更があったら__Slacker__はその変更を自動的に感知し、スクリプトを改めてリフレッシュします。

Bootstrap
----
`Bootstrap`を使ってBotの初期化メソードを作成することが出来ます。
```cs
[Bootstrap]
public void OnBootstrap() {
  // このメソッドはSlackerの初期化時点に実行されます。
}
```
* 現在、２つ以上の`Bootstrap`メソードを使うのは出来ますが、実行順序を指定するのはできません。

SendMeesage
----
__SendImage__
```cs
var imageURL = "https://github.com/pjc0247/Slacker/raw/master/slack.png";

// titleはオプショナルです。
Slack.SendImage(msg.channel, imageURL, title: "IMAGE_TITLE");
```

Scheduler
----
```cs
[Schedule(10)]
public void OnSchedule() {
  //　このメソッド１０秒毎に実行されます。
}
```
APIの使ってタスクをScheduleすることも出来ます。
```cs
Scheduler.SetTimeout(() => {
  // ことlambdaは１０秒後に実行されます。
}, 10);
```

Message Object
----
`Message` オブジェクトは下記の構造に構成されています。
```cs
public class Message {
  public string text;
}
```

Slack API
----
__me__
```cs
var me = Slack.me;

string id = me.id;
string name = me.name;
bool isBot = me.isBot;
string email = me.email;
```

Async Task
----
`v.1.2.0`から`async/await`キーワードを使えます。
```cs
[Subscribe("test")]
public async void OnTest(Message msg) {
  msg.Reply("Delay");

  await Task.Delay(3000);

  msg.Reply("After 3secs");
}
```

Herokuでホスティングする方
----
https://github.com/pjc0247/slacker_buildpack<br>
この主題については上記のリンクを従ってください。

コメント
----
__Slacker__はOpenSourceではありません。若し機能の追加を要請したい場合にはどうか教えてください。<br>
