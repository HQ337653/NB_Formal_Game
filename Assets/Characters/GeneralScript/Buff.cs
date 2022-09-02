using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NBGame.Player
{
    public interface Buff
    {
       public void initiate(characterScripts target);
        public void overlying(Buff overlayedBuff, characterScripts target);

        public void overlayed();
    }
}
