﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskFactory : MonoBehaviour
{
    public GameObject diskPrefab;
    private List<DiskData> used = new List<DiskData>();
    private List<DiskData> free = new List<DiskData>();

    private void Awake()
    {
        diskPrefab = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/disk"), Vector3.zero, Quaternion.identity);
        diskPrefab.SetActive(false);
    }

    public GameObject GetDisk(int round)
    {
        GameObject newDisk = null;
        if (free.Count > 0)
        {
            newDisk = free[0].gameObject;
            free.Remove(free[0]);
        }
        else
        {
            newDisk = GameObject.Instantiate<GameObject>(diskPrefab, Vector3.zero, Quaternion.identity);
            newDisk.AddComponent<DiskData>();
        }

        int start = 0;
        if (round == 1) start = 100;
        if (round == 2) start = 250;
        int selectedColor = Random.Range(start, round * 499);

        if (selectedColor > 500)
        {
            round = 2;
        }
        else if (selectedColor > 300)
        {
            round = 1;
        }
        else
        {
            round = 0;
        }

        switch (round)
        {
            case 0:
                {
                    newDisk.GetComponent<DiskData>().color = Color.blue;
                    newDisk.GetComponent<DiskData>().speed = 10;
                    float RanX = UnityEngine.Random.Range(-1f, 1f) < 0 ? -1 : 1;
                    newDisk.GetComponent<DiskData>().direction = new Vector3(RanX, 0, -1);
                    newDisk.GetComponent<Renderer>().material.color = Color.blue;
                    break;
                }
            case 1:
                {
                    newDisk.GetComponent<DiskData>().color = Color.yellow;
                    newDisk.GetComponent<DiskData>().speed = 15;
                    float RanX = UnityEngine.Random.Range(-1f, 1f) < 0 ? -1 : 1;
                    newDisk.GetComponent<DiskData>().direction = new Vector3(RanX, 0, -1);
                    newDisk.GetComponent<Renderer>().material.color = Color.yellow;
                    break;
                }
            case 2:
                {
                    newDisk.GetComponent<DiskData>().color = Color.red;
                    newDisk.GetComponent<DiskData>().speed = 20;
                    float RanX = UnityEngine.Random.Range(-1f, 1f) < 0 ? -1 : 1;
                    newDisk.GetComponent<DiskData>().direction = new Vector3(RanX, 0, -1);
                    newDisk.GetComponent<Renderer>().material.color = Color.red;
                    break;
                }
        }
        used.Add(newDisk.GetComponent<DiskData>());
        newDisk.name = newDisk.GetInstanceID().ToString();
        return newDisk;
    }

    public void FreeDisk(GameObject disk)
    {
        DiskData tmp = null;
        foreach (DiskData i in used)
        {
            if (disk.GetInstanceID() == i.gameObject.GetInstanceID())
            {
                tmp = i;
            }
        }
        if (tmp != null)
        {
            tmp.gameObject.SetActive(false);
            free.Add(tmp);
            used.Remove(tmp);
        }
    }
}