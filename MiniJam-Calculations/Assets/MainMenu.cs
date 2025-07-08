using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;


public class MainMenu : MonoBehaviour
{

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        animator.SetTrigger("RunAnimation");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    } 

    public void OpenSettings()
    {
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    
}
