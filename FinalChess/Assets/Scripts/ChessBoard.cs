using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ChessBoard : MonoBehaviour {
    static public int BOARD_SIZE = 8;
    static public int TILE_SIZE = 1;
    public Material darkTile;
    public Material lightTile;

    public Tile[,] tiles;

    void setTiles()
    {
        tiles = new Tile[8,8];
        for (int i = 0; i < BOARD_SIZE; i++)
        {
            for (int j = 0; j < BOARD_SIZE; j++)
            {
                GameObject t_gameobject = GameObject.Find("ChessBoard/Board/Tile_" + i.ToString() + j.ToString());
                t_gameobject.tag = "Tile";
                Tile t = t_gameobject.AddComponent<Tile>();
                t.row = i;
                t.col = j;

                if (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1)
                    t_gameobject.GetComponent<Renderer>().material = darkTile;
                else
                    t_gameobject.GetComponent<Renderer>().material = lightTile;
                tiles[i, j] = t;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        setTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //[MenuItem("GameObject/Create Other/Primitive")]
    //static public void DoPrimitive()
    //{
    //    var darkTile = Resources.Load<Material>("Assets/Materials/tileDark");
    //    var lightTile = Resources.Load<Material>("Assets/Materials/tileLight");
    //    Debug.Log(darkTile);
    //    //ChessBoard cb = new ChessBoard();
    //    //cb.applyMaterial();
    //    Tile[,] tiles = new Tile[8, 8];
    //    for (int i = 0; i < BOARD_SIZE; i++)
    //    {
    //        for (int j = 0; j < BOARD_SIZE; j++)
    //        {
    //            Tile tile = new Tile(i, j, TILE_SIZE);
    //            tiles[i + j * BOARD_SIZE] = tile;
    //            if (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1)
    //            {
    //                tile.create3DTile();
    //                tile.cube.GetComponent<Renderer>().sharedMaterials[0] = darkTile;
    //            }
    //            else
    //            {
    //                tile.create3DTile();
    //                tile.cube.GetComponent<Renderer>().sharedMaterials[0] = lightTile;
    //            }
    //        }
    //    }
    //}
}
