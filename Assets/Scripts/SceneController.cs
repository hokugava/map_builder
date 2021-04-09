using UnityEngine;

public class SceneController : MonoBehaviour
{
    public GameObject menuOverlay, settingsBtn, closeBtn;
    void Start()
    {
        Time.timeScale = 1.0f;
        menuOverlay.SetActive(false);
        closeBtn.SetActive(false);
        settingsBtn.SetActive(true);
    }

    public void OpenMenu()
    {
        Time.timeScale = 0.00001f;
        menuOverlay.SetActive(true);
        settingsBtn.SetActive(false);
        closeBtn.SetActive(true);
    }
    
    public void CloseMenu()
    {
        Time.timeScale = 1.0f;
        menuOverlay.SetActive(false);
        settingsBtn.SetActive(true);
        closeBtn.SetActive(false);
    }
    
    
}
