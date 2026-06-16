# Class Configuration （职业配置）

游戏中的每个职业在 [/Json/Class/](./Json/Class) 中都有一个配置文件，例如 `DeathKnight` 的某个配置在文件 [DeathKnight_70_Frost.json](./Json/Class/DeathKnight_70_Frost.json) 中。

配置文件决定了游戏角色在拉怪和其战斗时施放法术的时机、考虑需要哪些 Buff和在何时需要出售物品与修理等等。

如果某个属性在配置中没有明确指定或缺省，则可以假定它使用默认值！

### Understanding Class Configuration (理解 Class Configuration)

以下为每个部分以及属性的作用说明：

| 部分 | 目的 |
| --- | --- |
| **Loot/Skin/Herb/Mine** | 控制杀死怪物后 Bot 做什么。根据你的角色专业技能启用。 |
| **UseMount** | 加快刷怪点之间的旅行速度。如果没有坐骑或在坐骑有问题的区域可禁用。 |
| **PathFilename** | 定义 Bot 行走的路径。没有路径，Bot 就不知道去哪里。 |
| **NPCMaxLevels_Above/Below** | 防止攻击等级太高（危险）或太低（无经验值）的怪物。 |
| **Blacklist** | 避免特定导致问题的怪物（例如任务怪、具有烦人能力的怪物）。 |
| **Pull/Combat/Flee** | 核心战斗循环。Pull 定义如何开始战斗，Combat 是主循环，Flee 是紧急逃生。 |
| **NPC** | 定义 Vendor/修理路线。对于长时间刷怪至关重要。 |
| **Mail/MailConfig** | 自动将多余物品和金币发送给另一个角色。在长时间刷怪期间保持背包清理很有用。 |

