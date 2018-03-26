# Homework 1

> Unity3d-Learning      
>
> 离散仿真引擎基础

## 简答题

1.解释 游戏对象（GameObjects） 和 资源（Assets）的区别与联系。

- 游戏对象（GameObjects）

  > 游戏对象 (GameObject)是所有其他组件 (Component) 的容器。游戏中的所有对象本质上都是游戏对象。游戏对象包括：空、3D物体（立方体 、 球体 、 胶囊 、 圆柱体 、 平面和四边形 …）、2D物体（精灵/图片）、摄像机、灯光（平面，聚光，…）、音频、UI 元素、粒子系统、……

- 资源（Assets）

  > 资源是任何可以在游戏或项目中使用的项目的代表。资源可能来自于Unity之外创建的文件，如三维模型、音频文件、图像或Unity支持的任何其他类型的文件。也有一些可以在Unity中创建的资源类型，如动画师控制器、音频混音器或渲染纹理。

- 联系

  > 游戏对象可以成为资源从而作为模板使用。而资源可以包含游戏对象、图像、音频、模型、代码等。

2.下载几个游戏案例，分别总结资源、对象组织的结构（指资源的目录组织结构与游戏对象树的层次结构）

3.编写一个代码，使用 debug 语句来验证 [MonoBehaviour](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html) 基本行为或事件触发的条件

- 基本行为包括 Awake() Start() Update() FixedUpdate() LateUpdate()
- 常用事件包括 OnGUI() OnDisable() OnEnable()

4.查找脚本手册，了解 [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html)，Transform，Component 对象

- 分别翻译官方对三个对象的描述（Description）

  > **GameObject**
  >
  > *The **GameObjects** are the fundamental objects in Unity that represent characters, props and scenery. They do not accomplish much in themselves but they act as containers for Components, which implement the real functionality.*
  >
  > 游戏对象是代表人物、道具和布景的基本对象。它们本身没有实现太多功能，但它们充当组件的容器，而容器实现真正的功能。

  >  **Transform** 
  >
  >  *The **Transform** is used to store a GameObject’s position, rotation, scale and parenting state and is thus very important.*
  >
  >  变换是用来存储一个对象的位置、旋转、尺度和父对象的状态的，是非常重要的。

  > **Component**
  >
  > Base class for everything attached to GameObjects.
  >
  > 组件是所有附属于游戏对象的基类。

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