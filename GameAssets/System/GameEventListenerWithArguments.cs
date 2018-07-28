using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerWithArguments : GameEventListener {
	
	new public CardTransferEvent responseWithArgs;

	public override void OnEventRaised(MonoBehaviour argument) {
		Debug.Log(argument);
		
		responseWithArgs.Invoke(argument);
	}
}