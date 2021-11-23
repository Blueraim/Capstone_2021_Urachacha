using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStoneHead : MonoBehaviour
{
    float heightMax = 1.5f;  // �ִ� ����
    float heightMin = -1f;  // �ּ� ����
    float currentY;  // ���� ����
    float direction = 5.0f;  // �������� �ӵ�

    float coolTime = 0;  // ��Ÿ��

    void Start()
    {
        currentY = transform.localPosition.y;
        RandTime();
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while(true)
        {
            currentY += Time.deltaTime * direction;

            if (currentY >= heightMax)
            {
                direction *= -1;
                currentY = heightMax;
            }

            if (currentY <= heightMin)
            {
                currentY = heightMin;
                yield return new WaitForSeconds(coolTime);  // �ö󰬴� ������ ������ coolTime��ŭ ��
                direction *= -1;
            }

            transform.localPosition = new Vector3(transform.localPosition.x, currentY, transform.localPosition.z);

            yield return null;
        }
    }

    // �����ϸ� �������� ��Ÿ�� ����
    void RandTime()
    {
        coolTime = Random.Range(0.5f, 1.5f);
    }
}