| 属性名称 | 描述 | 可选 | 默认值 |
| --- | --- | --- | --- |
| `"Log"` | 是否为 [`KeyAction(s)`](#keyaction) 启用日志记录。需要重启。 | 是 | `true` |
| `"LogBagChanges"` | 是否启用背包变更日志记录。 | 是 | `true` |
| `"Loot"` | 是否拾取怪物 | 是 | `true` |
| `"Skin"` | 是否剥皮 | 是 | `false` |
| `"Herb"` | 是否采药 | 是 | `false` |
| `"Mine"` | 是否采矿 | 是 | `false` |
| `"Salvage"` | 是否回收零件 | 是 | `false` |
| `"UseMount"` | 是否在可能时使用坐骑 | 是 | `false` |
| `"AllowPvP"` | 是否与对立阵营交战 | 是 | `false` |
| `"TargetNeutral"` | 是否检测中立（黄色）目标姓名板。建议初始区域（1-5 级）启用，那里的怪物是中立的。 | 是 | `false` |
| `"AutoPetAttack"` | 宠物是否开启自动攻击 | 是 | `true` |
| `"CrossZoneSearch"` | 允许跨区域边界搜索目标，用于跨区域路径 | 是 | `false` |
| `"KeyboardOnly"` | 仅使用键盘交互。见 [KeyboardOnly](#keyboardonly) | 否 | `true` |
| --- | --- | --- | --- |
| `"PathFilename"` | 角色存活时使用的[Path](#path) | **否** 或[Multiple Paths With Requirements](#multiple-paths-with-requirements)(即启用下面的Paths属性) | `""` |
| `"PathThereAndBack"` | 使用路径时，[是否从头走到尾再反向走](#there-and-back) | 是 | `true` |
| `"PathReduceSteps"` | 减少路径上的坐标点数量 | 是 | `false` |
| `"SideActivityRequirements"` | [条件](#requirement)列表，用于限制玩家何时搜索目标<br/>非常适合强制执行路径跟随的紧密程度 | 是 | `true` |
| --- | --- | --- | --- |
| `"Paths"` | [PathSettings](#pathsettings) 数组。<br>要么定义此数组启用多条路径，要么使用上述单路径的相关属性 | 是 | `[]` |
| --- | --- | --- | --- |
| `"NPCMaxLevels_Above"` | 屏蔽高于角色n级的目标 | 是 | `1` |
| `"NPCMaxLevels_Below"` | 屏蔽低于角色n级的目标 | 是 | `7` |
| `"CheckTargetGivesExp"` | 仅在目标提供经验值时交战 | 是 | `false` |
| `"Blacklist"` | 必须避免交战的目标名称或子名称列表 | 是 | `[""]` |
| `"TargetMask"` | [`TargetMask`](#targetmask) — 允许交战的 [UnitClassification](https://wowpedia.fandom.com/wiki/API_UnitClassification) 类型 | 是 | `"Normal, Trivial, Rare"` |
| `"NpcSchoolImmunity"` | 具有一个或多个 [SchoolMask](#npcschoolimmunity) 免疫的 NpcID 列表 | 是 | `""` |
| `"IntVariables"` | 用户定义的 `integer` 或 `integer[]` 变量列表。见 [`IntVariables`](#intvariables) | 是 | `[]` |
| `"StringVariables"` | 用户定义的 `string` 变量列表。见 [`StringVariables`](#stringvariables) | 是 | `[]` |
| --- | --- | --- | --- |
| `"Pull"` | 执行 [Pull Goal](#pull-goal) 时执行的 [KeyActions](#keyactions) | 是 | `{}` |
| `"Flee"` | 执行 [Flee Goal](#flee-goal) 时执行的 [KeyActions](#keyactions) | 是 | `{}` |
| `"Combat"` | 执行 [Combat Goal](#combat-goal) 时执行的 [KeyActions](#keyactions) | **否** | `{}` |
| `"AssistFocus"` | 执行 [Assist Focus Goal](#assist-focus-goal) 时执行的 [KeyActions](#keyactions) | **否** | `{}` |
| `"Adhoc"` | 执行 [Adhoc Goals](#adhoc-goals) 时执行的 [KeyActions](#keyactions) | 是 | `{}` |
| `"Parallel"` | 执行 [Parallel Goal](#parallel-goals) 时执行的 [KeyActions](#keyactions) | 是 | `{}` |
| `"NPC"` | 执行 [NPC Goal](#npc-goals) 时执行的 [KeyActions](#keyactions) | 是 | `{}` |
| `"Wait"` | 执行 [Wait Goal](#wait-goals) 时执行的 [KeyActions](#keyactions) | 是 | `{}` |
| --- | --- | --- | --- |
| `"Mail"` | 启用邮件功能 | 是 | `false` |
| `"MailFilename"` | 外部邮件配置文件路径（相对于 `Json/mail/`）| 是 | `""` |
| `"MailConfig"` | 内联邮件配置对象。见 [Mail Goal](#mail-goal) | 是 | `{}` |
| --- | --- | --- | --- |
| `"GatherFindKeys"` | 用于在采集配置文件之间切换的字符串列表 | 是 | `string[]` |


| BaseActionKeys | 描述 | 可选 | 默认值 |
| --- | --- | --- | --- |
| `"Jump.Key"` | 跳跃键 | 是 | `"Spacebar"` |
| `"Interact.Key"` | 与目标交互的键。支持修饰键。 | 是 | `"Alt-Home"` |
| `"InteractMouseOver.Key"` | 与鼠标悬停目标交互的键。支持修饰键。 | 是 | `"Alt-End"` |
| `"TargetLastTarget.Key"` | 选择上一个目标的键 | 是 | `"G"` |
| `"ClearTarget.Key"` | 清除当前目标的键。支持修饰键。 | 是 | `"Alt-Insert"` |
| `"StopAttack.Key"` | 停止攻击的键。支持修饰键。 | 是 | `"Alt-Delete"` |
| `"TargetNearestTarget.Key"` | 选择最近敌人的键 | 是 | `"Tab"` |
| `"TargetTargetOfTarget.Key"` | 选择目标的目标的键 | 是 | `"F"` |
| `"TargetPet.Key"` | 选择宠物的键 | 是 | `"Multiply"` |
| `"PetAttack.Key"` | 命令宠物攻击的键 | 是 | `"Subtract"` |
| `"TargetFocus.Key"` | 选择焦点目标（TBC+）或队友1（Vanilla）的键。支持修饰键。 | 是 | `"Alt-PageUp"` |
| `"FollowTarget.Key"` | 跟随目标的键。支持修饰键。 | 是 | `"Alt-PageDown"` |
| `"Mount.Key"` | 使用坐骑的键 | 是 | `"O"` |
| `"StandUp.Key"` | 站立/坐下的键 | 是 | `"X"` |
| --- | --- | --- | --- |
| `"ForwardKey"` | 向前移动的 [ConsoleKey](https://learn.microsoft.com/en-us/dotnet/api/system.consolekey) | 是 | `"UpArrow"` |
| `"BackwardKey"` | 向后移动的 [ConsoleKey](https://learn.microsoft.com/en-us/dotnet/api/system.consolekey) | 是 | `"DownArrow"` |
| `"TurnLeftKey"` | 左转的 [ConsoleKey](https://learn.microsoft.com/en-us/dotnet/api/system.consolekey) | 是 | `"LeftArrow"` |
| `"TurnRightKey"` | 右转的 [ConsoleKey](https://learn.microsoft.com/en-us/dotnet/api/system.consolekey) | 是 | `"RightArrow"` |

### IntVariables

允许用户在整個 [Class Configuration](#class-configuration) 范围内定义全局整型变量。

带`*buff_`前缀的光环技能（`Buff_`、`Debuff_`、`TDebuff_`、`TBuff_`、`FBuff_`）后定义的整数，是技能的ID。

例如，查看 Warlock 配置文件：
```json
"IntVariables": {
    "DOT_MIN_HEALTH%": 35,
    "TDebuff_Frost Fever": 237522,
    "TDebuff_Blood Plague": 237514,
    "FBuff_Rejuvenation": 12345,
    "Buff_Slice and Dice": 99999,
    "Debuff_Poison": 135368,
    "TBuff_Dispel on Target": 16846,
    "Item_Soul_Shard": 6265,
    "ITEM_ARROW": 2512,
    "MIN_COUNT_ARROW": 200,
    "AMMO_SLOT": 5
}
```

可以将多个技能 ID 分组到单个变量下：
```json
"IntVariables": {
    "Debuff_POISON": [136006, 136007, 136016, 136064, 136067, 136077, 136093, 134437, 132273, 132274, 132105],
    "Debuff_DISEASE": [136127, 136134, 134324, 135914]
}
```

然后就可以整体的在条件中进行判断
```json
"Requirements": ["Debuff_POISON > 1 || Debuff_DISEASE > 1"]
```

### StringVariables

与 [IntVariables](#intvariables) 类似，只是用于定义字符串值。

注意：如果 `value` 匹配任何 [`IntVariables`](#intvariables) 的键，则该 `value` 将被替换为 IntVariable 的值。

当变量名称以 `$ITEM_NAME` 开头时，该值将被替换为物品的英文本地化名称，在此示例中为 `Rough Arrow`。

当变量名称以 `$NPC_NAME` 开头时，该值将被替换为 NPC 的英文本地化名称。

```json
"StringVariables": {
    "$ITEM_NAME_ARROW": "ITEM_ARROW",
    "$AMMO_SLOT": "AMMO_SLOT"
}
```

### KeyActions

在[Understanding Class Configuration](#understanding-class-configuration-理解-class-configuration)的属性表中，`Pull`/`Flee`/`Combat`/`AssistFocus`/`Adhoc`/`Parallel`/`NPC`/`Wait`都表示了一系列的按键动作的集合，其中的每个按键动作都为一个[KeyAction](#keyaction)。

### KeyAction

每个 `KeyAction` 都有其自己的属性来描述和限定该动作，可以用 [Requirement(s)] 来为动作指定条件，来决定当前情况下是否执行该动作。

| 属性名称 | 描述 | 默认值 |
| --- | --- | --- |
| `"Name"` | KeyAction 的名称。**命名约定**：小写名称表示游戏中设置的宏（例如 `"stopattack"`、`"petattack"`），而大写名称表示法术（例如 `"Frostbolt"`、`"Healing Wave"`）。这影响 `ActionBarPopulator` 和动作条验证如何处理该条目。 | `""` |
| `"Key"` | 要按下的 [ConsoleKey](https://learn.microsoft.com/en-us/dotnet/api/system.consolekey)。支持修饰键前缀：`Shift-`、`Ctrl-`、`Alt-`（例如 `"Shift-1"`、`"Alt-F1"`） | `""` |
| `"Modifier"` | 按下键时要按住的修饰键。值：`"None"`、`"Shift"`、`"Ctrl"`、`"Alt"`。在 `Key` 中使用前缀的替代方案。**注意**：不支持组合修饰键（例如 `Shift-Alt`）— 仅支持单个修饰键。 | `"None"` |
| `"Cost"` | [Adhoc Goals](#adhoc-goals) 或 [NPC Goal](#npc-goals) 专用，按键动作的执行优先级 | `18` |
| `"PathFilename"` | [NPC Goal](#npc-goals) 专用，这是一个短路径，用于靠近 NPC 以避免墙壁等。 | `""` |
| `"HasCastBar"` | **自动检测**自法术的有效施法时间（`GetSpellInfo`），因此它能反映出像 5/5 Improved Corruption 这样将施法转变为瞬发的天赋。JSON 设置被接受但忽略。 | _派生_ |
| `"InCombat"` | 尝试施法时战斗状态是否重要？<br>可接受的值：<br>* `"any value for doesn't matter"`<br>* `"true"`<br>* `"false"` | `false` |
| `"Item"` | 像使用饰品、`Food`、`Drink` 这样的物品。<br>以下法术计为物品：`Throw`、`Auto Shot`、`Shoot` | `false` |
| `"PressDuration"` | 按住键的最小毫秒数 | `50` |
| `"Form"` | 施放此法术时需处于的形态/姿态<br>如果设置，会影响 `WhenUsable` | `Form.None` |
| `"Cooldown"` | **注意这不是游戏内冷却时间！**<br>KeyAction 可以再次使用前的毫秒时间。<br>当后端注册 `Key` 按下时，此属性将被更新。它没有来自游戏的反馈。 | `400` |
| `"Charge"` | 在设置 Cooldown 之前应该连续按键的次数 | `1` |
| `"School"` | 指示法术将造成的 [SchoolMask](#npcschoolimmunity) 元素类型。 | `None` |
| `"MacroText"` | 你可以指定一个宏文本或宏模板，其中可以包含变量。确保 MacroText 不超过 255 个字符。 | `""` |
| `"BaseAction"` | 绕过 CastingHandler 的防护措施（GCD 等待、法术队列检查、施法验证）。用于立即执行的无施法条或冷却的动作。见 [BaseActions](#baseactionkeys)。 | `false` |
| --- | --- | --- |
| `"WhenUsable"` | 映射到 [IsUsableAction](https://wowwiki-archive.fandom.com/wiki/API_IsUsableAction) | `false` |
| `"UseWhenTargetIsCasting"` | 检查目标施法/引导。<br>可接受的值：<br>* `null` → 忽略<br>* `false` → 当敌人不施法时<br>* `true` → 当敌人施法时 | `null` |
| `"Requirement"` | 单个 [Requirement](#requirement) | `false` |
| `"Requirements"` | [Requirement](#requirement) 列表 | `false` |
| `"Interrupt"` | 单个 [Requirement](#requirement) | `false` |
| `"Interrupts"` | [Requirement](#requirement) 列表 | `false` |
| `"CancelOnInterrupt"` | 如果 [Interrupt](#interrupt-requirement) [Requirement](#requirement) 满足，是否**取消**当前施法条施法（发送 ESC） | `false` |
| `"ResetOnNewTarget"` | 如果目标更改，是否重置 Cooldown | `false` |
| `"Log"` | 相关事件是否应出现在日志中 | `true` |
| `"UseMount"` | 是否使用坐骑？<br/>仅限于 [AdhocNpcGoals](#npc-goals)，如 `Repair`、`Sell`、`Vendor` 路径。 | `false` |
| --- | 按键施法前... | --- |
| `"BeforeCastFaceTarget"` | 尝试直视目标。<br>**注意**：可能不适用于所有场景。 | `false` |
| `"BeforeCastDelay"` | 延迟，以毫秒计。 | `0` |
| `"BeforeCastMaxDelay"` | 最大延迟，以毫秒计。<br>如果设置，则在 [`BeforeCastDelay`..`BeforeCastMaxDelay`] 之间使用随机延迟。 | `0` |
| `"BeforeCastStop"` | 停止移动。 | `false` |
| `"BeforeCastDismount"` | 是否下马。[Adhoc Goals](#adhoc-goals) 专用。 | `true` |
| --- | 成功施法后... | --- |
| `"AfterCastWaitSwing"` | 等待下一次近战攻击命中。<br>阻塞 **CastingHandler**。 | `false` |
| `"AfterCastWaitCastbar"` | 等待施法条完成，排除 `SpellQueueTimeMs`。<br>阻塞 **CastingHandler**。 | `false` |
| `"AfterCastWaitBuff"` | 等待光环（玩家-目标 Debuff/Buff）计数变化。<br>仅当光环**计数**变化时才能正常工作。<br>不适用于刷新已有的光环。<br>阻塞 **CastingHandler**。 | `false` |
| `"AfterCastAuraExpected"` | 刷新光环（玩家-目标 Debuff/Buff）。<br>仅为该操作添加额外的（`SpellQueueTimeMs`）Cooldown，以免重复自身。<br>不阻塞 **CastingHandler**。 | `false` |
| `"AfterCastWaitBag"` | 等待任何背包、背包变更。<br>阻塞 **CastingHandler**。 | `false` |
| `"AfterCastWaitCombat"` | 等待玩家进入战斗。<br>阻塞 **CastingHandler**。 | `false` |
| `"AfterCastWaitMeleeRange"` | 等待以下任一情况中断：<br>* 目标进入近战范围<br>* 目标开始施法<br>* 玩家受到伤害<br>阻塞 **CastingHandler**。 | `false` |
| `"AfterCastStepBack"` | 开始后退，以毫秒计。<br>如果值设置为 `-1`，则尝试使用整个剩余的 GCD 时间。<br>阻塞 **CastingHandler**。 | `0` |
| `"AfterCastWaitGCD"` | 全局冷却完全结束。<br>阻塞 **CastingHandler**。 | `false` |
| `"AfterCastDelay"` | 延迟，以毫秒计。<br>阻塞 **CastingHandler**。 | `0` |
| `"AfterCastMaxDelay"` | 延迟，以毫秒计。<br>如果设置，则在 [`AfterCastDelay`..`AfterCastMaxDelay`] 之间使用随机延迟。<br>阻塞 **CastingHandler**。 | `0` |
| --- | --- | --- |

### PathSettings

| 属性名 | 说明 | 是否选填 | 默认值 |
| ---- | ---- | ---- | ---- |
| `"PathFilename"` | 角色在存活状态时使用的[Path](#path) | 否 | `""` |
| `"Id"` | 用于标识路线配置，**必须为Unique Integer** | 是 | 从0开始自动递增（用户未手动指定时） |
| `"PathThereAndBack"` | 使用路线时，是否启用往返行进 | 是 | `true` |
| `"PathReduceSteps"` | 是否简化路径上坐标数量 | 是 | `false` |
| `"SideActivityRequirements"` | 用于限制目标搜寻时机的[Requirements](#requirement)列表，可严格约束角色沿路线行进 | 是 | `true` |

### Path
对应的路径JSON文件存放在`/Json/Path/`目录下。该文件存储了一组X、Y、Z的坐标点，角色会沿着这些坐标点组成路径进行巡逻。

### Follow Route Goal
目标为：程序将控制角色沿着[Class Configuration](#class-configuration)中的"Paths"对象或者"PathFilename"属性所预设的路径进行巡逻。

# Requirement (条件)

条件是任务循环的大脑，它们定义了**何时**执行某个任务：
- 没有条件，Bot 会随机胡乱的执行任务
- 条件让你创建能对当前条件环境下作出反应的智能循环
- 可以让你根据角色的生命值、法力值、Buff、Debuff 等来排列技能的优先级

条件必须是一个值为 bool 的表达式，当他为 `true` 时，[KeyAction](#keyaction)才能执行。

但并非所有的[KeyAction](#keyaction)都有`Requirement`或`Requirements`属性，而是依赖于：
* `Cooldown` — 手动设置（你设置使用频率）
* `ActionBarCooldownReader` — 自动填充（读取实际游戏冷却时间）
* `ActionBarCostReader` — 自动填充（检查是否有足够的法力/怒气/能量）

**常见的条件**

| 模式 | 示例 | 用例 |
| --- | --- | --- |
| 冷却结束即用 | 无条件，依赖 Cooldown | 主要伤害技能 |
| Buff 缺失时使用 | `"!Battle Shout"` | 自我 Buff |
| 低生命值时使用 | `"Health% < 30"` | 紧急治疗、治疗石 |
| 高资源时使用 | `"Rage > 50"` | 资源消耗技能 |
| 目标 Debuff 缺失时使用 | `"!Sunder Armor"` | 保持目标上的 Debuff |
| 用于斩杀目标 | `"TargetHealth% < 20"` | 斩杀类技能 |

也可以通过`Requirements`来指定一组条件（当然也可以只指定一条）

例如：
```json
{
    "Name": "Execute",                                            //<--- 无条件
    "Key": "7",
    "WhenUsable": true
},
{
    "Name": "Soul Shard",
    "Key": "9",
    "HasCastBar": true,
    "Requirements": ["TargetHealth% < 36", "!BagItem:6265:3"]     //<--- 条件列表
},
{
    "Name": "Curse of Weakness",
    "Key": "6",
    "WhenUsable": true,
    "Requirement": "!Curse of Weakness"                           //<--- 单个条件
}
```

### Negate a requirement

每个条件都可以通过在条件前添加 `否定关键字` 来取反。

公式：`[否定关键字][条件]`

| 否定关键字 |
| --- |
| `"!"` |

例如：
```json
"Requirement": "!BagItem:Item_Soul_Shard:3"
```
---

### And / Or multiple Requirements

两个或多个条件可以合并到一个条件对象中。

默认情况下，每个条件使用 `[and]` 运算符连接，这意味着要执行 [KeyAction](#keyaction)，`RequirementsObject` 中的每个成员都必须求值为 `true`。但此结构也允许使用 `[or]` 连接。同时支持嵌套括号。

公式：`[条件1] [运算符] [条件N]`

| 运算符 | 描述 |
| --- | --- |
| "&&" | 与 |
| "\|\|" | 或 |

例如：
```json
"Requirements": ["Has Pet", "TargetHealth% < 70 || TargetCastingSpell"]
"Requirement": "!Form:Druid_Bear && Health% < 50 || MobCount > 2",
"Requirement": "(Judgement of the Crusader && CD_Judgement <= GCD && TargetHealth% > 20) || TargetCastingSpell"
```
---

### Value base requirements

基于数值是最基本的条件表达式

公式：`[关键字] [运算符] [整数值]`

**注意：** `[整数值]` 始终在表达式的_右侧_

| 运算符 | 描述 |
| --- | --- |
| `==` | 等于 |
| `!=` | 不等于 |
| `<=` | 小于等于 |
| `>=` | 大于等于 |
| `<` | 小于 |
| `>` | 大于 |

算术运算符可用于构建复杂表达式：

| 运算符 | 描述 |
| --- | --- |
| `+` | 加法 |
| `-` | 减法 |
| `*` | 乘法 |
| `/` | 除法 |
| `%` | 取模（返回余数）。检查整除性请使用 `Deaths % 2 == 0` |

### Keyword

以下为完整的关键字列表，表示角色在游戏中可能遇到的相关参数

| 关键字 | 描述 |
| --- | --- |
| `Health%` | 玩家生命值百分比 |
| `TargetHealth%` | 目标生命值百分比 |
| `FocusHealth%` | 焦点目标生命值百分比 |
| `PetHealth%` | 宠物生命值百分比 |
| `Mana%` | 玩家法力值百分比 |
| `Mana` | 玩家当前法力值 |
| `Rage` | 玩家当前怒气值 |
| `Energy` | 玩家当前能量值 |
| `RunicPower` | 玩家当前符文能量值 |
| `BloodRune` | 玩家当前鲜血符文数 |
| `FrostRune` | 玩家当前冰霜符文数 |
| `UnholyRune` | 玩家当前邪恶符文数 |
| `TotalRune` | 玩家当前符文总数（鲜血+冰霜+邪恶+死亡） |
| `Combo Point` | 玩家当前在目标上的连击点数 |
| `Holy Power` | 玩家当前在目标上的圣能点数 |
| `Durability%` | 玩家已装备物品的平均耐久度。**0-99** 值范围 |
| `BagCount` | 玩家背包中的物品数量 |
| `FoodCount` | 返回最高数量的食物类型物品数量 |
| `DrinkCount` | 返回最高数量的饮料类型物品数量 |
| `MobCount` | 检测到的玩家周围存活且正在战斗的怪物数量 |
| `MinRange` | 玩家与目标之间的最小距离（码） |
| `MaxRange` | 玩家与目标之间的最大距离（码） |
| `LastAutoShotMs` | 距离上次检测到自动射击的时间（毫秒） |
| `LastMainHandMs` | 距离上次检测到主手近战攻击的时间（毫秒） |
| `SinceDamageTakenMs` | 自玩家生命值上次减少以来经过的时间（毫秒） |
| `MainHandSpeed` | 返回玩家主手攻击速度（毫秒） |
| `MainHandSwing` | 返回预测的下一次主手攻击时间 |
| `RangedSpeed` | 返回玩家远程武器攻击速度（毫秒） |
| `RangedSwing` | 返回预测的下一次远程武器攻击时间 |
| `SpellQueueWindow` | 返回 SpellQueueWindow C_Var |
| `-SpellQueueWindow` | 返回 SpellQueueWindow C_Var 的负值 |
| `BowReload` | 返回默认 500ms 时间加上玩家延迟 |
| `CD` | 返回上下文 [KeyAction](#keyaction) 的**游戏内**冷却时间（毫秒） |
| `CD_{KeyAction.Name}` | 返回指定 `{KeyAction.Name}` 的**游戏内**冷却时间（毫秒） |
| `Cost_{KeyAction.Name}` | 返回指定 `{KeyAction.Name}` 的消耗值 |
| --- | --- |
| `Buff_{IntVariable_Name}` | 返回指定 `{IntVariable_Name}` 的**玩家 Buff** 剩余时间（毫秒） |
| `Debuff_{IntVariable_Name}` | 返回指定 `{IntVariable_Name}` 的**玩家 Debuff** 剩余时间（毫秒） |
| --- | --- |
| `TBuff_{IntVariable_Name}` | 返回指定 `{IntVariable_Name}` 的**目标 Buff** 剩余时间（毫秒） |
| `TDebuff_{IntVariable_Name}` | 返回指定 `{IntVariable_Name}` 的**目标 Debuff** 剩余时间（毫秒） |
| --- | --- |
| `FBuff_{IntVariable_Name}` | 返回指定 `{IntVariable_Name}` 的**焦点 Buff** 剩余时间（毫秒） |
| --- | --- |
| `CurGCD` | 返回玩家当前剩余的 GCD 时间 |
| `GCD` | `1500` 值的别名 |
| `Kills` | 当前会话中玩家击杀的怪物数量 |
| `Deaths` | 当前会话中玩家死亡次数 |
| `Level` | 返回玩家当前等级 |
| `SessionSeconds` | 返回自会话开始以来经过的时间（秒）。<br>会话在按下 `Start Bot` 按钮时开始！ |
| `SessionMinutes` | 返回自会话开始以来经过的时间（分钟）。<br>会话在按下 `Start Bot` 按钮时开始！ |
| `SessionHours` | 返回自会话开始以来经过的时间（小时）。<br>会话在按下 `Start Bot` 按钮时开始！ |
| `ExpPerc` | 返回玩家当前升级经验百分比 |
| `UIMapId` | 返回玩家当前 [UIMapId](https://github.com/Xian55/WowClassicGrindBot/blob/9bea201760babc0f6670df2bd5c071c9c3f1220d/Json/dbc/som/WorldMapArea.json#L3C6-L3C11) |
| `PathDist` | 返回上下文 [PathSettings](#pathsettings) 中从玩家位置到路径的最近距离（码） |
| `PathDist_{PathSettings.Id}` | 返回指定路径到玩家位置的最近距离（码） |

值得一提的是 `CD_{KeyAction.Name}` 是一个动态值。<br>每个 [KeyAction](#keyaction) 有自己的`游戏内冷却时间`，与 `KeyAction.Cooldown` 这个配置中自定义的值不同！

单个条件示例：
```json
"Requirement": "Health%>70"
"Requirement": "TargetHealth%<=10"
"Requirement": "PetHealth% < 10"
"Requirement": "Mana% <= 40"
"Requirement": "Mana < 420"
"Requirement": "Energy >= 40"
"Requirement": "Rage > 90"
"Requirement": "BagCount > 80"
"Requirement": "MobCount > 1"
"Requirement": "MinRange < 5"
"Requirement": "MinRange > 15"
"Requirement": "MaxRange > 20"
"Requirement": "MaxRange > 35"
"Requirement": "LastAutoShotMs <= 500"
"Requirement": "LastMainHandMs <= 500"
"Requirement": "SinceDamageTakenMs < 5000"
"Requirement": "CD_Judgement < GCD"                 // 审判剩余冷却时间小于 GCD(1500)
"Requirement": "CD_Hammer of Justice > CD_Judgement" // 制裁之锤剩余冷却时间大于 8 秒
"Requirement": "Rage >= Cost_Heroic Strike"          // 玩家当前怒气大于等于英勇打击消耗
"Requirement": "MainHandSpeed > 3500"   // 主手攻击速度大于 3.5 秒
"Requirement": "MainHandSwing > -400"   // 距离预测的下一次主手攻击还有 400 毫秒
"Requirement": "Dead && Deaths % 2"           // 玩家当前死亡，且在本次会话中第二次死亡
"Requirement": "Deaths % 2 == 1"              // 玩家死亡奇数次（显式比较）
"Requirement": "Energy - Cost_Sinister_Strike >= 0"  // 施法后剩余足够能量
```

条件列表示例：
```json
"Requirements": [
    "TargetHealth% > DOT_MIN_HEALTH%",  // 其中 DOT_MIN_HEALTH% 是用户定义的变量
    "!Immolate"
],
```

#### 复杂表达式

比较操作的两侧可以是完整的算术表达式，混合变量、常量和运算符。括号控制求值顺序，使用标准数学优先级（`*`/`/`/`%` 优先级高于 `+`/`-`）。

例如：
```json
"Requirement": "(Health% + Mana%) / 2 > 50"             // 生命和法力的平均值高于 50%
"Requirement": "Energy - Cost_Sinister_Strike >= 0"      // 施法后剩余足够能量
"Requirement": "MainHandSwing > -SpellQueueWindow"       // 攻击计时器与队列窗口对比
"Requirement": "SessionMinutes % 40 < 20"                // 每 40 分钟周期的前 20 分钟
"Requirement": "Kills % 5 == 0 && SessionMinutes > 10"   // 10 分钟后每第 5 次击杀
```

例如 `CD_{KeyAction.Name}`：`Hammer of Justice` 引用 `Judgement` 的**游戏内**冷却时间来实现酷炫连招！
```json
{
    "Name": "Judgement",
    "Key": "1",
    "WhenUsable": true,
    "Requirements": ["Seal of the Crusader", "!Judgement of the Crusader"]
},
{
    "Name": "Hammer of Justice",
    "Key": "7",
    "WhenUsable": true,
    "Requirements": ["Judgement of the Crusader && CD_Judgement <= GCD && TargetHealth% > 20 || TargetCastingSpell"]
}
```
---

### npcID requirements

如果需要针对特定 NPC，可以使用此条件。

公式：`npcID:[intVariableKey/整数值]`

当变量是数组时（例如 `[6195, 6196, 6197]`），如果目标匹配数组中的**任何** NPC ID，则返回 true。

例如：

* `"Requirement": "!npcID:6195"` — 目标不是 [6195](https://tbc.wowhead.com/npc=6195)
* `"Requirement": "npcID:6195"` — 目标是 [6195](https://tbc.wowhead.com/npc=6195)
* `"Requirement": "npcID:MyAwesomeIntVariable"` — 单个或数组[IntVariable](#intvariables)
---

### Bag requirements

公式：`BagItem:[intVariableKey/itemid]:[count/IntVariablesKey]`

其中 `intVariableKey` 为 [IntVariableKey](#intvariables) 中定义的 Key，`itemid`就是直接使用物品的 ID。物品的数量也可以定义在 [IntVariableKey](#intvariables) 中，但一般情况下没有必要。

第一个表示物品的变量，也可以是一个数组，即多个物品的 ID（例如 `[5512, 5511, 5509]`），此时后面的 `count` 表示这些物品数量的总和。

例如：

* `"Requirement": "BagItem:5175"` — 背包中必须有 [大地图腾](https://tbc.wowhead.com/item=5175)
* `"Requirement": "BagItem:Item_Soul_Shard:3"` — 背包中必须有至少 [3个灵魂碎片](https://tbc.wowhead.com/item=6265)
* `"Requirement": "!BagItem:19007:1"` — 背包中不能有 [次级治疗石](https://tbc.wowhead.com/item=19007)
* `"Requirement": "!BagItem:6265:3"` — 背包中不能有 [3个灵魂碎片](https://tbc.wowhead.com/item=6265)
* `"Requirement": "!BagItem:MyAwesomeIntVariable:69"`
* `"Requirement": "BagItem:ITEM_HEALTHSTONE_ALL:1"` — 使用数组 IntVariable，如果背包中有数组中的**任何**物品则返回 true

---

### Form requirements

专门用于那些有形态变化的角色，指定形态下才可以执行该按键动作。

公式：`Form:[form]`

| form |
| --- |
| None |
| Druid_Bear |
| Druid_Aquatic |
| Druid_Cat |
| Druid_Travel |
| Druid_Moonkin |
| Druid_Flight |
| Druid_Cat_Prowl |
| Priest_Shadowform |
| Rogue_Stealth |
| Rogue_Vanish |
| Shaman_GhostWolf |
| Warrior_BattleStance |
| Warrior_DefensiveStance |
| Warrior_BerserkerStance |
| Paladin_Devotion_Aura |
| Paladin_Retribution_Aura |
| Paladin_Concentration_Aura |
| Paladin_Shadow_Resistance_Aura |
| Paladin_Frost_Resistance_Aura |
| Paladin_Fire_Resistance_Aura |
| Paladin_Sanctity_Aura |
| Paladin_Crusader_Aura |
| DeathKnight_Blood_Presence |
| DeathKnight_Frost_Presence |
| DeathKnight_Unholy_Presence |

例如：
```json
"Requirement": "Form:Druid_Bear"    // 必须在 `熊形态`
"Requirement": "!Form:Druid_Cat"    // 不能处于 `猫形态`
```

---

### Race requirements

指定种族条件，只有当为指定种族时才可以触发按键动作

公式：`Race:[race]`

| race |
| --- |
| None |
| Human |
| Orc |
| Dwarf |
| NightElf |
| Undead |
| Tauren |
| Gnome |
| Troll |
| Goblin |
| BloodElf |
| Draenei |

例如：
```json
"Requirement": "Race:Orc"          // 必须是 `兽人` 种族
"Requirement": "!Race:Human"       // 不能是 `人类` 种族
```

---
### Target requirements

如果当前目标必须是特定的生物类型，可以使用此条件。通过 DBC 生物数据库根据 NPC ID 查找目标类型。

用于仅对特定生物类型有效的技能（例如圣骑士对亡灵/恶魔的驱邪术）。

公式：`Target:[type]`

| type |
| --- |
| Beast |
| Dragonkin |
| Demon |
| Elemental |
| Giant |
| Undead |
| Humanoid |
| Critter |
| Mechanical |
| NotSpecified |
| Totem |
| NonCombatPet |
| GasCloud |

例如：
```json
"Requirement": "Target:Undead"                          // 目标必须是亡灵
"Requirement": "Target:Demon"                           // 目标必须是恶魔
"Requirement": "!Target:Humanoid"                       // 目标不能是人型生物
"Requirement": "Target:Undead || Target:Demon"           // 目标是亡灵或恶魔
```

---