﻿using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Events;

namespace NoKidsEver
{    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {
        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            GameEvents.UpdateTick += this.GameEvents_UpdateTick;
        }

        public void GameEvents_UpdateTick(object sender, EventArgs e)
        {
            bool isBabyQuestion =
                Game1.farmEvent is QuestionEvent
            && this.Helper.Reflection.GetPrivateValue<int>(Game1.farmEvent, "whichQuestion") ==
            QuestionEvent.pregnancyQuestion;

            if (isBabyQuestion && Game1.activeClickableMenu is DialogueBox dialogue)
            {
                // answer question
                Response no = this.Reflection.GetPrivateValue<List<Response>>(dialogue, "responses")[1];
                Game1.currentLocation.answerDialogue(no);
                dialogue.closeDialogue();

                // reverse penalty
                // TODO: look at the game code to see what the friendship penalty is,
                //       and just add an equivalent number of points back.
            }





            /*if (isBabyQuestion)
            {
                this.Monitor.Log("Skipping baby question...");
                Game1.farmEvent = null;
                Game1.messagePause = false;
                this.Helper.Reflection.GetPrivateField<GameLocation.afterQuestionBehavior>
            (Game1.currentLocation, "afterQuestion").SetValue(null);
                Game1.objectDialoguePortraitPerson = null;
                Game1.dialogueUp = false;
                Game1.player.CanMove = true;
                Game1.activeClickableMenu.exitThisMenu();*/
        }
        }  
        /* Just my little "thank you" to Pathos for the INSANE level of patience displayed
         * during the countless hours of me pestering them on discord with questions, and all
         * the explanations provided. It could not have been done, by me at least, without their
         * help. Thank you. :D */
    }
}