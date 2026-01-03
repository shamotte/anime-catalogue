namespace CichyStrzalko.MemoryGame.Interfaces
{
    public interface IDataAccesObkect
    {
        public void GetCards();

    }


    public interface ICard
    {
        public int Id { get; }
        public string Graphic   { get; }

        public int value { get; }

        public bool CompareCard(ICard other);

    }
}
