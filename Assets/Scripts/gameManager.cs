using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public Texture2D mouseCrosshair;
    public Vector3 hotSpot = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(mouseCrosshair, hotSpot, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
