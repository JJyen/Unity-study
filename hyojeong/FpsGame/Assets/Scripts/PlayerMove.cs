using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �̵� �ӵ� ����
    public float moveSpeed = 7f;

    void Update()
    {
        // wase Ű�� ������ �Է��ϸ� ĳ���͸� �� �������� �̵���Ű�� �ʹ�.

        // 1. ������� �Է��� �޴´�.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 2. �̵� ������ �����Ѵ�.
        Vector3 dir = new Vector3(h, v);
        dir = dir.normalized;

        // 2-1. ���� ī�޶� �������� ������ ��ȯ�Ѵ�.
        dir = Camera.main.transform.TransformDirection(dir);

        // 3. �̵� �ӵ��� ���� �̵��Ѵ�.
        // p = p0 + vt
        transform.position += dir * moveSpeed * Time.deltaTime;
    }
}
