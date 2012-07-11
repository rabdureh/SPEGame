﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Testgame
{
    class Levels
    {
        Speed speed;
        ComputerPlayer computer;
        int _level;
        Card[] deck;
        Drawable _background;
        Texture2D _selector;
        SpriteFont _font;
        public readonly Player _player1;
        List<Texture2D> _particles;
        SoundEffect shuffling;
        SoundEffect playingCard;
        SoundEffectInstance shuffleInstance;
        bool isSoundOn;
        bool isPowerUpOn;
        Timer timer;
        public bool isHalted { get; set; }
        public bool isPaused { get; set; }
        public LevelState myState { get; set; }
        public bool isShaking { get; set; }
        Difficulty myDiff;
        PowerUp freeze;

        public enum LevelState
        {
            Starting,
            PlayAgain,
            Playing,
        }

        public enum Difficulty
        {
            Easy,
            Medium,
            Hard
        }
        
        // constructor, makes instance of the computer player and initializes global variables based on arguments
        public Levels(Card[] deckOfCards, Drawable background, Texture2D selector, SpriteFont font, Player player1, List<Texture2D> particles, SoundEffect shuffling, SoundEffect playingcard, SoundEffectInstance shuffinstance, bool isSoundOn, bool powerUpsOn, Difficulty difficulty, PowerUp powerup)
        {
            computer = new ComputerPlayer("Computer", false);
            deck = deckOfCards;
            _background = background;
            _selector = selector;
            _font = font;
            _player1 = player1;
            _particles = particles;
            this.shuffling = shuffling;
            this.playingCard = playingcard;
            shuffleInstance = shuffinstance;
            this.isSoundOn = isSoundOn;
            isPowerUpOn = powerUpsOn;
            _level = 1;
            myState = LevelState.Starting;
            myDiff = difficulty;
            freeze = powerup;
        }

        // start game method
        public void StartGame()
        {
            // resets players, initializes to level 1, sets levelstate to playing
            _player1.Reset();
            computer.Reset();
            if (myState == LevelState.Starting) _level = 1;
            myState = LevelState.Playing;

            // switches computers timedelay based on difficulty of game
            switch (myDiff)
            {
                case Difficulty.Easy:
                    computer.timeDelay = .9f - (.027f * _level);
                    break;
                case Difficulty.Medium:
                    computer.timeDelay = .6f - (.03f * _level);
                    break;
                case Difficulty.Hard:
                    computer.timeDelay = .43f - (.025f * _level);
                    break;
            }

            // makes new instance of speed between computer and player
            speed = new Speed(deck, _background, _selector, _font, _player1, computer, _particles, Speed.gameType.Levels, shuffling, playingCard, shuffleInstance, isSoundOn, isPowerUpOn, freeze);

            // sets level to level, turns speed on, makes player's state the playing state
            speed.level = _level;
            speed.TurnOn();
            myState = LevelState.Playing;
            // if player wins game, halts speed, increases level, and starts new game
            speed.YouWon += delegate() { speed.isHalted = true; timer = new Timer(1); timer.SetTimer(0, 2, delegate() { _level++; StartGame(); }); };
            // if player loses game, calls loser method, which prompts player to start new game or exit
            speed.YouLost += delegate() { speed.isHalted = true; timer = new Timer(1); timer.SetTimer(0, 2, delegate() { Loser(); }); };
            // if player ties computer, restarts game on the same level
            speed.YouTie += delegate() { speed.isHalted = true; timer = new Timer(1); timer.SetTimer(0, 2, delegate() { StartGame(); }); };
        }

        // method that changes level state to play again state, for use when human loses
        public void Loser()
        {
            myState = LevelState.PlayAgain;
        }

        // method to halt speed
        public void Halt()
        {
            speed.isHalted = true;
        }

        // method to un-halt speed
        public void Resume()
        {
            speed.isHalted = false;
        }

        // toggles paused version or resumed version of speed
        public void Pause()
        {
            speed.isPaused = true;
        }

        // if speed or timer not null, updates these
        public void Update(GameTime gameTime)
        {
            if (speed != null)
            {
                speed.Update(gameTime);
                isShaking = speed.isShaking;
            }
            if (timer != null) timer.Update(gameTime);

        }

        // if speed not null, draws speed 
        public void Draw(SpriteBatch spriteBatch)
        {
            if (speed != null) speed.Draw(spriteBatch);
        }

    }
}
