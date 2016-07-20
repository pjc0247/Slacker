자동 스케일 아웃
====

수동으로 `shardNo`와 `shardSize` 값을 지정하지 않아도, 네트워크에서 자동으로 노드들을 검색해 값을 설정합니다.

사용하기
----
`sharding_options.json` 파일에 `size` 항목을 __0__으로 지정합니다.<br>
이 경우 `no` 필드는 무시됩니다.
```json
{
  "no" : 2,
  "size" : 0,
  "enable" : true
}
```
이후 봇을 실행하면 자동으로 디스커버리 시퀸스를 실행하며, 네트워크상의 다른 봇 노드를 검색합니다.<br>

![](sla_1.PNG)<br>
![](sla_2.PNG)<br>
![](sla_3.PNG)<br>
