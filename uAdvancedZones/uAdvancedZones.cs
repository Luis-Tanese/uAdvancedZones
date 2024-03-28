using Game4Freak.AdvancedZones;
using Rocket.Unturned.Player;
using System.Reflection;
using UnityEngine;
using uScript.API.Attributes;
using uScript.Core;
using uScript.Module.Main.Classes;
using uScript.Unturned;

namespace uAdvancedZones
{
    [ScriptEvent("onPlayerEnterAdvancedZone", "player, zonename, position")]
    public class OnZoneEnteredAdvancedZone : ScriptEvent
    {
        public override EventInfo EventHook(out object instance)
        {
            instance = null;
            return typeof(AdvancedZones).GetEvent("onZoneEnter", BindingFlags.Public | BindingFlags.Static);
        }

        [ScriptEventSubscription]
        public void OnZoneEntered(UnturnedPlayer player, Zone zone, Vector3 lastPos)
        {
            var args = new ExpressionValue[]
            {
            ExpressionValue.CreateObject(new PlayerClass(player.Player)),
            zone.name,
            ExpressionValue.CreateObject(new Vector3Class(lastPos))
            };

            RunEvent(this, args);
        }
    }
    [ScriptEvent("onPlayerLeftAdvancedZone", "player, zonename, position")]
    public class OnZoneLeftAdvancedZone : ScriptEvent
    {
        public override EventInfo EventHook(out object instance)
        {
            instance = null;
            return typeof(AdvancedZones).GetEvent("onZoneLeave", BindingFlags.Public | BindingFlags.Static);
        }
        [ScriptEventSubscription]
        public void OnZoneLeft(UnturnedPlayer player, Zone zone, Vector3 lastPos)
        {
            var args = new ExpressionValue[]
            {
                ExpressionValue.CreateObject(new PlayerClass(player.Player)),
                zone.name,
                ExpressionValue.CreateObject(new Vector3Class(lastPos))
            };
            RunEvent(this, args);
        }
    }
}