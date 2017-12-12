namespace Ludo.LogicLayer
{
    abstract class GameState
    {
        protected GameStateManager gsm;

        public GameState(GameStateManager gsm) => this.gsm = gsm;

        public abstract void Init();
        public abstract void Update();
    }
}
