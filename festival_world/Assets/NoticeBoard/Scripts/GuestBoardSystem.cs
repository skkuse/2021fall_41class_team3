
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class GuestBoardSystem : UdonSharpBehaviour
{
    [SerializeField]
    private GameObject textInputCV, textPost;

    private InputField contentField;
    private Text textPostContent;

    void Start()
    {
        contentField = textInputCV.GetComponentInChildren<InputField>();
        textPostContent = textPost.GetComponentInChildren<Text>();
    }

    public void TurnOnTextInputCV()
    {
        textInputCV.SetActive(true);
        contentField.text = "";
    }

    public void TurnOffTextInputCV()
    {
        textInputCV.SetActive(false);
        contentField.text = "";
    }

    public void GetTextInput()
    {
        textPostContent.text = contentField.text;
    }

    public void TurnOnTextPost()
    {
        textPost.SetActive(true);
        textInputCV.SetActive(false);
    }

}
