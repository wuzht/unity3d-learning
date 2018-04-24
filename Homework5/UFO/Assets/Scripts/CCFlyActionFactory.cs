using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCFlyActionFactory : MonoBehaviour
{
    private List<int> wait = new List<int>();
    private Dictionary<int, SSAction> used = new Dictionary<int, SSAction>();
    private List<SSAction> free = new List<SSAction>();
   
    public CCFlyAction Fly;

    void Start()
    {
        Fly = CCFlyAction.GetCCAction();
    }

    private void Update()
    {
        foreach (var temp in used.Values)
        {
            if (temp.destroy)
            {
                wait.Add(temp.GetInstanceID());
            }
        }

        foreach (int temp in wait)
        {
            FreeSSAction(used[temp]);
        }
        wait.Clear();
    }

    public void FreeSSAction(SSAction action)
    {
        SSAction tmp = null;
        int key = action.GetInstanceID();
        if (used.ContainsKey(key))
        {
            tmp = used[key];
        }

        if (tmp != null)
        {
            tmp.Reset();
            free.Add(tmp);
            used.Remove(key);
        }
    }

    public SSAction GetSSAction()
    {
        SSAction action = null;
        if (free.Count > 0)
        {
            action = free[0];
            free.Remove(free[0]);
        }
        else
        {
            action = ScriptableObject.Instantiate<CCFlyAction>(Fly);
        }
        used.Add(action.GetInstanceID(), action);
        return action;
    }

    public void Clear()
    {
        foreach (var temp in used.Values)
        {
            temp.enable = false;
            temp.destroy = true;
        }
    }
}
