using ClassLibraryLab10;
namespace Lab13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyObservableCollection <Animals> Collection1 = new MyObservableCollection<Animals> ("Collection1", 10);
            MyObservableCollection<Animals> Collection2 = new MyObservableCollection<Animals>("Collection2", 10);

            Journal journal1 = new Journal();
            Journal journal2 = new Journal();

            Collection1.CollectionCountChanged += journal1.AddToJournal;
            Collection1.CollectionReferenceChanged += journal1.AddToJournal;
            Collection2.CollectionReferenceChanged += journal2.AddToJournal;
            Collection1.CollectionReferenceChanged += journal2.AddToJournal;

            Animals animals = new Animals();
            for (int i = 0; i < 5; i++)
            {
                Animals animal = new Animals();
                animal.RandomInit();
                Collection1.Add(animal);
            }

            for (int i = 0; i < 5; i++)
            {
                Animals animal = new Animals();
                animal.RandomInit();
                Collection2.Add(animal);
            }
            animals = new Animals();

            Console.WriteLine("Первая коллекция:");
            Collection1.Print();
            Console.WriteLine("Вторая коллекция:");
            Collection2.Print();

            Collection1.Add(animals);
            Collection2.Add(animals);
            Collection1.Remove(animals);

            Collection1[0] = animals;
            Collection2[0] = animals;
            Collection2[1] = animals;
            Console.WriteLine("Первый журнал");
            journal1.PrintJournal();
            Console.WriteLine("Второй журнал");
            journal2.PrintJournal();
        }
    }
}
