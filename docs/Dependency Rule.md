# Dependency Rule

```txt
ERP.Domain          ← no references (knows nothing)
    ↑
ERP.Application     ← knows Domain only
    ↑
ERP.Infrastructure  ← knows Application (implements its interfaces)
    ↑
ERP.API             ← knows Application + Infrastructure (entry point)
```

## Flow of a Request

```txt
Request → API (door)
        → Application (brain decides what to do)
        → Domain (validates business rules)
        → Infrastructure (talks to DB/cache/email)
        → Response back
```
