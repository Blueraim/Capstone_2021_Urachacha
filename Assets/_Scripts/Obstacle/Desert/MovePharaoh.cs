using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePharaoh : MonoBehaviour
{
    float widthMax = -41.0f;  // ������ ��ġ �ִ�
    float widthMin = -65.5f;  // �ּڰ�

    float currentX;  // ���� ��ġ
    float direction = 20.0f;  // �������� �ӵ�

    void Start()
    {
        currentX = transform.localPosition.x;  // ������ �� �⺻������ �����ִ� ��ġ�� ���� ��ġ��

        RandDirection();
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            currentX += Time.deltaTime * direction;

            if (currentX >= widthMax)
            {
                direction *= -1;
                currentX = widthMax;
            }

            if (currentX <= widthMin)
            {
                direction *= -1;
                currentX = widthMin;
            }

            transform.localPosition = new Vector3(currentX, transform.localPosition.y, transform.localPosition.z);

            yield return null;
        }
    }

    // �����ϸ� �������� �ӵ� ����
    public void RandDirection()
    {
        int rand = Random.Range(0, 3);

        switch(rand)
        {
            case 1:
                direction = 10.0f;
                break;
            case 2:
                direction = 15.0f;
                break;
            case 3:
                direction = 20.0f;
                break;
        }
    }
}
