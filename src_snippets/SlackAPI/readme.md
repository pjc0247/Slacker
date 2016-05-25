SlackAPI
====

메세지 전송하기
----
```cs
Slack.SendMessage("CHANNEL_ID", "MESSAGE_TO_SEND");
```

이미지 전송하기
----
```cs
Slack.SendImage("CHANNEL_ID", "IMAGE_URL");

Slack.SendImage("CHANNEL_ID", "IMAGE_URL", "TITLE (OPTIONAL)");
```

상태 변경하기
----
```cs
Slack.SetAway();

Slack.SetActive();
```

Auth 토큰 가져오기
----
```cs
var authToken = Slack.me.authToken;
```