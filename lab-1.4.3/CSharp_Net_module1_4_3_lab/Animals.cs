using System.Collections;

namespace CSharp_Net_module1_4_3_lab
{
    //6) implement interface IEnumerable
    class Animals : IEnumerable
    {
        // 7) declare private array of Animal
        public Animal[] strAnimal;
        // 8) declare parameter constructor to initialize array   
        public Animals(Animal[] AnimalName) {
            strAnimal = new Animal[AnimalName.Length];
            for (int i = 0; i < AnimalName.Length; i++) {
                strAnimal[i] = AnimalName[i];
            }
        }
        // 9) implement method GetEnumerator(), which returns IEnumerator
        // use foreach on array of Animal
        // and yield return for every animal
        public IEnumerator GetEnumerator()
        {
            foreach (Animal item in strAnimal) {
                yield return item;
            }
            
        }
    }
}
