Redis
====
노드 간 데이터 공유를 위하여 __Slacker__에는 기본적으로 __Redis__ 클라이언트가 내장되어 있습니다.<br>
Redis를 여러 인스턴스 간의 공유 메모리로 활용할 수 있습니다.

읽기 / 쓰기 / 업데이트
----
```cs
var level = await Redis.GetIntAsync("level", 0);
```

RAW API 이용하기
----
https://github.com/StackExchange/StackExchange.Redis
```cs
StackExchange.Redis.IDatabase db = Redis.db;
```

유저 스토리지
----
```
미완성
```
유저 스토리지 엔진을 Redis로 교체할 수 있습니다.

```cs
public async void OnMessage(Message msg, UserStorage user) {
}
```
