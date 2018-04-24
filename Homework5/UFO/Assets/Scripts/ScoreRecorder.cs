using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRecorder : MonoBehaviour
{
    public int score;
    private Dictionary<Color, int> scoreTable = new Dictionary<Color, int>();

    void Start()
    {
        score = 0;
        scoreTable.Add(Color.blue, 1);
        scoreTable.Add(Color.yellow, 2);
        scoreTable.Add(Color.red, 5);
    }

    public void Record(GameObject disk)
    {
        score += scoreTable[disk.GetComponent<DiskData>().color];
    }

    public void Reset()
    {
        score = 0;
    }
}
