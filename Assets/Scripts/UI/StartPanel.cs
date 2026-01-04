using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// ¶Ô»°Ãæ°å
/// </summary>
public class StartPanel : MonoBehaviour
{
    private TextMeshProUGUI content;
    private TextMeshProUGUI tips;
    private Transform ChatPart;
    [SerializeField] private string[] strings;
    private int index;

    [SerializeField] private Button StartBtn;

    private void Awake()
    {
        content=transform.Find("ChatPart/content").GetComponent<TextMeshProUGUI>();
        tips = transform.Find("ChatPart/tips").GetComponent<TextMeshProUGUI>();
        ChatPart = transform.Find("ChatPart");
    }
    private void Start()
    {
        StartChat();
        StartBtn.gameObject.SetActive(false);
    }
    private void StartChat()
    {
        StartCoroutine("DoAni");
    }
    IEnumerator DoAni()
    {
        while (index<strings.Length)
        {
            yield return DoText();
            while (!Input.GetMouseButtonDown(0)) yield return null;
            index++;
        }
        ChatPart.gameObject.SetActive(false);
        StartBtnAni();
    }
    IEnumerator DoText()
    {
        string str = "";
        string targetStr = strings[index];
        int i = 0;
        tips.gameObject.SetActive(false);
        while (str.Length<targetStr.Length)
        {
            str +=targetStr[i];
            content.text = str;
            yield return new WaitForSeconds(0.1f);
            i++;
        }
        tips.gameObject.SetActive(true);
    }
    private void StartBtnAni()
    {
        StartBtn.gameObject.SetActive(true);
        StartBtn.transform.localScale = Vector3.zero;
        StartBtn.transform.DOScale(Vector3.one,0.5f);
    }
    public void StartBtnOnClick()
    {
        SceneManager.LoadScene("GameScene");
    }
    
}
