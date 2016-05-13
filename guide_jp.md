Slacker ガイド
====

スクリプトの作成
----
`plugins/`ホルダーの下で`.csx`スクリプトを生成してください。<br>
後で作成したスクリプトで変更があったら__Slacker__はその変更を自動的に感知してスクリプトを改めてリフレッシュします。

Bootstrap
----
```cs
[Bootstrap]
public void OnBootstrap() {
  // このメソッドはSlackerの初期化時点に実行されます。
}
```

Herokuでホスティングする方
----
https://github.com/pjc0247/slacker_buildpack<br>
この主題については上記のリンクを従ってください。
