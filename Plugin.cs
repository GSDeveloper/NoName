using System;
using System.Net;
using System.Linq;
using Rocket.Core.Plugins;
using Rocket.Unturned.Permissions;
using SDG.Unturned;
using Steamworks;

namespace GS.NoName
{
	public class Plugin : RocketPlugin<CoreConfig>
	{
        protected override void Load()
		{
			Plugin.Instance = this;
            UnturnedPermissions.OnJoinRequested -= new UnturnedPermissions.JoinRequested(this.OnJoinRequested);
		}

		public void OnJoinRequested(CSteamID PlayerID, ref ESteamRejection? RejectionReason)
		{
			SteamPending steamPending = Provider.pending.FirstOrDefault((SteamPending SP) => SP.playerID.steamID == PlayerID);
			steamPending.playerID.characterName = base.Configuration.Instance.characterName;
		}

		protected override void Unload()
		{
			UnturnedPermissions.OnJoinRequested -= new UnturnedPermissions.JoinRequested(this.OnJoinRequested);
		}

		public static Plugin Instance;
	}
}
