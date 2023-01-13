using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UAS_152
{
    class Node
    {
        public int itemID,itemprice;
        public string name, itemType;
        public Node next;
        public Node prev;
    }

    class DoubleLinkedList
    {
        Node start;
        public void addNode()
        {
            int ID,price;
            string nam, tyepit;
            Console.WriteLine("\n Enter Item ID :");
            ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n Enter Item name");
            nam = Console.ReadLine();
            Console.WriteLine("\n Enter Item Type ");
            tyepit = Console.ReadLine();
            Console.WriteLine("\n Enter Item price");
            price = Convert.ToInt32(Console.ReadLine());
            Node newNode = new Node();
            newNode.itemID = ID;
            newNode.name = nam;
            newNode.itemType = tyepit;
            newNode.itemprice = price;

            if (start == null || ID <= start.itemID)
            {
                if ((start != null) && (ID == start.itemID))
                {
                    Console.WriteLine("\n Duplicaite item number not allwoed");
                    return;
                }
                newNode.next = start;
                if (start != null)
                    start.prev = newNode;
                newNode.next = null;
                start = newNode;
                return;
            }

            Node previous, current;
            for (current = previous = start;
                current != null && ID >= current.itemID;
                previous = current, current = current.next)
            {
                if (ID == current.itemID)
                {
                    Console.WriteLine("\n Duplicate item numbers are not allowed");
                    return;
                }
            }

            newNode.next = current;
            newNode.prev = previous;


            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }


        public bool Searchbytyep(string tyepIT, ref Node previous, ref Node current)
        {
            previous = current = start;
            while (current != null && tyepIT != current.itemType)
            {
                previous = current;
                current = current.next;
            }
            return (current != null);
        }

        public bool Search(int idtem, ref Node previous, ref Node current)
        {
            previous = current = start;
            while (current != null && idtem != current.itemID)
            {
                previous = current;
                current = current.next;
            }
            return (current != null);
        }
        public bool delNode(int idtem)
        {
            Node previous, current;
            previous = current = null;
            if (Search(idtem, ref previous, ref current) == false)
                return false;

            if (current.next == null)
            {
                previous.next = null;
                return true;
            }

            if (current == start)
            {
                start = start.next;
                if (start != null)
                    start.prev = null;
                return true;
            }

            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        public void Displaybyprice()
        {
            if (ListEmpty())
                Console.WriteLine("\n List is empty");
            else
            {
                Console.WriteLine("\n Record in the ascending order of " + "Roll number are: \n");
                Node currentNode;
                for (currentNode = start; currentNode != null; currentNode = currentNode.next)
                    Console.WriteLine("Item ID :  " + currentNode.itemID + "\nItem Name is : " + currentNode.name + "\nItem type is :  " + currentNode.itemType + "\n" + "Item price :" + currentNode.itemprice + "\n");
            }
        }
        public void Displayall()
        {
            if (ListEmpty())
                Console.WriteLine("\n No Items found");
            else
            {
                Console.WriteLine("\n Displaying all items in order of Item Id: \n");
                Node currentNode;
                for (currentNode = start; currentNode != null; currentNode = currentNode.next)
                    Console.WriteLine("Item ID :  " + currentNode.itemID + "\nItem Name is : " + currentNode.name + "\nItem type is :  " + currentNode.itemType + "\n"+ "Item price :" + currentNode.itemprice  + "\n");
            }
        }


        public bool ListEmpty()
        {
            if (start == null)
                return true;
            else
                return false;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add an Item");
                    Console.WriteLine("2. Display all items by ID");
                    Console.WriteLine("3. Search for items by item type ");
                    Console.WriteLine("4. Delete an Item");
                    Console.WriteLine("5. Exit\n");
                    Console.WriteLine("Enter yor choice(1-5):");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                obj.Displayall();
                            }
                            break;
                        case '3':
                            {
                                if (obj.ListEmpty() == true)
                                {
                                    Console.WriteLine("\n There is no data");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the type you want:");
                                string num = Console.ReadLine();
                                if (obj.Searchbytyep(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nType not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nItem ID :" + curr.itemID);
                                    Console.WriteLine("\nItem Name :" + curr.name);
                                    Console.WriteLine("\nItem Price :" + curr.itemprice);
                                    Console.WriteLine("\nItem Type :" + curr.itemType);

                                }
                            }
                            break;
                        case '4':
                            {
                                if (obj.ListEmpty())
                                {
                                    Console.WriteLine("\nList is Empty");
                                    break;
                                }
                                Console.Write("\nEnter Item ID to delete");
                                int idtem = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(idtem) == false)
                                    Console.WriteLine("Item not found");
                                else
                                    Console.WriteLine("Item with ID " + idtem + " deleted\n");
                            }
                            break;
                        case '5':
                            Console.WriteLine("\nThanks for using my program");
                            Console.WriteLine("\nExiting . . .");
                            Thread.Sleep(2500);
                            return;                           
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Check for the values entered");
                }
            }
        }
    }
}


/*
 * 2 - I used DoubleLinkedList Because its famous for its fast proceesing for data.
 * 
 * 3- Array use a predeclared space for that reason the wiil waste memore if declarer and not used while lists grow with the size nedded when you input new data
 * 
 * 4- Rear ,front
 * 
 * 5 - A - 41 and 74 siblings , 
 * 
 * B- 16,25,41,53,46,42,55,
 * */



