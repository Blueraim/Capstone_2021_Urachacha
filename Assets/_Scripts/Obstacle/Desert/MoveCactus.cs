using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCactus : MonoBehaviour
{
    float heightMax = 0.6f;  // ���� �ִ�
    float heightMin = -2.7f;  // ���� �ּ�
    float currentY;  // ���� ����
    float direction = 3.5f;  // �������� �ӵ�

    float coolTime = 0;  // ��Ÿ��

    void Start()
    {
        currentY = transform.localPosition.y;
        RandTime();
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
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
                yield return new WaitForSeconds(coolTime); // �ö󰬴� ������ ������ coolTime��ŭ ��
                direction *= -1;
            }

            transform.localPosition = new Vector3(transform.localPosition.x, currentY, transform.localPosition.z);

            yield return null;
        }
    }

    // �����ϸ� �������� ��Ÿ�� ����
    void RandTime()
    {
        coolTime = Random.Range(0.7f, 1.7f);
    }
}
