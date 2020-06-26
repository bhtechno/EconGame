using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Project_Enums;
public class CustomEventSystem : MonoBehaviour
{

    // the function prototype, for those that will be called
    // after an event is fired
    public delegate void EventListener(EventInfo eventInfo);

    // Dictionary that holds a list of all event listeners, for each event type
    static Dictionary <EVENT_TYPE, List<EventListener>> eventListeners;

    private void Awake() {
        eventListeners = new Dictionary<EVENT_TYPE, List<EventListener>>();
    }

    /*
     * Given an enum with event type, and a function pointer(delegate),
     * when such an event is fired, the function will be called. This is a
     * static class, where all the game's events should be processed
     */

    public static void RegisterListener(EVENT_TYPE eventType, EventListener listener) {
        if (!eventListeners.ContainsKey(eventType) || eventListeners[eventType] == null) {
            eventListeners[eventType] = new List<EventListener>();
        }
        eventListeners[eventType].Add(listener);
    }


    /*
     * UnRegister a previously registered listening fucntion for the passed type event enum
     */
    public void UnRegisterListener(EVENT_TYPE eventType) {
        if (eventListeners.ContainsKey(eventType))
            eventListeners.Remove(eventType);
    }

    /*
     * Function is called by the gameobject who completed a task, and now
     * wants to notify all listeners that it has finished
     * Receives the event type, and optionally an eventInfo
     */
    public static void fireEvent(EVENT_TYPE eventType, EventInfo eventInfo = null) {
        if (eventListeners == null || eventListeners[eventType] == null)
        {
            // No one is listening, no problem.
            return;
        }
        foreach (EventListener eventListener in eventListeners[eventType]) {
            eventListener(eventInfo);
        }
    }

}
