# Homework 1

> Unity3d-Learning      
>
> 离散仿真引擎基础

## 简答题

1.解释 游戏对象（GameObjects） 和 资源（Assets）的区别与联系。

2.下载几个游戏案例，分别总结资源、对象组织的结构（指资源的目录组织结构与游戏对象树的层次结构）

3.编写一个代码，使用 debug 语句来验证 [MonoBehaviour](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html) 基本行为或事件触发的条件

- 基本行为包括 Awake() Start() Update() FixedUpdate() LateUpdate()
- 常用事件包括 OnGUI() OnDisable() OnEnable()

4.查找脚本手册，了解 [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html)，Transform，Component 对象

- 分别翻译官方对三个对象的描述（Description）
- 描述下图中 table 对象（实体）的属性、table 的 Transform 的属性、 table 的部件
  - 本题目要求是把可视化图形编程界面与 Unity API 对应起来，当你在 Inspector 面板上每一个内容，应该知道对应 API。
  - 例如：table 的对象是 GameObject，第一个选择框是 activeSelf 属性。
- 用 UML 图描述 三者的关系（请使用 UMLet 14.1.1 stand-alone版本出图）

![4](images/ch02-homework.png)

5.整理相关学习资料，编写简单代码验证以下技术的实现：
- 查找对象
- 添加子对象
- 遍历对象树
- 清除所有子对象

6.资源预设（Prefabs）与 对象克隆 (clone)
- 预设（Prefabs）有什么好处？
- 预设与对象克隆 (clone or copy or Instantiate of Unity Object) 关系？
- 制作 table 预制，写一段代码将 table 预制资源实例化成游戏对象

7.尝试解释组合模式（Composite Pattern / 一种设计模式）。使用 BroadcastMessage() 方法
- 向子对象发送消息