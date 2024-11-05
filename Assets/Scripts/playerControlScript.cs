using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControlScript : MonoBehaviour
{
    
    // Player Movement
    public float movementSpeed;
    public bool CanMove = true;
    public bool canDodge = true;
    public bool canShoot = true;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Teleports player to start position
        transform.position = new Vector3(0, -3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        {
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");

            Vector3 movement = new Vector3(inputX, inputY, 0).normalized;

            if (movement.magnitude > 1)
            {
                movement.Normalize();
            }

            transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.rotation = Quaternion.LookRotation(new Vector3 (0, 0, 1), mousePosition - transform.position);
        }
    }
}
