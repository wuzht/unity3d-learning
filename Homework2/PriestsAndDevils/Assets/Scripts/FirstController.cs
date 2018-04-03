using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, IUserAction {
	public CoastController fromCoast;
	public CoastController toCoast;
	public BoatController boat;
	private ICharacterController[] characters;
    readonly Vector3 riverPosition = new Vector3(0, 0.5F, 0);
    UserUI userUI;

    void Awake() {
		SSDirector director = SSDirector.GetInstance();
        director.SetFPS(60);
		director.currentSceneController = this;
		userUI = gameObject.AddComponent<UserUI>() as UserUI;
		characters = new ICharacterController[6];
		LoadResources();
	}

	public void LoadResources() {
		GameObject river = Instantiate(Resources.Load("Perfabs/River", typeof(GameObject)), riverPosition, Quaternion.identity, null) as GameObject;
		river.name = "river";
		fromCoast = new CoastController("from");
		toCoast = new CoastController("to");
		boat = new BoatController();
		LoadCharacter();
	}

	private void LoadCharacter() {
		for (int i = 0; i < 3; i++) {
            ICharacterController character = new ICharacterController("priest");
            character.SetName("priest" + i);
            character.SetPosition(fromCoast.GetEmptyPosition());
            character.GetOnCoast(fromCoast);
			fromCoast.GetOnCoast(character);
			characters[i] = character;
		}

		for (int i = 0; i < 3; i++) {
            ICharacterController character = new ICharacterController("devil");
            character.SetName("devil" + i);
            character.SetPosition(fromCoast.GetEmptyPosition());
            character.GetOnCoast(fromCoast);
			fromCoast.GetOnCoast(character);
			characters[i + 3] = character;
		}
	}

	public void MoveBoat() {
		if (boat.IsEmpty())
			return;
		boat.Move();
		userUI.status = CheckGameOver();
	}

	public void CharacterIsClicked(ICharacterController characterController) {
		if (characterController.IsOnBoat()) {
			CoastController whichCoast;
			if (boat.Get_to_or_from() == -1) // to -1; from 1
				whichCoast = toCoast;
			else
				whichCoast = fromCoast;
			boat.GetOffBoat(characterController.GetName());
            characterController.MoveToPosition (whichCoast.GetEmptyPosition());
            characterController.GetOnCoast(whichCoast);
			whichCoast.GetOnCoast(characterController);

		}
        else {									// character on coast
			CoastController whichCoast = characterController.GetCoastController();
			if (boat.GetEmptyIndex() == -1)		// boat is full
				return;
			if (whichCoast.GetToOrFrom() != boat.Get_to_or_from())	// boat is not on the side of character
				return;
			whichCoast.GetOffCoast(characterController.GetName());
            characterController.MoveToPosition (boat.GetEmptyPosition());
            characterController.GetOnBoat(boat);
			boat.GetOnBoat(characterController);
		}
		userUI.status = CheckGameOver();
	}

	int CheckGameOver() {	// playing 0, lose 1, win 2
		int fromPriest = 0;
		int fromDevil = 0;
		int toPriest = 0;
		int toDevil = 0;

		int[] fromCount = fromCoast.GetCharacterNum();
		fromPriest += fromCount[0];
		fromDevil += fromCount[1];

		int[] toCount = toCoast.GetCharacterNum();
		toPriest += toCount[0];
		toDevil += toCount[1];

		if (toPriest + toDevil == 6)
			return 2;
		int[] boatCount = boat.GetCharacterNum ();
		if (boat.Get_to_or_from () == -1) {
			toPriest += boatCount[0];
			toDevil += boatCount[1];
		}
        else {
			fromPriest += boatCount[0];
			fromDevil += boatCount[1];
		}
		if (fromPriest < fromDevil && fromPriest > 0)
			return 1;
		if (toPriest < toDevil && toPriest > 0)
			return 1;
		return 0;
	}

	public void ReStart() {
        boat.Reset();
        fromCoast.Reset();
        toCoast.Reset();
        for (int i = 0; i < characters.Length; i++)
			characters [i].Reset();
    }
}