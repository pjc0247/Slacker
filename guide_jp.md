Slacker ガイド
====

スクリプトの作成
----
`plugins/`ホルダーの下で`.csx`スクリプトを生成してください。<br>
後で作成したスクリプトで変更があったら__Slacker__はその変更を自動的に感知し、スクリプトを改めてリフレッシュします。

Bootstrap
----
```cs
[Bootstrap]
public void OnBootstrap() {
  // このメソッドはSlackerの初期化時点に実行されます。
}
```

Scheduler
----
```cs
[Schedule(10)]
public void OnSchedule() {
  //　このメソッド１０秒まで実行されます。
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

Herokuでホスティングする方
----
https://github.com/pjc0247/slacker_buildpack<br>
この主題については上記のリンクを従ってください。

コメント
----
__Slacker__はOpenSourceではありません。若し機能の追加を要請したい場合にはどうか教えてください。
