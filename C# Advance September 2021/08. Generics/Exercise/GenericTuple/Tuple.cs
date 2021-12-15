namespace GenericTuple
{
    public class Tuple<T, V>
    {
        private  T firstItem;

        private  V secondItem;

        public Tuple(T first, V second)
        {
            FirstItem = first;
            SecondItem = second;
        }

        public T FirstItem 
        { 
            get => firstItem;
            set => firstItem = value;
        }

        public V SecondItem
        {
            get => secondItem;
            set => secondItem = value;
        }

        public override string ToString() => $"{firstItem} -> {secondItem}";
    }
}
