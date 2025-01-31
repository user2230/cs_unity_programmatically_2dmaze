using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile
{
    public GameObject tileObject;
    public bool istower;

    public Tile(GameObject tileObject, bool istower)
    {
        this.tileObject = tileObject;
        this.istower = istower;
    }
}

