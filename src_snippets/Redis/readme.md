Redis
====

PubSub
----
__publisher__
```cs
await Redis.PublishAsync("channel", "message");
```
__subscriber__
```cs
[RedisSubscribe("channel")]
public void OnRedisMessage(Message msg) {
  var ch = msg.channel; // "channel"
  var msg = msg.message; // "message"
}
```

Data Operations
----
```cs
// persistent
await Redis.SetIntAsync("key", 10);
// with TTL
await Redis.SetIntAsync("key", 10, TimeSpan.FromSecond(100));
```

```cs
var n = await Redis.GetIntAsync("key", 10 /* default value */);

await Redis.SetStringAsync("key", "Hello World");
var str = await Redis.GetStringAsync("key"); // "Hello World"
```

```cs
await Redis.AddStringAsync("key", "Hello world");
await Redis.UpdateStringAsync("key", "Hello world");
await Redis.SetStringAsync("key", "Hello world");
```

```cs
await Redis.DeleteAsync("key");

await Redis.ExpireAsync("key", TimeSpan.FromSecond(100));
```
