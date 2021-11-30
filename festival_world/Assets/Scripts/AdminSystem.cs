
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

    [SerializeField]
    private GameObject postCV;

    private InputField pwdInput;
    private Text adminCheckText;
    private string adminPwd = "1234";

    private bool _isActive;
    private float _timerCount;
    public float timer = 3;

    void Start()
    {
        systemControlCV.SetActive(false);
        pwdInput = adminCheckCV.GetComponentInChildren<InputField>();
        adminCheckText = adminCheckCV.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        if(_isActive)
        {
            if(_timerCount >= timer)
            {
                systemControlCV.SetActive(false);
                _timerCount = 0;
                _isActive = false;
            }
            else
            {
                _timerCount += Time.deltaTime;
            }
        }
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
            _isActive = true;
        }
        else
        {
            adminCheckText.text = "Wrong password! Retry!";
        }
    }

    // for notice board -> udon graph ?
    public void DestroyPost()
    {
        Destroy(postCV);
        Destroy(this);
    }

}
