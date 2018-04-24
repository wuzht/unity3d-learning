using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCFlyAction : SSAction
{

    float gravity;
    float xSpeed;
    Vector3 direction;
    float time;

    public override void Start()
    {
        xSpeed = gameobject.GetComponent<DiskData>().speed;
        direction = gameobject.GetComponent<DiskData>().direction;
        enable = true;
        gravity = 15;
        time = 0;
    }

    public override void Update()
    {
        if (gameobject.activeSelf)
        {
            time += Time.deltaTime;
            transform.Translate(Vector3.down * gravity * time * Time.deltaTime);
            transform.Translate(direction * xSpeed * Time.deltaTime);
            if (this.transform.position.y < -2)
            {
                this.destroy = true;
                this.enable = false;
                this.callback.SSActionEvent(this);
            }
        }

    }

    public static CCFlyAction GetSSAction()
    {
        CCFlyAction action = ScriptableObject.CreateInstance<CCFlyAction>();
        return action;
    }
}