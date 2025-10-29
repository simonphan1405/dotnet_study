using ConsoleApp;

var rand = new Random();

Animal animal = GetRandomAnimal(rand.Next(0, 3));

Animal animalA = new Bird();
Bird birdA = (Bird)animalA; // Downcasting

static Animal GetRandomAnimal(int id)
{
    switch (id)
    {
        case 0:
            return new Dog();
        case 1:
            return new Bird();
        default:
            return new Fish();
    }
}

animal.Move(); // Output: Dog is running
animalA.A();   // Output: Animal.A
birdA.A();  // Output: Bird.A