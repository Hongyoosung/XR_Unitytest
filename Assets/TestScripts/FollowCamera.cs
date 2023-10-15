using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform vrCamera;
    public float distanceForward = 1f; // UI와 카메라 사이의 전방 거리
    public float distanceLeft = 5f; // UI와 카메라 사이의 좌측 거리

    void Update()
    {
        // VR 카메라 전방과 왼쪽에 각각 지정된 거리만큼 떨어진 위치 계산
        Vector3 targetPosition = vrCamera.position + vrCamera.forward * distanceForward - vrCamera.right * distanceLeft;

        // UI 오브젝트 위치 설정
        transform.position = targetPosition;

        // UI 오브젝트 회전 설정 - 사용자가 어디를 보든지 상관없이 항상 앞에 보이도록 함.
        transform.rotation = Quaternion.Euler(vrCamera.eulerAngles.x, vrCamera.eulerAngles.y, 0);
    }
}
