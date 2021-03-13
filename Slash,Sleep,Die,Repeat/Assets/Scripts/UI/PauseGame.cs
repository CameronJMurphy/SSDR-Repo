using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    bool paused;
    [SerializeField] Canvas pauseMenu;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
		{
            if(!paused)
			{
                Pause();
            }
			else
			{
                Unpause();
            }
		}
    }

    public void Pause()
	{
        paused = true;
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
    }
    public void Unpause()
	{
        paused = false;
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
    }
}
