using System;
using Rocket.API;

namespace GS.NoName
{
	public class CoreConfig : IRocketPluginConfiguration, IDefaultable
	{
		public void LoadDefaults()
		{
			characterName = "Неизвестный";
		}

		public string characterName;
	}

}
