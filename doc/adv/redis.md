Redis
====
노드 간 데이터 공유를 위하여 __Slacker__에는 기본적으로 __Redis__ 클라이언트가 내장되어 있습니다.<br>
Redis를 여러 인스턴스 간의 공유 메모리로 활용할 수 있습니다.

읽기 / 쓰기 / 업데이트
----
__Slacker__에서는 사용 편의를 위하여 몇몇 API를 래핑하여 제공하고 있습니다.
```cs
var level = await Redis.GetIntAsync("level", 0);

// 항상 설정 (Always)
await Redis.SetIntAsync("level", 10);
// 기존 값이 있는 경우에만 설정 (Exists)
await Redis.UpdateIntAsync("level", 10);
// 기존 값이 없는 경우에만 설정 (NotExists)
await Redis.AddIntAsync("level", 10);
```

키 삭제하기
----
```cs
await Redis.DeleteAsync("level");

// 10초후 삭제
await Redis.ExpireAsync("level", TimeSpan.FromSeconds(10));
```

PubSub 이용하기
----
__Redis__의 PUBSUB기능을 이용하여 노드 간 메세지 송수신을 수행할 수 있습니다.<br>
<br>
__송신하기__
```cs
await Redis.PublishAsync("q.rini", "HELLO WORLD");
```
__수신하기__
```cs
// 정규식은 사용할 수 없지만, 와일드카드문자 `*`는 사용이 가능합니다.
[RedisSubscribe("q.*")]
public void OnRedisMessage(Message msg) {
  Console.WriteLine( msg.message );
  Console.WriteLine( msg.channel );
  
  // RedisMessage에는 Reply같은 쇼트컷 메소드를 사용할 수 없습니다.
  // Redis.PublishAsync 메소드를 이용해 주세요.
  // msg.Reply("A");
}
```

RAW API 이용하기
----
만약 Redis의 모든 기능을 이용하고 싶다면, 내부적으로 사용하는 Redis 객체를 가져와 작업합니다.<br>
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
