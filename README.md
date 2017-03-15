**/!\ All code inside this repository must be considered as unstable**

# FlatSquares
During all my developer life i built many game samples & game engine features. I have been made a break on gamedev since i failed to achieve two large games 3 years ago.

At the moment, i really want to come back on gamedev for fun, so i have decided to create a basic 2d game engine for retro game style development. I'm not sure if it will be a real project in the futur, but this repository will help me to remind most of my knowledge on gamedev

## RoadMap
- XPlatform and mobile first engine
- Providers to allow developer to target different C# game engine (not a huge priority)
- Scene management
- Node system with common components to build a 2d game
- Graphics/Audio/Input/Content providers
- TMX files import
- Embbed terminal
- ...

## Component lifecycle

| Lifecycles | Interfaces  | Description              |
| :--------: |:-----------:|--------------------------|
| Load       | ILoad       | Load content             |
| Initialize | IInitialize | Initialize               |
| Update     | IUpdate     | Update                   |
| Render     | IRender     | Draw                     |
| Dispose    | IDisposable | Dispose / Unload content |
