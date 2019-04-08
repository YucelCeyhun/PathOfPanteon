using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class PlayerSpellTrigger : UnityEvent
{
    public void DoThat()
    {
        Invoke();
    }
}


[System.Serializable]
public class PlayerSpellCaster
{

    public PlayerSpellTrigger mainTrigger;
    public PlayerSpellTrigger othersTrigger;

}

