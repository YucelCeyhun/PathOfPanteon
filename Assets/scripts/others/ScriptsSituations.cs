using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ToggleEvent : UnityEvent<bool> { }

public class ScriptsSituations : MonoBehaviour {

    [SerializeField]
    ToggleEvent scripts;

    public void Situations(bool state)
    {
        scripts.Invoke(state);
    }


}
