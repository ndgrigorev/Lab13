using ClassLibraryLab10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class Journal
    {
        List<JournalEntry> entries = new List<JournalEntry>();

        public int LengthOfJournal
        {
            get { return entries.Count; }
        }

        public void AddToJournal(object source, CollectionHandlerEventArgs args)
        {
            JournalEntry entry = new JournalEntry(args.Name, args.TypeOfChange, args.ObjectChange.ToString());
            entries.Add(entry);
        }

        public void PrintJournal()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("Журнал пустой");
                return;
            }
            foreach (JournalEntry entry in entries)
            {
                Console.WriteLine(entry);
            }
        }
    }

    internal class JournalEntry
    {
    
        public string CollectionName { get; set; }
        public string TypeOfChange { get; set; }
        public string ObjectInfo { get; set; }
        public JournalEntry(string collectionName, string typeOfChange, string objectInfo) 
        {
            CollectionName = collectionName;
            TypeOfChange = typeOfChange;
            ObjectInfo = objectInfo;
        }

        public override string ToString()
        {
            return $"Изменение в коллекции {CollectionName}, тип изменения: {TypeOfChange}, объект с которым связано изменение: {ObjectInfo}";
        }
    }
}
