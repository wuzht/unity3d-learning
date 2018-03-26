using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToe: MonoBehaviour {
    //grids 3*3的二维数组，表示每一格的状态，原始状态为0，X为1，O为2
    int [,]grids = new int[3, 3];
    // isXGrid 是否为X格子
    bool isXGrid = true;
	void Start()
    {
        Reset();
    }

    void Update()
    {

    }

    public void OnGUI()
    {
        if (GUI.Button(new Rect(500, 0, 180, 80), "Start/Restart Game"))
            Reset();
        //GameStatus 游戏输赢状态，进行中为0，X胜为1，O胜为2，平局为3
        int GameStatus = CheckGameStatus();
        if (GameStatus == 1)
            GUI.Label(new Rect(570, 80, 180, 40), "X win");
        else if (GameStatus == 2)
            GUI.Label(new Rect(570, 80, 180, 40), "O win");
        else if (GameStatus == 3)
            GUI.Label(new Rect(570, 80, 180, 40), "Tie");
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                if (grids[i, j] == 1)
                    GUI.Button(new Rect(500 + 60 * i, 100 + 60 * j, 60, 60), "X");
                else if (grids[i, j] == 2)
                    GUI.Button(new Rect(500 + 60 * i, 100 + 60 * j, 60, 60), "O");
                if (GUI.Button(new Rect(500 + 60 * i, 100 + 60 * j, 60, 60), ""))
                {
                    if (GameStatus == 0)
                    {
                        if (isXGrid)
                            grids[i, j] = 1;
                        else
                            grids[i, j] = 2;
                        isXGrid = !isXGrid;
                    }
                }
            }
        }
    }

    public void Reset()
    {
        for (int i = 0; i < 3; ++i)
            for (int j = 0; j < 3; ++j)
                grids[i, j] = 0;
        isXGrid = true;
    }

    public int CheckGameStatus()
    {
        //检查横向
        for (int i = 0; i < 3; ++i)
            if (grids[i, 0] != 0 && grids[i, 0] == grids[i, 1] && grids[i, 0] == grids[i, 2])
                return grids[i, 0];
        //检查纵向
        for (int j = 0; j < 3; ++j)
            if (grids[0, j] != 0 && grids[0, j] == grids[1, j] && grids[0, j] == grids[2, j])
                return grids[0, j];
        //对角线
        if (grids[1, 1] != 0)
        {
            if (grids[0, 0] == grids[1, 1] && grids[2, 2] == grids[1, 1])
                return grids[1, 1];
            if (grids[2, 0] == grids[1, 1] && grids[0, 2] == grids[1, 1])
                return grids[1, 1];
        }
        //继续游戏
        for (int i = 0; i < 3; ++i)
            for (int j = 0; j < 3; ++j)
                if (grids[i, j] == 0)
                    return 0;
        //平局
        return 3;
    }
}