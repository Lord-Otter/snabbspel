using System.Collections;
using UnityEngine;

public class swordScript : MonoBehaviour
{
    public GameObject slash;
    public Transform slashSpawnPoint;  // Reference to the spawn point
    private float nextShot = 0;
    public float fireDelay = 1f;
    public bool holdToShoot = true;

    public float swordHoldTime = 0.2f;
    public float swordResetTime = 0.5f;
    public Vector3 targetPosition = new Vector3(-1.2f, 0.3f, 0f);
    public Vector3 targetRotation = new Vector3(0f, 0f, 40f);

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        Transform childTransform = transform.GetChild(0);
        originalPosition = childTransform.localPosition;
        originalRotation = childTransform.localRotation;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextShot)
        {
            Shoot();
        }

        if (Input.GetButton("Fire1") && Time.time > nextShot && holdToShoot == true)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Use the position and rotation of the Slash_Spawn_Point to spawn the slash
        Instantiate(slash, slashSpawnPoint.position, slashSpawnPoint.rotation);

        Transform swordSprite = transform.GetChild(0);
        StartCoroutine(SlashAnimation(swordSprite));

        nextShot = Time.time + fireDelay;
    }

    IEnumerator SlashAnimation(Transform childTransform)
    {
        childTransform.localPosition = targetPosition;
        childTransform.localRotation = Quaternion.Euler(targetRotation);

        yield return new WaitForSeconds(swordHoldTime);

        float elapsedTime = 0f;
        while (elapsedTime < swordResetTime)
        {
            childTransform.localPosition = Vector3.Lerp(childTransform.localPosition, originalPosition, elapsedTime / swordResetTime);
            childTransform.localRotation = Quaternion.Lerp(childTransform.localRotation, originalRotation, elapsedTime / swordResetTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        childTransform.localPosition = originalPosition;
        childTransform.localRotation = originalRotation;
    }
}


