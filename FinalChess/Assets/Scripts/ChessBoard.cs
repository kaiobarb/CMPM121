using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[System.Serializable]
public class ChessBoard : MonoBehaviour {
    static public int BOARD_SIZE = 8;
    static public int TILE_SIZE = 1;

    //[SerializeField]
    //public Material darTile;
    //public Material lighTile;
    static public Material darkTile; 
    static public Material lightTile; 


    private Tile[] tiles;

    public class Tile
    {
        private int row, col;
        private float size;
        public GameObject cube;

        public Tile(int row, int col, int size)
        {
            this.row = row;
            this.col = col;
            this.size = size;
            this.cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            this.cube.transform.parent = GameObject.Find("ChessBoard").transform;
            this.cube.transform.position = new Vector3(row, 0, col);
            this.cube.transform.localScale = new Vector3(size, size, size);
        }

        public void setRowCol(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }




    

    [MenuItem("GameObject/Create Other/Primitive")]
    static public void DoPrimitive()
    {
        ChessBoard.darkTile = Resources.Load("Material/tileDark.mat", typeof(Material)) as Material;
        ChessBoard.lightTile = Resources.Load("Material/tileLight.mat", typeof(Material)) as Material;
        ChessBoard cb = new ChessBoard();
        
        cb.applyMaterial();   
    }

    void applyMaterial()
    {
        for (int i = 0; i < BOARD_SIZE; i++)
        {
            for (int j = 0; j < BOARD_SIZE; j++)
            {
                //ChessBoard chessboard = new ChessBoard();
                Tile tile = new Tile(i * TILE_SIZE, j * TILE_SIZE, 1);
                if (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1)
                {
                    tile.cube.GetComponent<Renderer>().sharedMaterials[0] = darkTile;
                }
                else
                {
                    tile.cube.GetComponent<Renderer>().sharedMaterials[0] = lightTile;
                }
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
