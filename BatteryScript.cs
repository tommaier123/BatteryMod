using UnityEngine;
using System.Collections;
using UMod;
using Synth.mods.utils;
using Synth.mods.events;
using Synth.mods.info;
using System.Collections.Generic;
using Synth.mods.interactions;
using System;
using UnityEngine.SceneManagement;

public class BatteryScript : ModScript, ISynthRidersEvents, ISynthRidersInfo, ISynthRidersInteractions
{

    GameObject battery = null;

    public override void OnModLoaded()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    public override void OnModUnload()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }

    public void OnRoomLoaded()
    {

    }

    public void OnRoomUnloaded()
    {

    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name.Contains("Stage"))
        {
            battery = ModAssets.Instantiate<GameObject>("battery_pre");
            BatteryBar.bar = ModAssets.Instantiate<GameObject>("bar_pre");
        }
        else
        {
            BatteryBar.GameOverCallback = null;
            BatteryBar.DestroyBatteryBar();
            UnityEngine.Object.Destroy(battery);
            battery = null;
        }
    }

    public void OnGameStageLoaded(TrackData trackData)
    {
        BatteryBar.misses = 0;
    }

    public void OnGameStageUnloaded()
    {

    }

    public void OnScoreStageLoaded()
    {

    }

    public void OnScoreStageUnloaded()
    {

    }

    public void OnNoteFail(PointsData pointsData)
    {
        BatteryBar.hit();
    }

    public void OnPointScored(PointsData pointsData)
    {

    }

    public void OnSongFinished(SongFinishedData songFinishedData)
    {

    }


    public void OnSongFailed(TrackData trackData)
    {

    }

    public void SetLoadedTracks(List<TrackData> tracks)
    {

    }

    public void SetLoadedStages(List<StageData> stages)
    {

    }

    public void SetUserSelectedColors(Color leftHandColor, Color rightHandColor, Color oneHandSpecialColor, Color bothHandSpecialColor)
    {

    }

    public void SetUICanvasCallback(Action<GameObject> callback)
    {
        
    }

    public void SetGameOverCallback(Action callback)
    {
        BatteryBar.GameOverCallback = callback;
    }

    public void SetPlayTrackCallback(Action<int, int, int> callback)
    {
        
    }

    public void SetCurrentSongSelected(int CurrentSong)
    {
        
    }

    public void SetSelectedTrackCallback(Action<int> callback)
    {
        
    }

    public void SetRefreshCallback(Action<Action, bool> callback)
    {
        
    }

    public void SetFilterTrackCallback(Action<List<string>, Action, bool> callback)
    {
        
    }
}
