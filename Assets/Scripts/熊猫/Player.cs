using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
/// <summary>
/// 玩家控制器
/// </summary>
public class Player : MonoBehaviour
{
    [SerializeField]private Transform BallInitPos;
    [SerializeField]private GameObject BallPre;

    [SerializeField] private KeyCode PlaykeyCode;
    [SerializeField] private bool NearPanda;
    [SerializeField] private 熊猫 target;
    private void Update()
    {
        if (Input.GetKeyDown(PlaykeyCode)&& NearPanda)
        {
            Iv();
        }
        if (targetDevice.isValid && targetDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerPressed) && triggerPressed&& NearPanda)
        {
            Iv();
        }
    }
    private void Iv()
    {
        int model = Random.Range(0, 2);
        switch (model)
        {
            case 0:
                ball ball = Instantiate(BallPre, BallInitPos.position, Quaternion.identity, BallInitPos).GetComponent<ball>();
                ball.Shoot(transform.forward);
                target.CurState = State.开心;
                break;
            case 1:
                TriggerVibration(0.5f, 0.1f);
                target.CurState = State.摸摸;
                break;
            case 2:

                break;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Panda"))
        {
            NearPanda = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Panda"))
        {
            NearPanda = false;
        }
    }
    // 指定左右手控制器
    public XRNode controllerNode = XRNode.LeftHand;
    private InputDevice targetDevice;

    void Start()
    {
        // 初始化获取设备
        GetDevice();
    }

    void GetDevice()
    {
        // 获取指定节点的设备
        var devices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(controllerNode, devices);
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    // 触发震动
    public void TriggerVibration(float amplitude, float duration)
    {
        if (!targetDevice.isValid)
        {
            GetDevice();
        }

        // 检查设备是否支持震动
        if (targetDevice.isValid && targetDevice.TryGetHapticCapabilities(out var capabilities) && capabilities.supportsImpulse)
        {
            targetDevice.SendHapticImpulse(0, amplitude, duration);
        }
    }

    // 示例：按下按键触发震动


}
