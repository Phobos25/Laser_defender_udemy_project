using UnityEngine;

public class MouseLock : MonoBehaviour {

	//hides and locks mouse cursos
	public void LockMouseCursor()
    {
        //locks mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        //hides mouse cursor
        Cursor.visible = false;
    }
	
    //reveals and unlocks mouse cursor
    public void UnlockMouseCursor()
    {
        //unlock mouse cursor
        Cursor.lockState = CursorLockMode.None;
        //reveal mouse cursor
        Cursor.visible = true;
    }
	
}
