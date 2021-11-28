
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class Plus : UdonSharpBehaviour
{
    [SerializeField]
    private GameObject selectTypeCV;

    [SerializeField]
    private GameObject plusBtn;

    void Start()
    {
        
    }

    public void TurnOnTypeCV()
    {
        selectTypeCV.SetActive(true);
        plusBtn.SetActive(false);
    }

    public void TurnOffTypeCV()
    {
        selectTypeCV.SetActive(false);
        //plusBtn.SetActive(true);
    }
}
