如果某项属性未在配置项或示例中明确注明，则默认使用默认值。
配置文件存放在/Json/Profile目录中，该配置文件用于预设游戏角色的各种行为：包括非战斗状态与战斗状态下释放哪些技能、售卖/修理物品的坐标，以及生效哪些BUFF等等。

以下为各个section(顶层对象)的作用说明：

# 配置项说明表
| 属性名 | 说明 | 是否选填 | 默认值 |
| ---- | ---- | ---- | ---- |
| `"Log"` | 是否为[KeyAction(s)](#keyaction)开启日志记录，修改后需重启 | 是 | `true` |
| `"LogBagChanges"` | 是否开启背包变动日志 | 是 | `true` |
| `"Loot"` | 是否拾取怪物掉落物 | 是 | `true` |
| `"Skin"` | 是否对怪物进行剥皮 | 是 | `false` |
| `"Herb"` | 是否采集怪物身上的草药 | 是 | `false` |
| `"Mine"` | 是否对怪物进行采矿 | 是 | `false` |
| `"Salvage"` | 是否拆解怪物战利品 | 是 | `false` |
| `"UseMount"` | 条件允许时是否使用坐骑 | 是 | `false` |
| `"AllowPvP"` | 是否与对立阵营单位交战 | 是 | `false` |
| `"TargetNeutral"` | 除敌对（红色）目标外，是否识别中立（黄色）名称单位。1-5级新手区域怪物多为中立，建议开启 | 是 | `false` |
| `"AutoPetAttack"` | 宠物是否自动发起攻击 | 是 | `true` |
| `"CrossZoneSearch"` | 允许跨区域搜索NPC，用于跨区域行进路线 | 是 | `false` |
| `"KeyboardOnly"` | 仅使用键盘进行交互，详见[KeyboardOnly](#keyboardonly) | 否 | `true` |
| `"PathFilename"` | 角色存活期间使用的[Path](#path)，与下面的"Paths"对象二选一| 否 | `""` |
| `"PathThereAndBack"` | 使用路线时，是否开启往返行进，详见[should go start to and reverse](#there-and-back) | 是 | `true` |
| `"PathReduceSteps"` | 是否精简路线点位数量 | 是 | `false` |
| `"SideActivityRequirements"` | 限制搜寻目标的[Requirements](#requirement)列表，用于规范角色沿路线行进的范围 | 是 | `true` |
| `"Paths"` | [PathSettings](#pathsettings)数组。二选一：配置此数组使用多条线路，或使用单条线路的"PathFilename"属性 | 是 | `[]` |
| `"Mode"` | 设置程序的[behaviour](#modes)类型 | 是 | `Mode.Grind` |
| `"NPCMaxLevels_Above"` | 目标怪物等级最高可高于角色多少级 | 是 | `1` |
| `"NPCMaxLevels_Below"` | 目标怪物等级最低可低于角色多少级 | 是 | `7` |
| `"CheckTargetGivesExp"` | 仅攻击能提供经验值的目标 | 是 | `false` |
| `"Blacklist"` | 黑名单，填写名称/名称片段，列表内单位将被屏蔽攻击 | 是 | `[""]` |
| `"TargetMask"` | [TargetMask](#targetmask)，限定可交互的[UnitClassification](https://wowpedia.fandom.com/wiki/API_UnitClassification)类型 | 是 | `"Normal, Trivial, Rare"` |
| `"NpcSchoolImmunity"` | 怪物ID列表，对应单位拥有一项或多项[SchoolMask](#npcschoolimmunity)免疫效果 | 是 | `""` |
| `"IntVariables"` | 自定义整型/整型数组变量列表，详见[IntVariables](#intvariables) | 是 | `[]` |
| `"StringVariables"` | 自定义字符串变量列表，详见[StringVariables](#stringvariables) | 是 | `[]` |
| `"Pull"` | 触发[Pull Goal](#pull-goal)时执行的[KeyActions](#keyactions) | 是 | `{}` |
| `"Flee"` | 触发[Flee Goal](#flee-goal)时执行的[KeyActions](#keyactions) | 是 | `{}` |
| `"Combat"` | 触发[Combat Goal](#combat-goal)时执行的[KeyActions](#keyactions) | 否 | `{}` |
| `"AssistFocus"` | 触发[Assist Focus Goal](#assist-focus-goal)时执行的[KeyActions](#keyactions) | 否 | `{}` |
| `"Adhoc"` | 触发[Adhoc Goals](#adhoc-goals)时执行的[KeyActions](#keyactions) | 是 | `{}` |
| `"Parallel"` | 触发[Parallel Goal](#parallel-goals)时执行的[KeyActions](#keyactions) | 是 | `{}` |
| `"NPC"` | 触发[NPC Goal](#npc-goals)时执行的[KeyActions](#keyactions) | 是 | `{}` |
| `"Wait"` | 触发[Wait Goal](#wait-goals)时执行的[KeyActions](#keyactions) | 是 | `{}` |
| `"Mail"` | 是否开启邮件功能 | 是 | `false` |
| `"MailFilename"` | 外部邮件配置文件路径（相对路径：`Json/mail/` 目录） | 是 | `""` |
| `"MailConfig"` | 内嵌式邮件配置对象，详见[Mail Goal](#mail-goal) | 是 | `{}` |
| `"GatherFindKeys"` | 切换采集配置方案的关键词列表 | 是 | 字符串数组 |

## 基础按键配置
| 属性名 | 说明 | 是否选填 | 默认值 |
| ---- | ---- | ---- | ---- |
| `"Jump.Key"` | 跳跃按键 | 是 | `"Spacebar"` |
| `"Interact.Key"` | 与当前目标交互按键，支持组合键 | 是 | `"Alt-Home"` |
| `"InteractMouseOver.Key"` | 与鼠标悬停目标交互按键，支持组合键 | 是 | `"Alt-End"` |
| `"TargetLastTarget.Key"` | 选中上一个目标按键 | 是 | `"G"` |
| `"ClearTarget.Key"` | 取消当前目标按键，支持组合键 | 是 | `"Alt-Insert"` |
| `"StopAttack.Key"` | 停止攻击按键，支持组合键 | 是 | `"Alt-Delete"` |
| `"TargetNearestTarget.Key"` | 选中最近敌对目标按键 | 是 | `"Tab"` |
| `"TargetTargetOfTarget.Key"` | 选中目标的目标按键 | 是 | `"F"` |
| `"TargetPet.Key"` | 选中宠物按键 | 是 | `"Multiply"` |
| `"PetAttack.Key"` | 命令宠物攻击按键 | 是 | `"Subtract"` |
| `"TargetFocus.Key"` | 选中焦点目标（燃烧的远征及后续版本）/选中队友1（经典旧世），支持组合键 | 是 | `"Alt-PageUp"` |
| `"FollowTarget.Key"` | 跟随当前目标按键，支持组合键 | 是 | `"Alt-PageDown"` |
| `"Mount.Key"` | 召唤坐骑按键 | 是 | `"O"` |
| `"StandUp.Key"` | 站立/坐下切换按键 | 是 | `"X"` |
| `"ForwardKey"` | 向前移动按键，参考[ConsoleKey](https://learn.microsoft.com/en-us/dotnet/api/system.consolekey) | 是 | `"UpArrow"` |
| `"BackwardKey"` | 向后移动按键，参考[ConsoleKey](https://learn.microsoft.com/en-us/dotnet/api/system.consolekey) | 是 | `"DownArrow"` |
| `"TurnLeftKey"` | 向左转向按键，参考[ConsoleKey](https://learn.microsoft.com/en-us/dotnet/api/system.consolekey) | 是 | `"LeftArrow"` |
| `"TurnRightKey"` | 向右转向按键，参考[ConsoleKey](https://learn.microsoft.com/en-us/dotnet/api/system.consolekey) | 是 | `"RightArrow"` |


### PathSettings

| 属性名 | 说明 | 是否选填 | 默认值 |
| ---- | ---- | ---- | ---- |
| `"PathFilename"` | 角色在存活状态时使用的[Path](#path) | 否 | `""` |
| `"Id"` | 用于标识路线配置，**必须为Unique Integer** | 是 | 从0开始自动递增（用户未手动指定时） |
| `"PathThereAndBack"` | 使用路线时，是否启用往返行进 | 是 | `true` |
| `"PathReduceSteps"` | 是否简化路径上坐标数量 | 是 | `false` |
| `"SideActivityRequirements"` | 用于限制目标搜寻时机的[Requirements](#requirement)列表，可严格约束角色沿路线行进 | 是 | `true` |

### KeyActions 
表示一系列按键动作[KeyAction](#keyaction)的类型，

### KeyAction

### Path
对应的路径JSON文件存放在`/Json/Path/`目录下。该文件存储了一组X、Y、Z的坐标点，角色会沿着这些坐标点组成路径进行巡逻。

### Follow Route Goal
目标为：程序将控制角色沿着[Class Configuration](#class-configuration)中的"Paths"对象或者"PathFilename"属性所预设的路径进行巡逻。