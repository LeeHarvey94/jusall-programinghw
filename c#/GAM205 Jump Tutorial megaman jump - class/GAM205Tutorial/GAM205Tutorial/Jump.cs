﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GAM205Tutorial
{
    public partial class Player : GameObject
    {
        /// <summary>
        /// This variable is *(automatically)* set to true when the player is standing on a block.
        /// </summary>
        private bool _standing = false;
        private float startY;
        private bool top, firstJump ,seccondJump;
        private  float jumpSpeed ;        
        
        /// <summary>
        /// This is called once per update cycle.
        /// </summary>
        private void UpdatePlayer()
        {
            if (!_standing)
            {
                this.Y += 7;
            }
            else {
                this.top = false;
                this.firstJump = false;
                this.seccondJump = false;

            }
        }

        /// <summary>
        /// This method is triggered when the player presses the jump button (space).
        /// </summary>
        public void Jump()
        {
            if (!seccondJump)
            {
                top = false;
                startY = this.Y;
                jumpSpeed = 26.0f;
            }
        }

        /// <summary>
        /// This method is called every cycle while the jump key is pressed down.
        /// </summary>
        public void HoldJump()
        {
            if (startY - 100 <= this.Y && !top && !seccondJump)
            {
                this.Y -= jumpSpeed;
                jumpSpeed *= .85f;
            }
            else
                top = true;
        }

        /// <summary>
        /// This method is triggered when the player
        /// </summary>
        /// <param name="duration"></param>
        public void EndJump(int duration)
        {
            if (!firstJump)
                firstJump = true;
            else
                seccondJump = true;
        }
    }
}
