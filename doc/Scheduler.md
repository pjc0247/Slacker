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
