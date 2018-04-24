# Homework 4

> Unity3d-Learning 
>
> 与游戏世界交互
>
> **演示视频：** http://v.youku.com/v_show/id_XMzU0NDkxNDYzNg==.html?spm=a2hzp.8244740.0.0

编写一个简单的鼠标打飞碟（Hit UFO）游戏

- 游戏内容要求：
  1. 游戏有 n 个 round，每个 round 都包括10 次 trial；
  2. 每个 trial 的飞碟的色彩、大小、发射位置、速度、角度、同时出现的个数都可能不同。它们由该 round 的 ruler 控制；
  3. 每个 trial 的飞碟有随机性，总体难度随 round 上升；
  4. 鼠标点中得分，得分规则按色彩、大小、速度不同计算，规则可自由设定。
- 游戏的要求：
  - 使用带缓存的工厂模式管理不同飞碟的生产与回收，该工厂必须是场景单实例的！具体实现见参考资源 Singleton 模板类
  - 尽可能使用前面 MVC 结构实现人机交互与游戏模型分离