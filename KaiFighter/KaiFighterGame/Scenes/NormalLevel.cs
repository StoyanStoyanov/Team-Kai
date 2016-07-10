﻿namespace KaiFighterGame.Scenes
{
    using Factories;
    using GlobalConstants;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;
    using Objects.DynamicObjects.Characters;
    using Objects.DynamicObjects.Characters.Enemies;
    using Objects.StaticObjects;
    using UI;
    using Utilities;

    public class NormalLevel : IScene
    {
        private Song fightMusic;

        public void Load()
        {
            this.fightMusic = EntryPoint.TheGame.Content.Load<Song>(AudioAddresses.FightSong);

            MediaPlayer.IsRepeating = true;

            if (MediaPlayer.State == MediaState.Stopped)
            {
                MediaPlayer.Play(this.fightMusic);
            }

            // add background
            Background backgr = (Background)UiFactory.Instance.Create(
                Color.White,
                ImageAddresses.LevelBackgroundImage,
                .72f,
                RenderLayers.BackgroundLayer);
            SceneManager.AddObject(backgr);

            Player fighter = (Player)DynamicObjectFactory.Instance.Create(
                new Vector2(100, 500),
                ImageAddresses.PlayerImage,
                ObjectType.Player,
                Color.White,
                scale: 0.6f,
                rotation: 0,
                layerDepth: RenderLayers.CharacterLayer,
                movementSpeed: 5f,
                damage: 50,
                health: 100,
                cooldown: 5
            );
            SceneManager.AddObject(fighter);

            Creep testCreep = (Creep)DynamicObjectFactory.Instance.Create(
                new Vector2(205, 555),
                ImageAddresses.CreepImage,
                ObjectType.Creep,
                Color.White,
                scale: 0.5f,
                rotation: 0,
                layerDepth: RenderLayers.CharacterLayer,
                movementSpeed: 1f,
                damage: 5,
                health: 100
            );
            SceneManager.AddObject(testCreep);

            Wizard testWizard = (Wizard)DynamicObjectFactory.Instance.Create(
                new Vector2(405, 305),
                ImageAddresses.WizardImage,
                ObjectType.Wizard,
                Color.White,
                scale: 0.5f,
                rotation: 0,
                layerDepth: RenderLayers.CharacterLayer,
                movementSpeed: 1f,
                damage: 5,
                health: 100
            );
            SceneManager.AddObject(testWizard);

            Boss testBoss = (Boss)DynamicObjectFactory.Instance.Create(
               new Vector2(505, 505),
               ImageAddresses.BossImage,
               ObjectType.Boss,
               Color.White,
               scale: 1.5f,
               rotation: 0,
               layerDepth: RenderLayers.CharacterLayer,
               movementSpeed: 1f,
               damage: 10,
               health: 300
);
            SceneManager.AddObject(testBoss);

            Archer testArcher = (Archer)DynamicObjectFactory.Instance.Create(
                new Vector2(800, 500),
                ImageAddresses.ArcherImage,
                ObjectType.Archer,
                Color.White,
                scale: 0.5f,
                rotation: 0,
                layerDepth: RenderLayers.CharacterLayer,
                movementSpeed: 1f,
                damage: 5,
                health: 100,
                cooldown: 50
            );
            SceneManager.AddObject(testArcher);

            // Add player HUD
            PlayerHUD hud = (PlayerHUD)UiFactory.Instance.Create(
                FontAddresses.HudFont,
                Color.White,
                fighter,
                RenderLayers.UiLayer);
            SceneManager.AddObject(hud);

            Wall topWall = (Wall)StaticObjectFactory.Instance.Create(
                    new Vector2(GameResolution.DefaultWidth / 2, 0),
                    ImageAddresses.HorizontalWall,
                    ObjectType.Wall,
                    Color.DarkCyan,
                    1f,
                    0f,
                    1f
                );
            SceneManager.AddObject(topWall);

            Wall bottomWall = (Wall)StaticObjectFactory.Instance.Create(
                    new Vector2(GameResolution.DefaultWidth / 2, GameResolution.DefaultHeight),
                    ImageAddresses.HorizontalWall,
                    ObjectType.Wall,
                    Color.DarkCyan,
                    1f,
                    0f,
                    1f
                );
            SceneManager.AddObject(bottomWall);

            Wall rightWall = (Wall)StaticObjectFactory.Instance.Create(
                    new Vector2(0, GameResolution.DefaultHeight),
                    ImageAddresses.VerticalWall,
                    ObjectType.Wall,
                    Color.DarkCyan,
                    1f,
                    0f,
                    1f
                );
            SceneManager.AddObject(rightWall);

            Wall leftWall = (Wall)StaticObjectFactory.Instance.Create(
                   new Vector2(GameResolution.DefaultWidth, GameResolution.DefaultHeight),
                   ImageAddresses.VerticalWall,
                   ObjectType.Wall,
                   Color.DarkCyan,
                   1f,
                   0f,
                   1f
               );
            SceneManager.AddObject(leftWall);
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                EntryPoint.TheGame.Exit();
            }
        }
    }
}