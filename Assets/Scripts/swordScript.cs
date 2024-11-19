using System.Collections;
using UnityEngine;

public class swordScript : MonoBehaviour
{
    public GameObject slash;
    private float nextShot = 0;
    public float fireDelay = 0.5f;
    public bool holdToShoot = false;

    public float holdTime = 2f;
    public float slideTime = 3f;
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
        Instantiate(slash, transform.position, transform.rotation);

        Transform childTransform = transform.GetChild(0);

        StartCoroutine(TeleportAndReturn(childTransform));

        nextShot = Time.time + fireDelay;
    }

    IEnumerator TeleportAndReturn(Transform childTransform)
    {
        childTransform.localPosition = targetPosition;
        childTransform.localRotation = Quaternion.Euler(targetRotation);

        yield return new WaitForSeconds(holdTime);

        float elapsedTime = 0f;
        while (elapsedTime < slideTime)
        {
            childTransform.localPosition = Vector3.Lerp(childTransform.localPosition, originalPosition, elapsedTime / slideTime);
            childTransform.localRotation = Quaternion.Lerp(childTransform.localRotation, originalRotation, elapsedTime / slideTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        childTransform.localPosition = originalPosition;
        childTransform.localRotation = originalRotation;
    }
}

