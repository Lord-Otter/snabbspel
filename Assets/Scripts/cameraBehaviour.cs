using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerBehaviour : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float mouseInfluence = 0f;
    public float yAxisBias = 1.5f;
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

        Vector3 cameraPosition = player.position + offset;

        if (mouseInfluence > 0f)
        {
            cameraPosition = Vector3.Lerp(player.position + offset, player.position + new Vector3(directionToMouse.x, directionToMouse.y * yAxisBias, directionToMouse.z), mouseInfluence);
        }

        cameraPosition.z = player.position.z + initialOffset.z;

        float distanceFromPlayer = Vector3.Distance(player.position, cameraPosition);

        if (distanceFromPlayer > maxDistance)
        {
            Vector3 direction = (cameraPosition - player.position).normalized;
            cameraPosition = player.position + direction * maxDistance;
        }

        transform.position = cameraPosition;

        transform.rotation = Quaternion.identity;
    }
}
