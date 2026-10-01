# Command-console starting example

[CommandLoop.cs](CommandLoop.cs) is the original implementation: input handling, dispatch, and behavior share one loop.

Run `dotnet run --project OCP` from the repository root, then try:

```text
/echo hello
/time
/unknown
/exit
```

`/exit` leaves the loop and continues to the quiz. End-of-input also leaves the loop.

Exercise: refactor so new commands do not require editing this loop, then add `/poll Lunch? | Pizza | Salad`. Expected output:

```text
Poll: Lunch?
1. Pizza
2. Salad
```

Keep the existing echo, time, exit, and unknown-command behavior. Decide where new commands are registered. The repository provides the starting code only.
