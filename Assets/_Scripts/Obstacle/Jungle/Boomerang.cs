using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    [SerializeField] private Transform startPos;  // �θ޶� ���� ��ġ
    [SerializeField] private Transform endPos;  // ���ư� ��ġ
    [SerializeField] private float direction = 18.0f;  // �������� �ӵ�
    [SerializeField] private string whos = "Big";  // ū �ε�Ȱ� ���� �ε���� �θ޶� ������ �ٸ��� ������

    float currentX;  // ���� ��ġ
    float coolTime;  // ��Ÿ��
    float rotate = 700f;  // ȸ�� �ӵ�

    void Start()
    {
        currentX = transform.localPosition.x;
        RandTime();

        switch(whos)
        {
            case "Big":
                StartCoroutine(BigMonsterBmr());
                break;
            case "Small":
                StartCoroutine(SmallMonsterBmr());
                break;
        }
    }

    IEnumerator BigMonsterBmr()
    {
        while (true)
        {
            currentX += Time.deltaTime * direction;

            if (currentX >= endPos.localPosition.x)
            {
                direction *= -1;
                currentX = endPos.localPosition.x;
            }

            if (currentX <= startPos.localPosition.x)
            {
                currentX = startPos.localPosition.x;
                yield return new WaitForSeconds(coolTime);  // �� �� ���� ������ coolTime��ŭ ��
                direction *= -1;
            }

            transform.Rotate(new Vector3(rotate * Time.deltaTime, 0, 0));
            transform.localPosition = new Vector3(currentX, transform.localPosition.y, transform.localPosition.z);

            yield return null;
        }
    }

    // ���� BigMonsterBmr()���� >=, <= �� �ٸ�
    IEnumerator SmallMonsterBmr()
    {
        while (true)
        {
            currentX += Time.deltaTime * direction;

            if (currentX <= endPos.localPosition.x)
            {
                direction *= -1;
                currentX = endPos.localPosition.x;
            }

            if (currentX >= startPos.localPosition.x)
            {
                currentX = startPos.localPosition.x;
                yield return new WaitForSeconds(coolTime);
                direction *= -1;
            }

            transform.Rotate(new Vector3(rotate * Time.deltaTime, 0, 0));
            transform.localPosition = new Vector3(currentX, transform.localPosition.y, transform.localPosition.z);

            yield return null;
        }
    }

    // �����ϸ� �������� ��Ÿ�� ����
    void RandTime()
    {
        int rand = Random.Range(0, 4);

        switch(rand)
        {
            case 0:
                coolTime = 0.3f;
                break;
            case 1:
                coolTime = 0.6f;
                break;
            case 2:
                coolTime = 0.9f;
                break;
            case 3:
                coolTime = 1.2f;
                break;
        }
    }
}
