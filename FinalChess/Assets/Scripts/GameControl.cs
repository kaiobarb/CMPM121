using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public Light selectionLight;
    private GameObject selectedPiece;
    private GameObject selectedTile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Camera cam = Camera.main;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "Piece")
                {
                    if (selectedPiece != hitInfo.collider.gameObject)
                    {
                        deselectPiece();
                        selectedPiece = hitInfo.collider.gameObject;
                    }
                    highlightPiece(selectedPiece);
                }
                else if (hitInfo.collider.gameObject.tag == "Tile")
                {
                    if (selectedTile != hitInfo.collider.gameObject)
                    {
                        deselectTile();
                        selectedTile = hitInfo.collider.gameObject;
                    }
                    if (selectedTile && selectedPiece)
                        selectedPiece.GetComponent<Piece>().moving = true;
                }
            }
        }
        if (selectedTile && selectedPiece && selectedPiece.GetComponent<Piece>().moving)
        {
            Piece selectedPieceComponent = selectedPiece.GetComponent<Piece>();
            if (selectedPiece.transform.position == selectedTile.transform.position)
                selectedPieceComponent.moving = false;
            selectedPiece.GetComponent<Piece>().move(selectedTile.transform);
        }
    }

    void deselectPiece()
    {
        if (selectedPiece)
        {
            selectedPiece.GetComponent<Piece>().highlighted = false;
        }
    }

    // Currently does nothing...
    void deselectTile()
    {
        if (selectedTile)
        {

        }
    }

    void highlightPiece(GameObject obj)
    {
        var t_pos = selectionLight.transform.position;
        t_pos.x = obj.transform.position.x;
        t_pos.z = obj.transform.position.z;
        selectionLight.transform.position = t_pos;
        if (obj.GetComponent<Piece>().highlighted == true)
        {
            obj.GetComponent<Piece>().highlighted = false;
            selectionLight.enabled = false;
        }
        else
        {
            obj.GetComponent<Piece>().highlighted = true;
            selectionLight.enabled = true;
        }
        
        //selectionLight.transform.position.z = hitInfo.collider.gameObject.transform.position.z;        
    }
}
