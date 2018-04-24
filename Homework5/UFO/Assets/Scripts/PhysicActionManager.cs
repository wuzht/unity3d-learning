﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicActionManager : MonoBehaviour, IActionManager, ISSActionCallback
{
    public FirstSceneController sceneController;
    public int DiskNumber = 0;
    private List<SSAction> waitingAdd = new List<SSAction>();
    private List<int> waitingDelete = new List<int>();
    private Dictionary<int, SSAction> actions = new Dictionary<int, SSAction>();
    
    protected void Start()
    {
        sceneController = (FirstSceneController)SSDirector.GetInstance().currentSceneController;
        sceneController.actionManager = this;

    }

    protected void FixedUpdate()
    {
        foreach (SSAction ac in waitingAdd)
            actions[ac.GetInstanceID()] = ac;
        waitingAdd.Clear();

        foreach (KeyValuePair<int, SSAction> kv in actions)
        {
            SSAction ac = kv.Value;
            if (ac.destroy)
            {
                waitingDelete.Add(ac.GetInstanceID());
            }
            else if (ac.enable)
            {
                ac.FixedUpdate();
            }
        }

        foreach (int key in waitingDelete)
        {
            SSAction ac = actions[key];
            actions.Remove(key);
            DestroyObject(ac);
        }
        waitingDelete.Clear();
    }

    public void RunAction(GameObject gameobject, SSAction action, ISSActionCallback manager)
    {
        action.gameobject = gameobject;
        action.transform = gameobject.transform;
        action.callback = manager;
        waitingAdd.Add(action);
        action.Start();
    }

    public void SSActionEvent(SSAction source, SSActionEventType events = SSActionEventType.Completed, int intParam = 0,
        string strParam = null, UnityEngine.Object objectParam = null)
    {
        if (source is CCFlyAction)
        {
            DiskNumber--;
            source.gameobject.SetActive(false);
        }
    }

    public void StartThrow(Queue<GameObject> diskQueue)
    {
        CCFlyActionFactory cf = Singleton<CCFlyActionFactory>.Instance;
        foreach (GameObject tmp in diskQueue)
        {
            RunAction(tmp, cf.GetSSAction(), (ISSActionCallback)this);
        }
    }

    public void setDiskNumber(int num)
    {
        DiskNumber = num;
    }

    public int getDiskNumber()
    {
        return DiskNumber;
    }  
}
