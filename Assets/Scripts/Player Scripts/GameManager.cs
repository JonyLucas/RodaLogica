using Game.Player.PlayerInput;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void StartGame(bool isMultiplayer)
    {
        CreatePlayer(true);
        if (isMultiplayer)
        {
            CreatePlayer(false);
        }
    }

    private void CreatePlayer(bool isPlayer1)
    {
        var inputManager = CreateInputManager();
    }

    private GameObject CreateInputManager()
    {
        var inputManager = new GameObject("InputManager");
        inputManager.AddComponent<InputManager>();
        return Instantiate(inputManager, transform);
    }

    public void GameOver()
    {
        // Destroy the input managers.
        DestroyInputManagers();
    }

    private void DestroyInputManagers()
    {
        var components = transform.GetComponentsInChildren<InputManager>();
        var count = components.Count();
        for (int i = 0; i < count; i++)
        {
            Destroy(components[i].gameObject);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}