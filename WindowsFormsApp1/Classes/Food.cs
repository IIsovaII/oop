namespace WindowsFormsApp1
{
    public class Food
    {
        int weight;
        int weightLimit;

        public int Weight { get => weight; set => weight = value; }
        public int WeightLimit { get => weightLimit; set => weightLimit = value; }
    }

    public class Fishes : Food
    {
        public Fishes()
        {
            Weight = 2;
            WeightLimit = 30;
        }
    }

    public class Rats : Food
    {
        public Rats()
        {
            Weight = 3;
            WeightLimit = 27;
        }
    }

    public class Bugs : Food
    {
        public Bugs()
        {
            Weight = 5;
            WeightLimit = 45;
        }
    }

    public class Worms : Food
    {
        public Worms()
        {
            Weight = 7;
            WeightLimit = 21;
        }
    }

    public class Birds : Food
    {
        public Birds()
        {
            Weight = 1;
            WeightLimit = 30;
        }
    }

    public class Humsters : Food
    {
        public Humsters()
        {
            Weight = 6;
            WeightLimit = 36;
        }
    }
}
