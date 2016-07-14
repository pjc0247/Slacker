스케쥴러
====

봇이 먼저 말을 꺼내는 등의 기능을 구현하기 위해 `Schedule` 기능을 제공합니다.<br>
스케쥴러에 등록하면 지정된 시간마다 반복해서 실행됩니다.

```cs
// 10초마다 실행되는 메소드
[Schedule(10)]
public void OnSchedule() {
    Console.WriteLine("I'M ALIVE.");
}
```

API 이용하기
----
```cs
Scheduler.SetInterval(() => {
    Console.WriteLine(1234);
}, 1000);
```

최소 간격 설정하기
----
`Scheduler`의 해상도를 변경할 수 있습니다. 이 값이 낮으면 낮을수록 Scheduler가 더 자주 깨어납니다.
```cs
// ms 단위로 최소 간격을 설정합니다.
Config.schedulerMinInterval = 1000;
```
혹은 `script_option.json`
```json
{
    "scheduler_min_interval" : 1000
}
```
