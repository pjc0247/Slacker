수평적 스케일 아웃
====
![shad](img/1463063163965.jpg)<br><br>

__shading_option.json__
```json
{
    "no" : 0,
    "size" : 3,
    "enable" : true
}
```

<br><br>
__script.csx__
```cs
[Subscribe("shading_test")]
public void OnShad(Message msg) {
    if (Config.enableShading == false) {
        Slack.SendMessage(msg.channel, "샤딩 안켜짐.");
        return;
    } 
    
    Slack.SendMessage(msg.channel, "이 메세지는 한번만 전송되어야 합니다.");
    Slack.SendMessage(msg.channel, "처리하는 인스턴스 id : " + Config.shadNo.ToString());
}
```
