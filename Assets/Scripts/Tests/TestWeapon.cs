using UnityEngine;
using UnityEngine.InputSystem;

public class TestWeapon : MonoBehaviour
{
    public Weapon weaponToTest;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            weaponToTest.PullTrigger(0);
        }
        if (Keyboard.current.spaceKey.wasReleasedThisFrame)
        {
            weaponToTest.ReleaseTrigger(0);
        }

        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            weaponToTest.PullTrigger(1);
        }
        if (Keyboard.current.cKey.wasReleasedThisFrame)
        {
            weaponToTest.ReleaseTrigger(1);
        }


    }
}
