using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{

    public GameObject obj;
    public Player(GameObject obj)
    {
        this.obj = obj;

    }
    // Start is called before the first frame update
    void Start()
    {

    }
    bool CanMoveTo(Vector3 newPos, Tile[][] path)
    {
        for (int i = 0; i < path.Length; i++)
        {
            for (int i2 = 0; i2 < path[i].Length; i2++)
            {
                ???
                // kijk hier of de newPos op een toren uitkomt
                //als dat zo is return false!
            }
        }
        return true;
    }
    public void Move(Vector3 newPos, Tile[][] path)
    {

        Debug.Log("======move");
        if (CanMoveTo(newPos, path))
        {
            Debug.Log("======CanMoveTo");
            obj.transform.position = newPos;
        }
    }
    public void DoMove(Tile[][] path)
    {
        Vector3 newPos = obj.transform.position;
        ???
        //maak hier je input check, bv:
        // als right down dan move naar rechts (tel iets bij de x van newpos op)
        // gebruik de move function daarvoor
    }
}
