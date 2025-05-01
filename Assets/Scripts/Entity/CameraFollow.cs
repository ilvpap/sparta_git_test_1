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
        
        // 카메라가 주인공 자연스럽게 따라가게 만들어주는 

        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        Vector3 currentPosition = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime); // 선형 보간
        //두 점 사이의 값을 추정하는 방법 , 두 점 사이의 값을 
        //멀어지면 멀어질 수록 빨라지고 가까우면 가까울 수록 느려진다.
        //Vector3 curPosition = transform.position - (transform.position - targetPosition).normalized * Time.deltaTime * followSpeed;
        //방향 벡터 구함 // 일정한 값을 가지고 간다.

        float clampedX = Mathf.Clamp(currentPosition.x, minPosition.x, maxPosition.x);  // 넣고 싶은 값, 최소값 제한, 최댓값 제한 (ex. HP)
        float clampedY = Mathf.Clamp(currentPosition.y, minPosition.y, maxPosition.y);  // Mathf 수학함수...
        // Clamp == 해당 범위를 벗어나면 최소치로 바꾼다. 최대치를 넘어가면 넘어갈 수 없도록 만들어준다?
        // Abs (절댓값) -10 > 10 으로 변함
        // float a = Mathf.Clamp(Mathf.Abs(-10), 0, Mathf.Abs(20));

        transform.position = new Vector3(clampedX, clampedY, currentPosition.z);
        //currenPosition == clapedX, clampedY / currentPosition z = 고정시키는 값
    }
}
