Привет, спасибо что уделил время). Всего на выполнение потратил, ~7-8 часов. 
Разделил работу на две части. Выполнил базовую архитектуру, вышел по делам, вернулся и доделал остальное.

Записал небольшое видео: https://www.youtube.com/watch?v=lYIF0cpVJPc

Было реализовано все что в тз.
Из опционального:
* Выбор дрона
* Система фракций
* Скорость симуляции
* Вывод состояния дрона


Так выглядит структура проекта:
Game
│
├── Core
│   ├── GameManager
│   ├── ResourcesManager
│   └── UIManager
│
├── Services (ассистенты & контроллеры)
|   ├── BaseStation
|   ├── ResourcesDroneManager
| 
├── Units
│   ├── AUnit (абстрактный класс)
│       └── ADrone (абстрактный класс)
│           └── ResourceDrone
│       └── (в будущем все возможные юниты)
│
├── Targeting
│   ├── ITargetable (интерфейс)
│   ├── Resource (реализует ITargetable)
│
└── Events (события)
    ├── IntEventChannelSO
    ├── FloatEventChannelSO
    └── BoolEventChannelSO
