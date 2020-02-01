using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Loads a scene or closes the game.
/// Attach this to the canvas that contains the button you want to load scenes with.
/// Go into said button, and under the light grey "OnClick ()" panel, drag the canvas into the slot under the runtime dropdown.
/// NOW click the dropdown next to the runtime dropdown, and mouse over MenuLoader. Choose one of the methods below to run them on click.
/// </summary>
public class MenuLoader : MonoBehaviour
{
    /// <summary>
    /// Loads a scene by a given index.
    /// </summary>
    /// <param name="sceneIndex">The index of the scene to load.</param>
    public void LoadSceneOnClick(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void CloseGameOnClick()
    {
        Application.Quit();
    }
}
