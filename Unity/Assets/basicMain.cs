using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class basicMain : MonoBehaviour
{
    public Button Hello;
    public string host;     //IP주소 (로커ㄹㅇㅔㅅㅓ 127.0.0.1)
    public int port;      //포트 주소(3000번으로 express)
    public string route;

    private void Start()
    {
        this.Hello.onClick.AddListener(() =>
        {
            var url = string.Format("{0}:{1}/{2}", host, port, route);                //url 주소 ex(127,0.0.1:3000/about)

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

        if (webRequest.result == UnityWebRequest.Result.ConnectionError     //접소ㄱ 오류
            || webRequest.result == UnityWebRequest.Result.ProtocolError)    //프로토코ㄹ 오류
        {
            Debug.Log("네트워크 통ㅅㅣㄴ 불가");               //예오ㅣ 처리

        }
        else
        {
            callback(webRequest.downloadHandler.text);             //통ㅅㅣㄴ 완ㄹㅛ 되고 해다ㅇ 텍ㄷ스트를 가져 온ㄷ
        }
    }
}
