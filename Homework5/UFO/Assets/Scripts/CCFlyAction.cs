using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCFlyAction : SSAction
{

    float gravity;
    float xSpeed;
    Vector3 direction;
    float time;
    Rigidbody rigidbody;

    public override void Start()
    {
        xSpeed = gameobject.GetComponent<DiskData>().speed;
        direction = gameobject.GetComponent<DiskData>().direction;
        enable = true;
        gravity = 8;
        time = 0;
        rigidbody = this.gameobject.GetComponent<Rigidbody>();
        if (rigidbody)
        {
            rigidbody.velocity = xSpeed * direction;
        }
    }

    public override void Update()
    {
        if (gameobject.activeSelf)
        {
            time += Time.deltaTime;
            transform.Translate(Vector3.down * gravity * time * Time.deltaTime);
            transform.Translate(direction * xSpeed * Time.deltaTime);
            if (this.transform.position.y < -5)
            {
                this.destroy = true;
                this.enable = false;
                this.callback.SSActionEvent(this);
            }
        }

    }

    public override void FixedUpdate()
    {
        if (gameobject.activeSelf)
        {
            if (this.transform.position.y < -5)
            {
                this.destroy = true;
                this.enable = false;
                this.callback.SSActionEvent(this);
            }
        }
    }

    public static CCFlyAction GetCCAction()
    {
        CCFlyAction action = ScriptableObject.CreateInstance<CCFlyAction>();
        return action;
    }
}