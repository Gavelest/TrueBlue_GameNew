using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Dialogue : MonoBehaviour
{
var activateGUI , GUITexture;
var infoText , GUIText;
var detailsText , GUIText;
var objectName = "Object001";
var useButton = "(E)";
var doThis = "Activate";
var pressButton = "Activate";
var itemWG = 0.0;
var itemVAL = 0.0;

function Start () {
	infoText.text = " ";
	detailsText.text = " ";
	activateGUI.guiTexture.color = Color(0,0,0,0);
}

function OnMouseOver () {
	activateGUI.guiTexture.color = Color(0.5,0.5,0.5,0.5);
	infoText.text = useButton + " " + doThis + " " + objectName;
	detailsText.text = "VAL = " + itemVAL + " " + "|" + " WG = " + itemWG;
	if (Input.GetButton(pressButton)){
		Destroy(gameObject);
		activateGUI.guiTexture.color = Color(0,0,0,0);
		infoText.text = " ";
		detailsText.text = " ";
	}
}

function OnMouseExit () {
	activateGUI.guiTexture.color = Color(0,0,0,0);
	infoText.text = " ";
	detailsText.text = " ";
}
}