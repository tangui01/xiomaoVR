using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum State
{ 
    None,
    坐下,
    开心,
    害怕,
    环顾,
    挖,
    摸摸
}
public class 熊猫 : MonoBehaviour
{
    public GameObject[] StateGameObj;
    [SerializeField]private State curState;
    public State CurState
    {
        get
        {
            return curState;
        }
        set
        {
            if (value == curState) return;
            curState = value;
            switch (curState)
            {
                case State.坐下:
                    break;
                case State.开心:
                    GamePanel.Instance.AddCount(1);
                    Invoke("NorAml",2);
                    break;
                case State.害怕:
                    break;
                case State.环顾:
                    break;
                case State.挖:
                    break;
                case State.摸摸:
                    GamePanel.Instance.AddCount(2);
                    Invoke("NorAml", 1);
                    break;
            }
            SetStateGameObjActive((int)curState-1);
        }
    }
    private void Start()
    {
        CurState = State.坐下;
    }
    private void SetStateGameObjActive(int index)
    {
        foreach (var item in StateGameObj)
        {
            item.gameObject.SetActive(false);
        }
        StateGameObj[index].SetActive(true);
    }
    [SerializeField] private bool NearPlayer;
    [SerializeField] private bool IsFirstPalyer = true;

    void OnTriggerEnter(Collider other)
    {
        // 检查是否是VR相机（玩家）
        if (other.CompareTag("Player"))
        {
            // 触发相应事件
            if (IsFirstPalyer)
            {
                IsFirstPalyer = false;
                CurState = State.害怕;
            }
        }
    }
    private void NorAml()
    {
        CurState = State.环顾;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
        }
    }
}
