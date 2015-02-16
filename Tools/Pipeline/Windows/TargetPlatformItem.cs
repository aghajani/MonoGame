using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoGame.Tools.Pipeline
{
    public class TargetPlatformItem
    {
        public Microsoft.Xna.Framework.Content.Pipeline.TargetPlatform TargetPlatform { get; private set; }

        public TargetPlatformItem(Microsoft.Xna.Framework.Content.Pipeline.TargetPlatform target)
        {
            TargetPlatform = target;
        }

        public override string ToString()
        {
            return TargetPlatform.ToString();
        }
    }
}
