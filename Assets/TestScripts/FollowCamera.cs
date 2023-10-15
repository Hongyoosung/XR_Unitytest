using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform vrCamera;
    public float distanceForward = 1f; // UI�� ī�޶� ������ ���� �Ÿ�
    public float distanceLeft = 5f; // UI�� ī�޶� ������ ���� �Ÿ�

    void Update()
    {
        // VR ī�޶� ����� ���ʿ� ���� ������ �Ÿ���ŭ ������ ��ġ ���
        Vector3 targetPosition = vrCamera.position + vrCamera.forward * distanceForward - vrCamera.right * distanceLeft;

        // UI ������Ʈ ��ġ ����
        transform.position = targetPosition;

        // UI ������Ʈ ȸ�� ���� - ����ڰ� ��� ������ ������� �׻� �տ� ���̵��� ��.
        transform.rotation = Quaternion.Euler(vrCamera.eulerAngles.x, vrCamera.eulerAngles.y, 0);
    }
}
