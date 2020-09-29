using DragonCoderStudios.RTSTheBoardGame.Core.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragonCoderStudios.RTSTheBoardGame.Core.Tokens
{
    public class BaseToken
    {
        public Player Owner { get; }

        public BaseToken(Player p)
        {
            Owner = p;
        }
    }
}
