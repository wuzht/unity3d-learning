using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSDirector : System.Object {
	private static SSDirector myInstance;
	public ISceneController currentSceneController { get; set; }
	private SSDirector() { }
	public static SSDirector GetInstance() {
		if (myInstance == null)
			myInstance = new SSDirector();
		return myInstance;
	}

    public int GetFPS()
    {
        return Application.targetFrameRate;
    }

    public void SetFPS(int fps)
    {
        Application.targetFrameRate = fps;
    }
}

public interface IUserAction {
    void MoveBoat(GameObject clickedObject);
    void CharacterIsClicked(ICharacterController characterController, GameObject clickedObject);
    void ReStart();
}

public interface ISceneController {
	void LoadResources();
}