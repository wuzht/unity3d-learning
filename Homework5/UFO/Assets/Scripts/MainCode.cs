using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSDirector : System.Object
{
    private static SSDirector myInstance;
    public ISceneController currentSceneController { get; set; }
    private SSDirector() { }
    public static SSDirector GetInstance()
    {
        if (myInstance == null)
            myInstance = new SSDirector();
        return myInstance;
    }

    public int GetFPS()
    {
        return Application.targetFrameRate;
    }

    public void SetFPS(int fps)
    {
        Application.targetFrameRate = fps;
    }
}

public enum GameState { ROUND_START, ROUND_FINISH, RUNNING, PAUSE, START }
public enum ActionMode { PHYSIC, KINEMATIC, NOTSET }

public interface IUserAction
{
    void GameOver();
    GameState GetGameState();
    void SetGameState(GameState gs);
    int GetScore();
    void Hit(Vector3 pos);
    ActionMode GetMode();
    void SetMode(ActionMode m);
}

public interface ISceneController
{
    void LoadResources();
}

public interface IActionManager
{
    void StartThrow(Queue<GameObject> diskQueue);
    int getDiskNumber();
    void setDiskNumber(int num);
}