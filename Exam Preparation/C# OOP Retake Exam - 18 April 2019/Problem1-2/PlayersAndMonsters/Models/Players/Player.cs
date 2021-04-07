﻿using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private ICardRepository cardRepository;

        public Player(ICardRepository cardRepository, string username, int health)
        {
            this.Username = username;
            this.Health = health;
            this.cardRepository = cardRepository;
        }
        public ICardRepository CardRepository => cardRepository;

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string.");
                }
                this.username = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set //it is public
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero. ");
                }
                this.health = value;
            }
        }

        public bool IsDead { get; private set; }

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }
            if (this.Health - damagePoints <= 0)
            {
                this.Health = 0;
                this.IsDead = true;
            }
            else
            {
                this.Health -= damagePoints;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Username: {this.Username} - Health: {this.Health} – Cards {this.CardRepository.Count}");
            foreach (var card in cardRepository.Cards)
            {
                sb.AppendLine(card.ToString());
            }
            sb.AppendLine("###");

            return sb.ToString().Trim();
        }
    }
}
