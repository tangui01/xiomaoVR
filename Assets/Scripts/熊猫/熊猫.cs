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
    private State curState;
    public State CurState
    {
        get
        {
            return curState;
        }
        set
        {
            if (value == curState) return;
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
}
