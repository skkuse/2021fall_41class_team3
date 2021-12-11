
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;
using System.Collections;

public class NewPost : UdonSharpBehaviour
{
    [SerializeField]
    private GameObject textInputCV;

    [SerializeField]
    private GameObject typeSelectCV;

    [SerializeField]
    private GameObject textPost, imagePost, votingPost;

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
        typeSelectCV.SetActive(false);
        contentField.text = "";
    }

    public void TurnOffAllCV()
    {
        textInputCV.SetActive(false);
        typeSelectCV.SetActive(false);
    }

    public void GetTextInput()
    {
        textPostContent.text = contentField.text;
    }

    public void TurnOnTextPost()
    {
        textPost.SetActive(true);
        textInputCV.SetActive(false);
        typeSelectCV.SetActive(false);
    }
    public void TurnOnImagePost()
    {
        imagePost.SetActive(true);
        typeSelectCV.SetActive(false);
    }

    public void TurnOnVotingPost()
    {
        votingPost.SetActive(true);
        typeSelectCV.SetActive(false);
    }
}
