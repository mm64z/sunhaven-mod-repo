using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using Wish;
using static Version;
// using Sirenix.Serialization;

// namespace RepeatHeartEventPlugin
// {
  [BepInPlugin(Version.GUID, "Repeat 15 heart event", Version.VERSION)]
  public class RepeatHeartEventPlugin : BaseUnityPlugin
  {
    private Harmony harmony = new Harmony(Version.GUID);
    public static ManualLogSource logger;

    private static ConfigEntry<bool> mEnabled;

    private void Awake()
    {
      logger = this.Logger;
      try
      {
        this.harmony.PatchAll();
        mEnabled = this.Config.Bind<bool>(
          "General",
          "Enabled",
          true,
          "Set to false to disable this mod."
        );
        logger.LogInfo((object)"" + Version.GUID + " " + Version.VERSION + " loaded.");
      }
      catch (Exception e)
      {
        logger.LogError("** Awake FATAL - " + e);
      }
    }

    [HarmonyPatch(typeof(Player), "FinishSleeping")]
    class HarmonyPatch_Player_FinishSleeping {
		  private static void Postfix() {
        try {
          GameSave.Instance.SetProgressBoolCharacter(ProgressID.AnneLateNightCutscene, false);
          GameSave.Instance.SetProgressBoolCharacter(ProgressID.CatherineLateNightCutscene, false);
          GameSave.Instance.SetProgressBoolCharacter(ProgressID.ClaudeLateNightCutscene, false);
          GameSave.Instance.SetProgressBoolCharacter(ProgressID.DariusLateNightCutscene, false);
          GameSave.Instance.SetProgressBoolCharacter(ProgressID.DonovanLateNightCutscene, false);
          GameSave.Instance.SetProgressBoolCharacter(ProgressID.IrisLateNightCutscene, false);
          GameSave.Instance.SetProgressBoolCharacter(ProgressID.JunLateNightCutscene, false);
          GameSave.Instance.SetProgressBoolCharacter(ProgressID.KittyLateNightCutscene, false);
          GameSave.Instance.SetProgressBoolCharacter(ProgressID.LiamLateNightCutscene, false);
          GameSave.Instance.SetProgressBoolCharacter(ProgressID.LuciaLateNightCutscene, false);
          GameSave.Instance.SetProgressBoolCharacter(ProgressID.LynnLateNightCutscene, false);
          GameSave.Instance.SetProgressBoolCharacter(ProgressID.NathanielLateNightCutscene, false);
          GameSave.Instance.SetProgressBoolCharacter(ProgressID.VaanLateNightCutscene, false);
          GameSave.Instance.SetProgressBoolCharacter(ProgressID.WornhardtLateNightCutscene, false);
          GameSave.Instance.SetProgressBoolCharacter(ProgressID.XylaLateNightCutscene, false);
        } catch (Exception e) {
          logger.LogError("** ScenePortalSpot.Awake_Postfix ERROR - " + e);
        }
      }
    }
  }
// }
