using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoroutineCache
{
    // ����Ÿ���̶� new�� ���� (C++)
    static Dictionary<float, WaitForSeconds> dictionary = new Dictionary<float, WaitForSeconds>();
    
    // ���� �Լ� �����Ͽ� �ٸ� Ŭ�������� ���

    // time = Ű ��
    // WaitForSeconds Ÿ���� ��ȯ
    public static WaitForSeconds WaitForSeconds(float time)
    {
        // ���ο��� ������ �͸� ���� (��������)

        // ��ųʸ� Ű���� �ش� �ð���ŭ�� WaitForSeconds ����

        // TryGetValue ����Ͽ� Ű ���� ���ٸ� �߰��ѵ� ��ȯ
        // Ű ���� �ִٸ� �׳� ��ȯ
        
        // ��������
        WaitForSeconds waitForSeconds;

        if(dictionary.TryGetValue(time, out waitForSeconds) == false)
        {
            dictionary.Add(time, new WaitForSeconds(time));

            // �߰� �� �ڿ� �����ؾ��Ѵ� -> �߰� �ϱ� �������� Ű������ null ����

            waitForSeconds = dictionary[time];
        }

        return waitForSeconds;
    }
}
