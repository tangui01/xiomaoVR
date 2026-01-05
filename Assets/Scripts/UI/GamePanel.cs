using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GamePanel : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI text;
    public int Count;

    public static GamePanel Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        SetCount();
    }
    public void AddCount(int add)
    {
        Count += add;
        if (Count>=10)
        {
            GameoverPanel.Instance.Show();        
        }
        SetCount();
    }
    private void SetCount()
    {
        text.text = string.Format($"Ç×ÃÜ¶È<color=#FF0000>{Count}/10</color>");
    }
}
