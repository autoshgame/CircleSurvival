# CircleSurvival
[Ghoshittttt]

So boring to do this, but here are the things I have done in this project:

- Service Provider Pattern: Why? I didn't want to plan on using Dependency Injection (DI) in this project because it's quite large and out of my scope, so I chose an easier implementation. However, this implementation can work with DI if you want to use it.

- FSM State: This is a powerful tool that I used throughout my project. I created it in a flexible way, but I’m sad that if you inherit from my FSMManager, you cannot use another class (inheritance). You need to implement the interface for the hero. I used it in my map, my enemies, etc.

- Observer Pattern: I opted for this due to its ability to handle multiple events. I didn’t plan to use strings because it’s awkward to create strings in a constant script, so I used generics (T). This choice is flexible but does come with a performance trade-off.

- Component Usage: There’s room for improvement in how components interact. Components shouldn't reference their parent directly; instead, they should receive information from the parent. If two components need to communicate (like when an enemy moves towards a target, or if the target is null and it requests another scan), this should be handled in action. For instance, the movement component should use velocity or transform data passed down through the FSM state. This approach makes it flexible for reuse in other contexts, like mini-games, without having to carry over old scripts. Game development differs from other software; it doesn’t need to be overly strict with software engineering principles. If it is too rigid, it can negatively impact gameplay and lead to financial losses. On the other hand, in other software development, if a feature changes, a rigid implementation can make scaling difficult, and developers might end up frustrated. This project can not do that. Gotta do some improvements, yeahhhhhhh



