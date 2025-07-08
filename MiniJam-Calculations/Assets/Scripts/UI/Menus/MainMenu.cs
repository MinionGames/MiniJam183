using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

namespace Game.UI.Menus
{
    /// <summary>
    /// This script controls the main menu of the game.
    /// </summary>
    public class MainMenu : MenuBase
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
}
