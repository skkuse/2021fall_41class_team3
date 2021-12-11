
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class DeletePost : UdonSharpBehaviour
{
    [SerializeField]
    private GameObject targetPostCV, deleteCV;

    [SerializeField]
    private GameObject option1, option2;

    private Image PostPanel;
    private Text PostContent;
    private Text Option1Count, Option2Count;

    void Start()
    {
        PostPanel = targetPostCV.GetComponentInChildren<Image>();
        PostContent = targetPostCV.GetComponentInChildren<Text>();
        if(option1)
            Option1Count = option1.GetComponentInChildren<Text>();
        if(option2)
            Option2Count = option2.GetComponentInChildren<Text>();
    }

    public void InitVotingCount()
    {
        Option1Count.text = "0";
        Option2Count.text = "0";
    }

    public void DeletePostCV()
    {
        targetPostCV.SetActive(false);
        deleteCV.SetActive(false);
        if(option1) InitVotingCount();
    }

/*    public void DestroyPostCV()
    {
        Destroy(targetPostCV);
        Destroy(this);
    }*/
}
