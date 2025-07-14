using UnityEngine;

namespace Game.Management
{
    /// <summary>
    /// Manages the game state and overall game logic.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
