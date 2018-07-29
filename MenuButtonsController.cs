using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonsController : MonoBehaviour {

	// To use this example, attach this script to an empty GameObject.
	// Create two buttons (Create>UI>Button). Next, click your
	// empty GameObject in the Hierarchy and click and drag each of your
	// Buttons from the Hierarchy to the Your First Button and "Your Second Button"
	// fields in the Inspector.
	// Click each Button in Play Mode to output the message to the console.

	//Make sure to attach these Buttons in the Inspector
	public Button m_YourFirstButton, m_YourSecondButton;

	void Start()
	{
		Button btn1 = m_YourFirstButton.GetComponent<Button>();
		Button btn2 = m_YourSecondButton.GetComponent<Button>();

		//Calls the TaskOnClick/TaskWithParameters method when you click the Button
		Debug.Log("Hello");
		btn1.onClick.AddListener(TaskOnClick);
		btn2.onClick.AddListener(delegate {TaskWithParameters("Hello"); });
	}

	void TaskOnClick()
	{
		//Output this to console when the Button is clicked
		Debug.Log("You have clicked the button!");
	}

	void TaskWithParameters(string message)
	{
		//Output this to console when the Button is clicked
		Debug.Log(message);
	}
}
