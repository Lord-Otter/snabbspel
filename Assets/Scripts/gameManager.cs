using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public Texture2D mouseCrosshair;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(mouseCrosshair, Vector3.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
