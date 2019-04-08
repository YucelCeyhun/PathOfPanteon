using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ToggleActive
{
    public GameObject ui;
    public KeyCode kcode;

}

public class ToggleSystem : MonoBehaviour {

    public GameObject player;
    public List<ToggleActive> toggle;

	void Update ()
    {
        KeyControl();
    }

    void KeyControl()
    {
        if (Input.GetKeyDown(toggle[0].kcode))
        {
            ScriptsSituations situations = player.GetComponent<ScriptsSituations>();

            if (!toggle[0].ui.activeSelf)
            {
                situations.Situations(false);
                toggle[0].ui.SetActive(true);
            }
            else
            {
                situations.Situations(true);
                toggle[0].ui.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(toggle[1].kcode))
        {
            ScriptsSituations situations = player.GetComponent<ScriptsSituations>();

            if (!toggle[1].ui.activeSelf)
            {
                //situations.Situations(false);
                toggle[1].ui.SetActive(true);
            }
            else
            {
                //situations.Situations(true);
                toggle[1].ui.SetActive(false);
            }
        }

    }
}
