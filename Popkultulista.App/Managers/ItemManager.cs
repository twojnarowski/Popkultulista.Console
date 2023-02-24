using System.Text.Json.Serialization;
using Popkultulista.App.Abstract;
using Popkultulista.Core;
using Popkultulista.Core.Entity;
using Newtonsoft.Json;

namespace Popkultulista.App.Managers
{
    public class ItemManager
    {
        private readonly IService<ListItem> itemService;

        private readonly List<string> types = new List<string>();

        public ItemManager(IService<ListItem> itemService)
        {
            this.itemService = itemService;
            Initialize();
        }

        private void Initialize()
        {
            this.types.Add(nameof(VideoGame));
            this.types.Add(nameof(TvShow));
            this.types.Add(nameof(Movie));
            this.types.Add(nameof(Book));
            LoadProgress();
        }
        public void SaveProgress(object sender, EventArgs e)
        {
            if (itemService.Items.Count > 0)
            {
                Directory.CreateDirectory(@"C:\Temp");
                File.Create(@"C:\Temp\items.txt").Close();
                using StreamWriter sw = new StreamWriter(@"C:\Temp\items.txt");
                using JsonWriter writer = new JsonTextWriter(sw);
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, itemService.Items);
            }
        }

        private void LoadProgress()
        {
            if(!File.Exists(@"C:\Temp\items.txt"))
            {
                return;
            }

            string jsonString = File.ReadAllText(@"C:\Temp\items.txt");
            List<ListItem> items = JsonConvert.DeserializeObject<List<ListItem>>(jsonString)!;
            if (itemService.Items.Count == 0 && items is not null)
            {
                foreach(var item in items)
                {
                    itemService.Items.Add(item);
                }
            }

        }

        public Guid AddNewItem()
        {
            Console.WriteLine("Podaj nazwę pozycji:");
            string? name = Console.ReadLine();
            if (name is null || name.Length == 0)
            {
                Console.WriteLine("Nie podano nazwy!");
                return Guid.Empty;
            }

            Console.WriteLine("Podaj typ pozycji:");
            foreach (string type in this.types)
            {
                Console.WriteLine($"{type}");
            }

            var line = Console.ReadLine();
            var selectedType = types.Where(x => x.Equals(line, StringComparison.InvariantCultureIgnoreCase));

            if (selectedType is null)
            {
                Console.WriteLine("Podano błędną opcję!");
                return Guid.Empty;
            }

            ListItem item = new ListItem(name, 0, 100, 100, 0, 0);

            return this.itemService.AddItem(item);
        }

        public void RemoveItem()
        {
            if (this.itemService.IsEmpty())
            {
                Console.WriteLine("Brak pozycji do usunięcia!");
                return;
            }

            Console.WriteLine("Wpisz nazwę pozycji do usunięcia:");
            foreach (ListItem item in this.itemService.GetAllItems())
            {
                Console.WriteLine($"{item.Name}");
            }

            var selectedItem = itemService.GetAllItems().FirstOrDefault(x => x.Name.Equals(Console.ReadLine(), StringComparison.InvariantCultureIgnoreCase));

            if (selectedItem is null)
            {
                Console.WriteLine("Podano błędną opcję!");
                return;
            }

            this.itemService.RemoveItem(selectedItem);
        }

        public void GetItem()
        {
            if (this.itemService.IsEmpty())
            {
                Console.WriteLine("Brak pozycji do wyświetlenia!");
                return;
            }

            Console.WriteLine("Wpisz nazwę pozycji do usunięcia:");
            foreach (ListItem item in this.itemService.GetAllItems())
            {
                Console.WriteLine($"{item.Name}");
            }

            var selectedItem = itemService.GetAllItems().FirstOrDefault(x => x.Name.Equals(Console.ReadLine(), StringComparison.InvariantCultureIgnoreCase));

            if (selectedItem is null)
            {
                Console.WriteLine("Podano błędną opcję!");
                return;
            }

            Console.WriteLine($"Id: {selectedItem.Id}");
            Console.WriteLine($"Nazwa: {selectedItem.Name}");
            Console.WriteLine($"FomoScore: {selectedItem.FomoScore}");
            Console.WriteLine($"Type: {selectedItem.GetType()}");
        }
    }
}