using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSceneControl : MonoBehaviour, ISceneController, IUserAction
{
    public CCActionManager actionManager { get; set; }
    public ScoreRecorder scoreRecorder { get; set; }
    public Queue<GameObject> diskQueue = new Queue<GameObject>();
    private int diskNumber;
    public int currentRound = -1;
    public int round = 3;
    private float time = 0;
    private GameState gameState = GameState.START;

    void Awake()
    {
        SSDirector director = SSDirector.GetInstance();
        director.SetFPS(60);
        director.currentSceneController = this;
        gameObject.AddComponent<UserGUI>();
        diskNumber = 10;
        gameObject.AddComponent<ScoreRecorder>();
        gameObject.AddComponent<DiskFactory>();
        scoreRecorder = Singleton<ScoreRecorder>.Instance;
        LoadResources();
    }


    private void Update()
    { 
        if (actionManager.DiskNumber == 0 && gameState == GameState.RUNNING)
        {
            gameState = GameState.ROUND_FINISH;    
        }

        if (actionManager.DiskNumber == 0 && gameState == GameState.ROUND_START)
        {
            currentRound = (currentRound + 1) % round;
            NextRound();
            actionManager.DiskNumber = 10;
            gameState = GameState.RUNNING;
        }

        if (time > 1)
        {
            ThrowDisk();
            time = 0;
        }
        else
            time += Time.deltaTime;
    }

    private void NextRound()
    {
        DiskFactory df = Singleton<DiskFactory>.Instance;
        for (int i = 0; i < diskNumber; i++)
        {
            diskQueue.Enqueue(df.GetDisk(currentRound));
        }
        actionManager.StartThrow(diskQueue);
    }

    void ThrowDisk()
    {
        if (diskQueue.Count != 0)
        {
            GameObject disk = diskQueue.Dequeue();
            disk.transform.position = new Vector3(-disk.GetComponent<DiskData>().direction.x * Random.Range(0, 20), Random.Range(5, 15), Random.Range(5, 15));
            disk.SetActive(true);
        }
    }

    public void LoadResources()
    {
    }

    public void GameOver()
    {
        GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 60, 100, 60), "您输了");
    }

    public int GetScore()
    {
        return scoreRecorder.score;
    }

    public GameState GetGameState()
    {
        return gameState;
    }

    public void SetGameState(GameState gs)
    {
        gameState = gs;
    }

    public void Hit(Vector3 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if (hit.collider.gameObject.GetComponent<DiskData>() != null)
            {
                scoreRecorder.Record(hit.collider.gameObject);
                hit.collider.gameObject.transform.position = new Vector3(0, -5, 0);
            }
        }
    }
}