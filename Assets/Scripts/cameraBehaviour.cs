using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerBehaviour : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float mouseInfluence = 0f;
    public float yMouseBias = 1.5f;
    public float maxDistance = 10f;

    private Vector3 initialOffset;

    void Start()
    {
        initialOffset = offset;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;

        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 directionToMouse = worldMousePos - player.position;

        // Apply mouse influence to the x and y directions separately
        Vector3 desiredPosition = player.position + offset;

        if (mouseInfluence > 0f)
        {
            // Scale the mouse influence differently for the y-axis
            desiredPosition = Vector3.Lerp(player.position + offset, player.position + new Vector3(directionToMouse.x, directionToMouse.y * yMouseBias, directionToMouse.z), mouseInfluence);
        }

        // Preserve the initial z offset
        desiredPosition.z = player.position.z + initialOffset.z;

        // Ensure the camera doesn't go too far from the player
        float distanceFromPlayer = Vector3.Distance(player.position, desiredPosition);

        if (distanceFromPlayer > maxDistance)
        {
            Vector3 direction = (desiredPosition - player.position).normalized;
            desiredPosition = player.position + direction * maxDistance;
        }

        transform.position = desiredPosition;

        // Lock rotation to identity (no rotation)
        transform.rotation = Quaternion.identity;
    }
}