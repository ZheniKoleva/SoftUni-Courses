namespace GenericThreeuple
{
    public class Threeuple<T, U, V>
    {
        private T firstItem;

        private U secondItem;

        private V thirdItem;

        public Threeuple(T first, U second, V third)
        {
            FirstItem = first;
            SecondItem = second;
            ThirdItem = third;
        }

        public T FirstItem
        {
            get => firstItem;
            set => firstItem = value;
        }

        public U SecondItem
        {
            get => secondItem;
            set => secondItem = value;
        }

        public V ThirdItem
        {
            get => thirdItem;
            set => thirdItem = value;
        }

        public override string ToString() => $"{firstItem} -> {secondItem} -> {thirdItem}";

    }
}
