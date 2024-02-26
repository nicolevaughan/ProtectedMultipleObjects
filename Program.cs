using System.ComponentModel.Design;

namespace ProtectedMultipleObjects
{
    //Base Class
    class ThingsToSell
    {
        protected int _Id;
        protected string _NameOfItem;
        protected string _ConditionOfItem;
        protected int _PriceOfItem;

        // default constructor
        public ThingsToSell()
        {
            _Id = 0;
            _NameOfItem = string.Empty;
            _ConditionOfItem = string.Empty;
            _PriceOfItem = 0;
        }
        // parameterized constructor
        public ThingsToSell(int id, string nameOfItem, string conditionOfItem, int priceOfItem)
        {
            _Id = id;
            _NameOfItem = nameOfItem;
            _ConditionOfItem = conditionOfItem;
            _PriceOfItem = priceOfItem;
        }
        // Get and Set Methods- Not needed for Protected
        //public int getId() { return _Id; }
        //public string getNameOfItem() { return _NameOfItem; }
        //public string getConditionOfItem() { return _ConditionOfItem; }
        //public int getPriceOfItem() { return _PriceOfItem; }
        //public void setId(int id) { _Id = id; }
        //public void setNameOfItem(string nameOfItem) { _NameOfItem = nameOfItem; }
        //public void setConditionOfItem(string conditionOfItem) { _ConditionOfItem = conditionOfItem; }
        //public void setPriceOfItem(int priceOfItem) { _PriceOfItem = priceOfItem; }

        public virtual void addChange()
        {
            Console.Write($"ID=");
            _Id=int.Parse(Console.ReadLine());
            Console.Write("Name of Item for Sale=");
            _NameOfItem = Console.ReadLine();
            Console.Write("Condition of Item for Sale=");
            _ConditionOfItem=Console.ReadLine();
            Console.Write("Price of Item for Sale=");
            _PriceOfItem=int.Parse(Console.ReadLine());
        }
        public virtual void print()
        {
            Console.WriteLine();
            Console.WriteLine($"ID: {_Id}");
            Console.WriteLine($"Name of Item for Sale: {_NameOfItem}");
            Console.WriteLine($"Condition of Item for Sale: {_ConditionOfItem}");
            Console.WriteLine($"Price of Item for Sale: ${_PriceOfItem}");
        }

    }
    class ThingsToSellInStore : ThingsToSell
    {
        private int _SalePrice;
        private string _Location;

        public ThingsToSellInStore()
            : base()
        {
            _SalePrice = 0;
            _Location = string.Empty;
        }
        public ThingsToSellInStore(int id, string nameOfItem, string conditionOfItem, int priceOfItem, int salePrice, string location)
            : base(id, nameOfItem, conditionOfItem, priceOfItem)
        {
            _SalePrice = salePrice;
            _Location = location;
        }
        public void setSalePrice(int salePrice) { _SalePrice = salePrice; }
        public void setLoacation(string location) { _Location = location; }
        public int getSalePrice() { return _SalePrice; }
        public string getLocation() { return _Location; }
        public override void addChange()
        {
            base.addChange();
            Console.Write("Sale Price=");
            setSalePrice(int.Parse(Console.ReadLine()));
            Console.Write("Location=");
            setLoacation(Console.ReadLine());
        }
        public override void print()
        {
            base.print();
            Console.WriteLine($"Sale Price of Item: ${getSalePrice()}");
            Console.WriteLine($"Location of Item: {getLocation()}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many items do you want to sell?");
            int maxItems;
            while (!int.TryParse(Console.ReadLine(), out maxItems))
                Console.WriteLine("Please enter a whole number");
            // array of ItemsForSale objects
            ThingsToSell[] items = new ThingsToSell[maxItems];
            Console.WriteLine("How many items do you want to sell in-store?");
            int maxItemsInStore;
            while (!int.TryParse(Console.ReadLine(), out maxItemsInStore))
                Console.WriteLine("Please enter a whole number");
            // array of ThingsToSellInStore
            ThingsToSellInStore[] itemsInStore = new ThingsToSellInStore[maxItemsInStore];

            int choice, rec, type;
            int itemsCounter = 0; int itemsInStoreCounter = 0;
            choice = Menu();
            while (choice != 4)
            {
                Console.WriteLine("Enter 1 for Item to sell in-store or 2 for online");
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("1 for Item to sell in-store or 2 for online");
                try
                {
                    switch (choice)
                    {
                        case 1: //Add
                            if (type == 1) //ThingsToSellInStore
                            {
                                if (itemsInStoreCounter <= maxItemsInStore)
                                {
                                    itemsInStore[itemsInStoreCounter] = new ThingsToSellInStore(); //places an object in the array instead of null
                                    itemsInStore[itemsInStoreCounter].addChange();
                                    itemsInStoreCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of items to sell in-store have been added");
                            }
                            else //ThingsToSell
                            {
                                if (itemsCounter <= maxItems)
                                {
                                    items[itemsCounter] = new ThingsToSell(); //places an object in the array instead of null
                                    items[itemsCounter].addChange();
                                    itemsCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of items to sell have been been added");
                            }
                            break;
                        case 2: //Change
                            Console.WriteLine("Enter the record number you want to change: ");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.WriteLine("Enter the record number you want to change: ");
                            rec--; //subtract 1 because arrya index begins at 0
                            if (type == 1) //ThingsToSellInStore
                            {
                                while (rec > itemsInStoreCounter - 1 || rec < 0)
                                {
                                    Console.WriteLine("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record numer you want to change: ");
                                    rec--;
                                }
                                itemsInStore[rec].addChange();
                            }
                            else //ThingsToSell
                            {
                                while (rec > itemsCounter - 1 || rec < 0)
                                {
                                    Console.WriteLine("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec)) ;
                                    Console.WriteLine("Enter the record number you want to change: ");
                                    rec--;
                                }
                                items[rec].addChange();
                            }
                            break;
                        case 3: //Print All
                            if (type == 1) //ThingsToSellInStore
                            {
                                for (int i = 0; i < itemsInStoreCounter; i++)
                                    itemsInStore[i].print();
                            }
                            else //ThingsToSell
                            {
                                for (int i = 0; i < itemsCounter; i++)
                                    items[i].print();
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                choice = Menu();
            }
        }
        private static int Menu()
        {
            Console.WriteLine("Please make a selection from the menu");
            Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            return selection;
        }
    }
}