ScriptOption
====

`script_option.json` 파일을 수정하여 스크립트 엔진의 옵션을 변경할 수 있습니다.

```json
{
    "assembly_ref" : [
        
    ],
    "global_namespace" : [
        "System",
        "Slacker.Exports"
    ]
}
```

__assembly_ref__ : 스크립트에 추가할 레퍼런스 어셈블리의 경로를 입력합니다.<br>
__global_namespace__ : 스크립트에 기본적으로 `using` 될 네임스페이스 이름을 지정합니다.
