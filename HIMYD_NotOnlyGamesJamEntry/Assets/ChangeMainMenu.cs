using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;
public class ChangeMainMenu : MonoBehaviour
{
    public PlayerIndex playerIndex;
    GamePadState state;
    void Start()
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
      
    }

    void Update()
    {
        state = GamePad.GetState(playerIndex);
        if (state.Buttons.A== ButtonState.Pressed)
        {
            ChangeScene();
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Level_001");
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}