using DragonCoderStudios.RTSTheBoardGame.Core.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragonCoderStudios.RTSTheBoardGame.Core.Tokens
{
    public class PromissaryNote : BaseToken
    {
        public PromissaryNote(Player p) : base(p) { }

        public static PromissaryNote PoliticalSecret()
        {
            return new PromissaryNote(null);
        }
        public static PromissaryNote TradeAgreement()
        {
            return new PromissaryNote(null);
        }
        public static PromissaryNote SupportForTheThrone()
        {
            return new PromissaryNote(null);
        }
        public static PromissaryNote CeaseFire()
        {
            return new PromissaryNote(null);
        }
    }
}
