﻿namespace KaiFighterGame.Scenes
{
    using System;
    using System.IO;
    using Microsoft.Xna.Framework;

    using Factories;
    using GlobalConstants;
    using Interfaces;
    using UI;
    using Utilities;

    public class StatsLevel : ButtonController, IScene
    {
        private Button backButton;
        private Button clearStatsButton;
        private int deaths;
        private int maxScore;
        private int killsCount;

        public void Load()
        {
            this.LoadStats();

            Background backgr = (Background)UiFactory.Instance.Create(
                Color.White,
                ImageAddresses.StatsBackgroundImage,
                backgroundScale: .72f,
                backgroundLayer: RenderLayers.BackgroundLayer);
            SceneManager.AddObject(backgr);

            this.backButton = (Button)UiFactory.Instance.Create(
                Color.White,
                new Vector2(50, 50),
                ImageAddresses.NormalBackButton,
                ImageAddresses.HoveredBackButton,
                ImageAddresses.InactiveBackButton,
                RenderLayers.UiLayer,
                scale: .8f);
            SceneManager.AddObject(this.backButton);

            this.clearStatsButton = (Button)UiFactory.Instance.Create(
                Color.White,
                new Vector2(50, 130),
                ImageAddresses.NormalClearStatsButton,
                ImageAddresses.HoveredClearStatsButton,
                ImageAddresses.InactiveClearStatsButton,
                RenderLayers.UiLayer,
                scale: .8f);
            SceneManager.AddObject(this.clearStatsButton);

            TextField deaths = (TextField)UiFactory.Instance.Create(
                FontAddresses.StatsFont,
                "Number of deaths: " + this.deaths,
                Color.Red,
                new Vector2(50, 250),
                RenderLayers.UiLayer);
            SceneManager.AddObject(deaths);

            TextField kills = (TextField)UiFactory.Instance.Create(
                FontAddresses.StatsFont,
                "Number of kills: " + this.killsCount,
                Color.Red,
                new Vector2(50, 350),
                RenderLayers.UiLayer);
            SceneManager.AddObject(kills);

            TextField score = (TextField)UiFactory.Instance.Create(
                FontAddresses.StatsFont,
                "Max score: " + this.maxScore,
                Color.Red,
                new Vector2(50, 450),
                RenderLayers.UiLayer);
            SceneManager.AddObject(score);

            this.CurrentSelectedButton = this.backButton;

            this.Buttons.Add(this.backButton);
            this.Buttons.Add(this.clearStatsButton);

            this.backButton.OnPressed += this.LoadMenu;
            this.clearStatsButton.OnPressed += this.ClearStats;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        private void ClearStats()
        {
            using (var writer = new StreamWriter(File.Open("../../SavedGame.txt", FileMode.OpenOrCreate)))
            {
                writer.WriteLine("0");
                writer.WriteLine("0");
                writer.WriteLine("0");

                writer.Close();
            }

            SceneManager.LoadScene(new StatsLevel());
        }

        private void LoadMenu()
        {
            this.backButton.OnPressed -= this.LoadMenu;
            this.clearStatsButton.OnPressed -= this.ClearStats;

            SceneManager.LoadScene(new MainMenu());
        }

        private void LoadStats()
        {
            using (var reader = new StreamReader(File.Open("../../SavedGame.txt", FileMode.OpenOrCreate))) 
            {
                string deaths = reader.ReadLine();

                if (string.IsNullOrEmpty(deaths))
                {
                    this.deaths = 0;
                }
                else
                {
                    this.deaths = int.Parse(deaths);
                }

                string score = reader.ReadLine();

                if (string.IsNullOrEmpty(score))
                {
                    this.maxScore = 0;
                }
                else
                {
                    this.maxScore = Convert.ToInt32(score);
                }

                string killsCount = reader.ReadLine();

                if (string.IsNullOrEmpty(killsCount))
                {
                    this.killsCount = 0;
                }
                else
                {
                    this.killsCount = int.Parse(killsCount);
                }

                reader.Close();
            }
        }
    }
}