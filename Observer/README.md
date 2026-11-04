# Observer: прогрес завантаження

Імітація прогресу без справжнього завантаження. Реалізовано два варіанти:

- `Downloader` зберігає список `IProgressObserver`. `Subscribe` додає
  підписника, `Unsubscribe` прибирає. При зміні стану викликається
  `OnProgressChanged` кожного підписника.
- `EventDownloader` використовує подію `Action<int>`. Підписка — через `+=`,
  відписка — через `-=`. `ProgressChanged?.Invoke(percentage)` викликає
  підписані методи, якщо вони є.

`ProgressDisplay` друкує відсоток, `CompletionNotification` повідомляє
лише про значення 100. Повторення поточного значення не породжує повідомлень.
Значення за межами 0–100 відхиляються без зміни стану.

`Program.cs` демонструє 10, 50 і 100 для обох варіантів. Перед 100
індикатор прогресу відписується, але повідомлення про завершення залишається.

Запуск із .NET 10 SDK:

```sh
dotnet run --project Observer
```

Очікуваний результат:

```text
=== OOP Observer ===
Progress: 10%
Progress: 50%
Download complete
=== Delegates/events ===
Progress: 10%
Progress: 50%
Download complete
```
