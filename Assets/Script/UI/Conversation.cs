using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
{

    [SerializeField]
    GameObject PlayerDark;
    [SerializeField]
    GameObject PlayerText;
    [SerializeField]
    Text PText;

    [SerializeField]
    GameObject BossDark;
    [SerializeField]
    GameObject BossText;
    [SerializeField]
    Text BText;

    [SerializeField]
    GameObject convers;

    int conv = 1;

    

    public void Conversation2()
    {

        switch (conv)
        {
            case 1:
                convers.SetActive(true);
                conv++;
                break;
            case 2:
                PlayerSay("��ȭ�����ϱ�?");
                conv++;
                break;
            case 3:
                BossSay("��ȭ�����̾�");
                conv++;
                break;
            case 4:
                PlayerSay("������ȭ���ұ�?");
                conv++;
                break;
            case 5:
                PlayerSay("�߸𸣰ڳ�?");
                conv++;
                break;
            case 6:
                BossSay("��ȭ�׸�����");
                conv++;
                break;
            case 7:
                convers.SetActive(false);
                Boss1.bossStart = true;
                conv++;
                break;
            default:
                break;
        }

    }

    void PlayerSay(string str)
    {
        BossDark.SetActive(true);
        BossText.SetActive(false);

        PlayerText.SetActive(true);
        PText.text = str;
        PlayerDark.SetActive(false);

    }

    void BossSay(string str)
    {
        PlayerDark.SetActive(true);
        PlayerText.SetActive(false);

        BossText.SetActive(true);
        BText.text = str;
        BossDark.SetActive(false);

    }
}
