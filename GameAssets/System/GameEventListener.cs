using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour {
	[Tooltip("Event to register with")]
	public GameEvent Event;

	[Tooltip("Response to invoke when Event is raised")]
	public UnityEvent response;

	private void OnEnable(){
		if(Event)
		Event.RegisterListener(this);
	}

	private void OnDisabled(){
		Event.UnregisterListener(this);
	}

	public virtual void OnEventRaised() {
		Debug.Log("Ëvent Raised");
		response.Invoke();
	}
	public virtual void OnEventRaised(MonoBehaviour argument) {
		response.Invoke();
		Debug.Log(argument);
	}

	public void RegisterEvent(GameEvent listenedEvent, UnityEvent responseEvent){
		Debug.Log(responseEvent.ToString());
		Event = listenedEvent;
		Event.RegisterListener(this);

		response = responseEvent;
	}
}