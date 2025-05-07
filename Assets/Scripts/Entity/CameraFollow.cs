using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float followSpeed = 2f;

    [Header("카메라 경계")]
    [SerializeField] private Vector2 minPosition;
    [SerializeField] private Vector2 maxPosition;

    private void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        Vector3 currentPosition = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        float clampedX = Mathf.Clamp(currentPosition.x, minPosition.x, maxPosition.x);
        float clampedY = Mathf.Clamp(currentPosition.y, minPosition.y, maxPosition.y);


        transform.position = new Vector3(clampedX, clampedY, currentPosition.z);
    }
}
