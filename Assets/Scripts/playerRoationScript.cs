using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRoationScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), mousePosition - transform.position);
    }
}
