using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;

    // ���� ���� �� ����Ǵ� �ʱ�ȭ �Լ�
    public void Start()
    {
        // restartText�� ������� �ʾ��� ��� ���� ���
        if (restartText == null)
        {
            Debug.LogError("restart text is null");
        }

        // scoreText�� ������� �ʾ��� ��� ���� ����ϰ� �ߴ�
        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        // ó������ "�ٽ� ����" �ؽ�Ʈ�� ���ܵ�
        restartText.gameObject.SetActive(false);
    }

    // ���� ���� ���¿��� �ٽ� ���� �޽����� ���̰� ��
    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }

    // ���� ������ UI�� ������Ʈ
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString(); // ������ ���ڿ��� ��ȯ�Ͽ� ���
    }
}