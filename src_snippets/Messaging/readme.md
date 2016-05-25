Messaging
====

훅 생성하기
----
```cs
[Subscribe("Hello")]
public void OnHello(Message msg) {
	var channelId = msg.channel;
	var sender = msg.sender;
	var msg = msg.message;

	msg.Reply("Hi, " + sender + "!");
}
```

파일 훅 생성하기
----
```cs
[Subscribe(MessageType.File)]
public void OnFile(Message msg) {
	var file = msg.file;

	// https://api.slack.com/types/file
	var url = file.url_private_download;
}
```

이미지 훅 생성하기
----
```cs
[Subscribe(MessageType.File, mimeType: "image/")]
public void OnImage(Message msg) {
	var file = msg.file;

	// https://api.slack.com/types/file
	var url = file.url_private_download;
}
```