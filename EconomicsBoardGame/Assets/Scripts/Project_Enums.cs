﻿public class Project_Enums
{
    public enum EVENT_TYPE { PLAYER_ARRIVED, DICE_FINISHED};
    public enum GAME_STATUS { WAITING_THROW, AFTER_THROW};
    public enum TILE_TYPE {FREE, BUSSINESS, FACTORY ,RESIDENCE, INNOVATIVE, VALUE, FARM, OTHER, EMPTY};
    public enum TILE_STATUS {UNOWNED_LAND, OWNED_LAND};
    public enum BUTTON_TYPE {THROW_DICE, END_TURN, BUY}
    public enum PLAYER_COLORS {NONE, GREEN, RED, BLUE, YELLOW};
    public enum EMPTY_TILE_TYPE {START, NORMAL};
    public enum BUSSINESS_TYPE {RESTAURAT, SUPERMARKET, IMPORTER};
    public enum VALUE_BUSINESS_TYPE {MOVIE_PRODUCTION, FOOD_FACTORY, SOFTWARE_INTERNATIONAL};
    public enum INNOVATIVE_TYPE {TECHNOLOGY, GAME_DEV, RESEARCH, TRAINING};
    public enum OTHER_TYPE {UTILITY, MARKETING, ENTERTAINMENT};
}
