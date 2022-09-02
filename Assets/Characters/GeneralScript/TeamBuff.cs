using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NBGame.Player
{
    //a buff that will be apply to all team member
    public interface TeamBuff
    {
        //when the buff is firt added 
        public void initiate(teamScripts target);

        //when there is already a buff like this
        public void overlying(TeamBuff overlayedBuff, teamScripts target);

        //when overlay by the same buff(stop the script from doing anything)
        public void overlayed();
    }
}