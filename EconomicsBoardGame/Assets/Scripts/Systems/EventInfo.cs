public class EventInfo {

    /*
     * This class represents the object that is passed from the
     * event caller, to the event listener. As more fields are needed,
     * it could be expanded.
     */
    short playerIndex = -1;
    public EventInfo(short index) {
        playerIndex = index;
    }
    public short getPlayerIndex() {
        return playerIndex;
    }
}
