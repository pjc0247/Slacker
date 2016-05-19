Spawner
====

배치 스크립트를 이용하여 인스턴스를 동시에 여러개 켜는 프로그램을 작성할 수 있습니다.
```bat
SET size=3

FOR /l %%x in (1, 1, %size%) do (
    START Slacker.exe --sharding true --shard-no %%x --shard-size %size%
) 
```
