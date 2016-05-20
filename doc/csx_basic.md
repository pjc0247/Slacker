csx 파일 작성하기
====
`.csx` 파일은 __C# 6.0__ 문법을 따릅니다.<br>

공유 변수 사용하기
----
전역 스코프에 변수를 선언하면 변수가 생성됩니다.
```cs
int count = 0;

[Subscribe("Hello")]
public void OnHello(Message msg) {
  Slack.SendMessage(msg.channel, count.ToString());
  count += 1;
}
```

이 변수는 `.csx` 파일간에 공유됩니다. 다른 `.csx` 파일간에 상태를 공유해야 하는 경우가 있다면 이 방법을 이용해 주세요.
<br><br>
* __주의__ : 이 값들은 스크립트가 다시 컴파일 될 경우 저장되지 않고 모두 삭제됩니다.


저장되는 변수 사용하기
----
일반적인 변수는 스크립트가 다시 컴파일되거나, 프로그램이 다시 시작되면 전부 초기화됩니다.<br>
아래는 저장되는 변수를 사용하여 세션간에 유지되는 값을 사용하는법을 보여줍니다.

```cs
[Bootstrap]
public void OnBootstrap() {
  // 초기값을 설정합니다.
  // Persistent 하위의 값은 이전 실행에 의해 값이 들어있을 수 있으므로
  // 항상 0으로 초기화하는것은 옳지 못한 행동입니다.
  Persistent.count = Persistent.count ?? 0;
}

[Subscribe("Hello")]
public void OnHello(Message msg) {
  Slack.SendMessage(msg.channel, Persistent.count.ToString());
  Persistent.count += 1;
}
```
* __Persistent__는 `dynamic`입니다.
<br><br>
* __주의__ : 프로그램을 강제 종료할 경우에는 저장되는 변수도 저장되지 않을 수 있습니다.
* `Persistent`는 단일 인스턴스 환경만을 고려해서 작성되었습니다.
