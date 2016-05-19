gist.csx
====

```cs
bool isPublicGist = true;

Gist.Create(
  "DESCRIPTION",
  isPublicGist,
  new Dictionray<string, string>() {
    {"a.cpp", "printf(12345);"},
    {"b.rb", "puts(12345);"},
  },
  (dynamic result) => {
    string url = result.url;
  });
```
