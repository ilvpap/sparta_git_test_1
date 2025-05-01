using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float followSpeed = 2f;

    [Header("ī�޶� ���")]
    [SerializeField] private Vector2 minPosition;
    [SerializeField] private Vector2 maxPosition;

    private void LateUpdate()
    {
        if (target == null)
        {
            return;
        }
        
        // ī�޶� ���ΰ� �ڿ������� ���󰡰� ������ִ� 

        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        Vector3 currentPosition = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime); // ���� ����
        //�� �� ������ ���� �����ϴ� ��� , �� �� ������ ���� 
        //�־����� �־��� ���� �������� ������ ����� ���� ��������.
        //Vector3 curPosition = transform.position - (transform.position - targetPosition).normalized * Time.deltaTime * followSpeed;
        //���� ���� ���� // ������ ���� ������ ����.

        float clampedX = Mathf.Clamp(currentPosition.x, minPosition.x, maxPosition.x);  // �ְ� ���� ��, �ּҰ� ����, �ִ� ���� (ex. HP)
        float clampedY = Mathf.Clamp(currentPosition.y, minPosition.y, maxPosition.y);  // Mathf �����Լ�...
        // Clamp == �ش� ������ ����� �ּ�ġ�� �ٲ۴�. �ִ�ġ�� �Ѿ�� �Ѿ �� ������ ������ش�?
        // Abs (����) -10 > 10 ���� ����
        // float a = Mathf.Clamp(Mathf.Abs(-10), 0, Mathf.Abs(20));

        transform.position = new Vector3(clampedX, clampedY, currentPosition.z);
        //currenPosition == clapedX, clampedY / currentPosition z = ������Ű�� ��
    }
}
