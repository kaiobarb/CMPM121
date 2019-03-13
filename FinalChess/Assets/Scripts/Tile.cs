using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int row, col;
    public float size;
    public GameObject cube;

    void Start()
    {
        
    }

    public Tile(int row, int col)
    {
        this.row = row;
        this.col = col;
    }

    public void create3DTile()
    {
        this.cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //this.cube.name = this.name;
        this.cube.transform.parent = GameObject.Find("Board").transform;
        this.cube.transform.localPosition = new Vector3(row * this.size, 0, col * this.size);
        this.cube.transform.localScale = new Vector3(this.size, this.size * 2, this.size);
    }
}