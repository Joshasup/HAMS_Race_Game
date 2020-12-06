using System;

    public class Profile
    {
        private string username = "";
        private int wins = 0;
        private int losses = 0;

        public Profile(string username, string wins, string losses)
        {
            this.username = username;
            this.wins = Int32.Parse(wins);
            this.losses = Int32.Parse(losses);
        }

        public string Username
        {
            get => username;
            set => username = value;
        }

        public int Wins
        {
            get => wins;
            set => wins = value;
        }

        public int Losses
        {
            get => losses;
            set => losses = value;
        }
    }
