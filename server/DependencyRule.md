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
