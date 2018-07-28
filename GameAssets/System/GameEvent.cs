using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName="GameJam/New Event")]
public class GameEvent : ScriptableObject {
	private readonly List<GameEventListener> eventListeners =
		new List<GameEventListener>();

	public void Raise() {
		for(int i = eventListeners.Count -1; i >= 0; i--){
			eventListeners[i].OnEventRaised();
		}
	}

	public void Raise(MonoBehaviour argument){
		for(int i = eventListeners.Count -1; i >= 0; i--){
			eventListeners[i].OnEventRaised(argument);
		}
	}

	public void RegisterListener(GameEventListener listener) {
		if(!eventListeners.Contains(listener)) {
			eventListeners.Add(listener);
		}
	}

	public void UnregisterListener(GameEventListener listener) {
		if (eventListeners.Contains(listener)){
			eventListeners.Remove(listener);
		}
	}
}
