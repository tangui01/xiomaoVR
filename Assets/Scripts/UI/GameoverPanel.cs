using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
public class GameoverPanel : MonoBehaviour
{
    [SerializeField] private Button EndBtn;
    [SerializeField] private TextMeshProUGUI text;

    public static GameoverPanel Instance;
    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }
    public void Show()
    {
        StartCoroutine("DoText");
        EndBtn.gameObject.SetActive(false);
    }
    IEnumerator DoText()
    {
        string str = "";
        string targetStr = "恭喜你,守护了这片竹林和交交,任务成功!";
        int i = 0;
        while (str.Length < targetStr.Length)
        {
            str += targetStr[i];
            text.text = str;
            yield return new WaitForSeconds(0.1f);
            i++;
        }
        EndBtn.gameObject.SetActive(true);
        EndBtn.transform.DOScale(Vector3.one, 0.5f);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
