using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //========================================
    //##		������ ���� SingleTon		##
    //========================================
    /*
        �̱��� ���� :
        ���� �� ���� Ŭ���� �ν��Ͻ����� ������ ����
        �̿� ���� �������� �������� ����

        ���� :
        1. �������� ���� ������ �ν��Ͻ��� �ּҸ� ���� ����
        ������ ���� �޸� ������ Ȱ�� (��������)
        2. ���������� Ȱ���Ͽ� ĸ��ȭ�� ����
        3. �������� ���ٱ����� �ܺο��� ������ �� ������ ����
        4. Instance �Ӽ��� ���� �ν��Ͻ��� ������ �� �ֵ��� ��
        5. instance ������ �� �ϳ��� �ֵ��� ����

        ���� :
        1. �ϳ����� ����� �ֿ� Ŭ����, �������� ������ ��
        2. ������ �������� ������ �ʿ��� �۾��� ���� �������ٰ���
        3. �ν��Ͻ����� �̱����� ���Ͽ� �����͸� �����ϱ� ������

        ���� :
        1. �̱����� �ʹ� ���� å���� �������� ��츦 �����ؾ���
        2. �̱����� ���߷� ���������� �������� �Ǵ� ���, ������ �ڵ� ���յ��� ������
        3. �̱����� �����͸� ������ ��� ������ ������ �����ؾ���
    */

public class SingleTon
{
    private static SingleTon instance;

    public static SingleTon Instance
    {
        get
        {
            if (instance == null)
                instance = new SingleTon();

            return instance;
        }
    }

    private SingleTon() { }
}

public class Player
{
    public void Test()
    {
        SingleTon singleTon1 = SingleTon.Instance;
    }
}