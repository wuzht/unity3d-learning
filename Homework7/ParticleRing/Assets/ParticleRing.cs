using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 粒子的位置信息
public class CirclePosition
{
    public float radius = 0f;
    public float angle = 0f;
    public float time = 0f;
    public CirclePosition(float r, float a, float t)
    {
        radius = r;
        angle = a;
        time = t;
    }
}

public class ParticleRing : MonoBehaviour {
    private ParticleSystem particleSys;
    private ParticleSystem.Particle[] particlesArr;
    private CirclePosition[] circlePositions;

    public int count = 10000;
    public float size = 0.03f;
    public float minRadius = 5.0f;
    public float maxRadius = 12.0f;
    public bool clockwise = true;
    public float speed = 2f;
    public float pingPong = 0.02f;

    public Gradient colorGradient;

    // Use this for initialization
    void Start()
    {
        particlesArr = new ParticleSystem.Particle[count];
        circlePositions = new CirclePosition[count];

        particleSys = this.GetComponent<ParticleSystem>();
        particleSys.startSpeed = 0;
        particleSys.startSize = size;
        particleSys.loop = false;
        particleSys.maxParticles = count;
        //particleSys.startColor = Color.white;
        particleSys.Emit(count);
        particleSys.GetParticles(particlesArr);

        // 初始化梯度颜色控制器  
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[5];
        alphaKeys[0].time = 0.0f; alphaKeys[0].alpha = 1.0f;
        alphaKeys[1].time = 0.4f; alphaKeys[1].alpha = 0.4f;
        alphaKeys[2].time = 0.6f; alphaKeys[2].alpha = 1.0f;
        alphaKeys[3].time = 0.9f; alphaKeys[3].alpha = 0.4f;
        alphaKeys[4].time = 1.0f; alphaKeys[4].alpha = 0.9f;
        GradientColorKey[] colorKeys = new GradientColorKey[2];
        colorKeys[0].time = 0.0f; colorKeys[0].color = Color.white;
        colorKeys[1].time = 1.0f; colorKeys[1].color = Color.white;
        colorGradient.SetKeys(colorKeys, alphaKeys);

        RandomlySpread();
    }

    private int level = 10;
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < count; i++)
        {
            if (clockwise)
                circlePositions[i].angle -=
                    (i % level + 1) * (speed / circlePositions[i].radius / level);
            else
                circlePositions[i].angle +=
                    (i % level + 1) * (speed / circlePositions[i].radius / level);

            circlePositions[i].angle = (360.0f + circlePositions[i].angle) % 360.0f;
            circlePositions[i].time += Time.deltaTime;
            circlePositions[i].radius +=
                Mathf.PingPong(circlePositions[i].time / minRadius / maxRadius, pingPong) -
                pingPong / 2.0f;

            float theta = circlePositions[i].angle / 180 * Mathf.PI;
            particlesArr[i].position =
                new Vector3(circlePositions[i].radius * Mathf.Cos(theta),
                0f, circlePositions[i].radius * Mathf.Sin(theta));
            particlesArr[i].color = colorGradient.Evaluate(circlePositions[i].angle / 360.0f);
        }
        particleSys.SetParticles(particlesArr, particlesArr.Length);
    }

    void RandomlySpread()
    {
        for (int i = 0; i < count; i++)
        {
            float midRadius = (maxRadius + minRadius) / 2;
            float minRate = Random.Range(1.0f, midRadius / minRadius);
            float maxRate = Random.Range(midRadius / maxRadius, 1.0f);
            float radius = Random.Range(minRadius * minRate, maxRadius * maxRate);

            float angle = Random.Range(0.0f, 360.0f);
            float theta = angle / 180 * Mathf.PI;

            float time = Random.Range(0.0f, 360.0f);

            circlePositions[i] = new CirclePosition(radius, angle, time);

            particlesArr[i].position =
                new Vector3(circlePositions[i].radius * Mathf.Cos(theta),
                0f, circlePositions[i].radius * Mathf.Sin(theta));
        }

        particleSys.SetParticles(particlesArr, particlesArr.Length);
    }
}
