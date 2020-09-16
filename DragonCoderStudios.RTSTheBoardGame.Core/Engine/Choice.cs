using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonCoderStudios.RTSTheBoardGame.Core.Engine
{
    public class Choice
    {
        public string Prompt { get; }

        public List<string> Choices { get; }

        public Action<string,Game> ExecuteChoice { get; }

        public Choice(
            string prompt,
            IEnumerable<string> choices,
            Action<string, Game> onExecute)
        {
            Prompt = prompt;
            Choices = choices.ToList();
            ExecuteChoice = onExecute;
        }
    }
}
