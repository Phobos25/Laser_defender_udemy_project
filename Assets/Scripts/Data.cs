public class Data {

    #region Singleton
    // keep constructor private
    private Data()
        {
        }

        static private Data _instance;
        static public Data instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Data();
                return _instance;
            }
        }
    #endregion 

    //if 2nd player is enabled
    public bool TwoPlayerEnabled;

    public int StageNumber;

    public int Player1Health;

    public int Player2Health;
}
