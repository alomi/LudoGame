namespace Ludo.LogicLayer
{
    class Game
    {
        private GameStateManager gsm;
        
        public Game()
        {
            Init();
        }

        public void Init()
        {
            gsm = new GameStateManager();
            Run();

        }

        public void Run()
        {
            /*while (true)
            {
                Update();
            }*/
        }

        public void Update()
        {
            gsm.Update();
        }

        public GameStateManager GetGsm()
        {
            return gsm;
        }

        public void SetGsm(GameStateManager gsm)
        {
            this.gsm = gsm;
        }

    }
}
