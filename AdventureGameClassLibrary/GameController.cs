namespace AdventureGameClassLibrary
{
    public class GameController
    {
        public Game game;
        public GameController()
        {
            
        }

        public String GetFightSummary()
        {
            if(game.PlayerWonFight)
            {
                return $"{game.PlayerCharacter.Name} won the fight, earned 200XP and {game.MonsterCharacter.Gold} golds";
            }
            else
            {
                return $"{game.MonsterCharacter.Name} won the fight";
            }
        }

        public void StartNewGameOrJustGetNewMonster()
        {
            if (game.GameIsFinished) { CreateGame(); }
            else
            {
                game.GenerateRandomMonsterCharacter();
                game.FightIsFinished = false;
                game.PlayerWonFight = false;
                game.MonsterWonFight = false;
            }
        }

        public void PlayRound()
        {
            game.PlayRound();
        }

        public string GetRoundStatus()
        {
            return game.GetRoundStatus();   
        }

        public void CreateGame()
        {
            game = new Game();
        }

        public Boolean GameIsFinished()
        {
            return game.GameIsFinished;
        }

        public Boolean FightIsFinished()
        {
            return game.FightIsFinished;
        }

        public PlayerCharacter GetPlayer()
        {
            return game.PlayerCharacter;
        }

        public MonsterCharacter GetMonster()
        {
            return game.MonsterCharacter;
        }
    }
}
