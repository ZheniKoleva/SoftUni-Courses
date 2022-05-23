namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Task 1
            //Dog dog = new Dog();
            //dog.Bark();
            //dog.Bark();

            //Task 2
            Puppy puppy = new Puppy();
            puppy.Eat();
            puppy.Bark();
            puppy.Weep();


            //Task 3
            Dog dog = new Dog();
            dog.Eat();
            dog.Bark();

            Cat cat = new Cat();
            cat.Eat();
            cat.Meow();

        }
    }
}
