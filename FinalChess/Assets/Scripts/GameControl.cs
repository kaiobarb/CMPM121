using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public Light selectionLight;
    private 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            highlightPiece();
        }
    }

    void highlightPiece()
    {
        Camera cam = Camera.main;
         Ray ray = cam.ScreenPointToRay(Input.mousePosition);
    RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.gameObject.tag == "Piece")
            {
                var t_pos = selectionLight.transform.position;
                t_pos.x = hitInfo.collider.gameObject.transform.position.x;
                t_pos.z = hitInfo.collider.gameObject.transform.position.z;
                selectionLight.transform.position = t_pos;
                //selectionLight.transform.position.z = hitInfo.collider.gameObject.transform.position.z;
            }
        }
    }
}
