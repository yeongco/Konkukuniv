using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FPSManager : MonoBehaviour
{
    public Text fpsText; // TextMeshPro UI �ؽ�Ʈ�� ����
    private float deltaTime;

    void Update()
    {
        // ��Ÿ Ÿ�� ����
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        // FPS ���
        float fps = 1.0f / deltaTime;

        // �ؽ�Ʈ ������Ʈ
        fpsText.text = string.Format("FPS : {0:0.0}", fps);
    }
}
