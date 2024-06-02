using System.Collections.ObjectModel;
using Lab13;
using ClassLibraryLab10;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MyObservableCollection<Animals> Collection1 = new MyObservableCollection<Animals>("Collection1", 10);
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

            Collection1.Add(animals);
            Collection2.Add(animals);
            Collection1.Remove(animals);

            Collection1[0] = animals;
            Collection2[0] = animals;
            Collection2[1] = animals;
            Assert.AreEqual(8, journal1.LengthOfJournal);
            Assert.AreEqual(3, journal2.LengthOfJournal);
        }
    }
}