using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    private FirstSceneController sceneController;
    private IUserAction action;
    private bool isGameStart = false;

    void Start()
    {
        sceneController = (FirstSceneController)SSDirector.GetInstance().currentSceneController;
        action = SSDirector.GetInstance().currentSceneController as IUserAction;
    }

    private void OnGUI()
    {
        
        if (action.GetMode() == ActionMode.NOTSET)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 - 90, 100, 60), "运动学运动"))
            {
                action.SetMode(ActionMode.KINEMATIC);
                if (action.GetMode() == ActionMode.KINEMATIC)
                    Debug.Log("运动学运动\n");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 - 30, 100, 60), "物理运动"))
            {
                action.SetMode(ActionMode.PHYSIC);
                if (action.GetMode() == ActionMode.PHYSIC)
                    Debug.Log("物理运动\n");
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Vector3 pos = Input.mousePosition;
                action.Hit(pos);
            }
            GUIStyle fontStyle1 = new GUIStyle();
            fontStyle1.fontSize = 20;
            fontStyle1.normal.textColor = Color.black;
            GUIStyle fontStyle2 = new GUIStyle();
            fontStyle2.fontSize = 20;
            fontStyle2.normal.textColor = Color.red;
            int roundNumShown = (sceneController.currentRound + 1) == 0 ? 1 : (sceneController.currentRound + 1);
            GUI.Label(new Rect(Screen.width / 2 + 20, Screen.height * (float)0.05, 100, 100), "回合：" + roundNumShown, fontStyle1);
            GUI.Label(new Rect(Screen.width / 2 - 120, Screen.height * (float)0.05, 100, 100), "您的得分：" + action.GetScore().ToString(), fontStyle1);
            if (!isGameStart && GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 - 60, 100, 60), "开始游戏"))
            {
                isGameStart = true;
                action.SetGameState(GameState.ROUND_START);
            }

            if (isGameStart && sceneController.currentRound < 2 && action.GetGameState() == GameState.ROUND_FINISH && GUI.Button(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 60, 100, 60), "下一回合"))
            {
                action.SetGameState(GameState.ROUND_START);
            }

            if (isGameStart && action.GetGameState() == GameState.ROUND_FINISH && sceneController.currentRound >= 2)
            {
                GUI.Label(new Rect(Screen.width / 2 - 140, Screen.height * (float)0.15, 100, 100), "游戏结束！您的得分为：" + action.GetScore().ToString(), fontStyle2);
                if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 - 60, 100, 60), "重新开始"))
                {
                    sceneController.currentRound = -1;
                    sceneController.scoreRecorder.score = 0;
                    action.SetGameState(GameState.ROUND_START);
                }
            }
        }
        
    }
}