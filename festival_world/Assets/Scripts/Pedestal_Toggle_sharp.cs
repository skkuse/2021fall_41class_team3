
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Pedestal_Toggle_sharp : UdonSharpBehaviour
{
    public GameObject Target;
    public GameObject Message;

    private bool _isActive;
    private float _timerCount;

    public float timer = 5;

    void Start()
    {
        Target.SetActive(false);
        Message.SetActive(false);
    }

    private void Interact()
    {
        Target.SetActive(true);
        Message.SetActive(true);
        _isActive = true;
    }

    public void Update()
    {
        if (_isActive)
        {
            if(_timerCount >= timer)
            {
                Message.SetActive(false);
                Target.SetActive(false);
                _isActive = false;
                _timerCount = 0;
            }
            else
            {
                _timerCount += Time.deltaTime;
            }
        }

    }

}
