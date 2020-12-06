using System;


    public class Match
    {
        private UInt32 matchID;
        private bool isStarted;
        private bool isEnded;

        public Match(UInt32 matchId, bool isStarted)
        {
            matchID = matchId;
            this.isStarted = isStarted;
        }

        public UInt32 MatchId => matchID;

        public bool IsStarted => isStarted;
    }
