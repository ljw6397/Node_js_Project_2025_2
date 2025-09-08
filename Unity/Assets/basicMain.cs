using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class basicMain : MonoBehaviour
{
    public Button Hello;
    public string host;     //IP�ּ� (��Ŀ�����Ĥ��� 127.0.0.1)
    public int port;      //��Ʈ �ּ�(3000������ express)
    public string route;

    private void Start()
    {
        this.Hello.onClick.AddListener(() =>
        {
            var url = string.Format("{0}:{1}/{2}", host, port, route);                //url �ּ� ex(127,0.0.1:3000/about)

            StartCoroutine(this.GetBasic(url, (raw) =>
            {
                Debug.LogFormat("{0}", raw);
            }));
        });
    }

    private IEnumerator GetBasic(string url, System.Action<string> callback)
    {
        var webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError     //���Ҥ� ����
            || webRequest.result == UnityWebRequest.Result.ProtocolError)    //�������ڤ� ����
        {
            Debug.Log("��Ʈ��ũ �뤵�Ӥ� �Ұ�");               //������ ó��

        }
        else
        {
            callback(webRequest.downloadHandler.text);             //�뤵�Ӥ� �Ϥ��� �ǰ� �ش٤� �ؤ���Ʈ�� ���� �¤�
        }
    }
}
