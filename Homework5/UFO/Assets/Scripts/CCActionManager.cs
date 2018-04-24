﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCActionManager : MonoBehaviour, ISSActionCallback, IActionManager
{

    public FirstSceneController sceneController;
    //public List<CCFlyAction> Fly;
    public int DiskNumber = 0;
    //private List<SSAction> used = new List<SSAction>();
    //private List<SSAction> free = new List<SSAction>();
    private Dictionary<int, SSAction> actions = new Dictionary<int, SSAction>();
    private List<SSAction> waitingAdd = new List<SSAction>();
    private List<int> waitingDelete = new List<int>();

    protected void Update()
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
                ac.Update();
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


    protected void Start()
    {
        sceneController = (FirstSceneController)SSDirector.GetInstance().currentSceneController;
        sceneController.actionManager = this;
    }

    public void SSActionEvent(SSAction source, SSActionEventType events = SSActionEventType.Completed,
        int intParam = 0, string strParam = null, UnityEngine.Object objectParam = null)
    {
        if (source is CCFlyAction)
        {
            DiskNumber--;
            /*
            DiskFactory df = Singleton<DiskFactory>.Instance;
            df.FreeDisk(source.gameobject);
            FreeSSAction(source);*/
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
