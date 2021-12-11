
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class AdminSystem : UdonSharpBehaviour
{
    [SerializeField]
    private GameObject adminCheckCV;

    [SerializeField]
    private GameObject systemControlCV;

    private InputField pwdInput;
    private Text adminCheckText;
    private string adminPwd = "1234";

    void Start()
    {
        pwdInput = adminCheckCV.GetComponentInChildren<InputField>();
        adminCheckText = adminCheckCV.GetComponentInChildren<Text>();
    }

    public void TurnOnAdminCheckCV()
    {
        adminCheckCV.SetActive(true);
        adminCheckText.text = "Admin Password";
        pwdInput.text = "";
        Debug.Log(adminCheckText.text);
    }

    public void TurnOffAdminCheckCV()
    {
        adminCheckCV.SetActive(false);
    }

    public void TurnOfsystemControlCV()
    {
        systemControlCV.SetActive(false);
    }

    public void ValidateAdminPwd()
    {
        if (adminPwd.Equals(pwdInput.text))
        {
            adminCheckCV.SetActive(false);
            systemControlCV.SetActive(true);
        }
        else
        {
            adminCheckText.text = "Wrong password! Retry!";
        }
    }
}
