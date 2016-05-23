Http
====

봇에서 HTTP 요청을 수행하기 위해서 기본 제공되는 [Net.Http.HttpClient](https://msdn.microsoft.com/ko-kr/library/system.net.http.httpclient(v=vs.118).aspx) 클래스를 사용할 수 있지만,<br>
Slacker에서는 작성의 간편함을 위해서 래핑 클래스를 제공합니다.<br>
<br>
__Slacker__의 `Http` 클래스는 아주 간단한 수준의 래핑이기 때문에 상세한 컨트롤이 필요한 경우 다른 구현체를 이용해 주세요.

GET
----
```cs
Http.Get(
  "http://www.naver.com",
  (code, body) => {
    if (code != 200)
      Console.WriteLine("ERROR");
    else {
      Console.WriteLine(body);
    }
  });
```

POST
----
```cs
Http.Post(
  "http://www.naver.com",
  "POSTDATA",
  (code, body) => {
    if (code != 201)
      Console.WriteLine("ERROR");
    else {
      Console.WriteLine(body);
    }
  });
````

Request Headers
----
```cs
Http.Get(
  "http://www.naver.com",
  new Dictionary<string, string>() {
    {"HEADER_NAME1", "HEADER_VALUE1"},
    {"HEADER_NAME2", "HEADER_VALUE2"},
  },
  (code, body) => {
    /* .... */
  });
```

Http.CreateSlackAuthorizedHeader
----
현재 Slacker 봇의 인증 정보를 담은 헤더를 생성합니다.<br>
이 메소드는 Slack에 공유된 파일을 다운로드 받을 때 사용됩니다.
```cs
[Subscribe(MessageType.File, name: ".*\\.rb")]
public void OnRubyScript(Message msg){
  Http.Get(
    msg.file.url_private_download,
    Http.CreateSlackAuthorizedHeader(),
    (code, body) => {
      /* .... */       
    });
}
```
