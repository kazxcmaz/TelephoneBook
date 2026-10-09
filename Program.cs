using System;
using System.IO;

if (!File.Exists("contacts.txt"))
{
    File.Create("contacts.txt").Close();
}

List<Contacts> contacts = new List<Contacts>();
string[] text = File.ReadAllLines("contacts.txt");
foreach (string line in text)
{
    string[] blocks = line.Split('|');
    Contacts c = new Contacts();
    c.Name = blocks[0];
    c.LastName = blocks[1];
    c.Phone = blocks[2];
    c.Email = blocks[3];
    contacts.Add(c);
}
int Mainchoice;
    while (true)
    {
        Console.WriteLine("=== Телефонная книга ===");
        Console.WriteLine("1. Показать все контакты");
        Console.WriteLine("2. Добавить контакт");
        Console.WriteLine("3. Удалить контакт");
        Console.WriteLine("4. Найти контакт");
        Console.WriteLine("5. Выход");
        Console.WriteLine("========================");
        if (int.TryParse(Console.ReadLine(), out Mainchoice))
        {
            switch (Mainchoice)
            {
                case 1:
                    {
                    Console.WriteLine("=== Контакты ===");
                    Outputting();
                    break;
                    }
                case 2:
                    {
                    Console.WriteLine("=== Добавление нового контакта ===");
                    Contacts c = new Contacts();
                    Console.Write("Имя: ");
                    c.Name = Console.ReadLine();
                    Console.Write("Фамилия: ");
                    c.LastName = Console.ReadLine();
                    Console.Write("Номер телефона: ");
                    c.Phone = Console.ReadLine();
                    Console.Write("Почта: ");
                    c.Email = Console.ReadLine();
                    contacts.Add(c);
                    Save();
                    break;
                    }
                case 3:
                    {
                    Console.WriteLine("=== Удаление контакта ===");
                    Outputting();
                    Console.WriteLine("=========================");
                    Console.WriteLine("Введите номер контакта из списка");
                    Console.Write("Номер: ");
                    int SubChoice;
                    if (int.TryParse(Console.ReadLine(), out SubChoice))
                    {
                        if (SubChoice <= contacts.Count() && SubChoice != 0)
                        {
                            contacts.RemoveAt(SubChoice - 1);
                            Save();
                        }
                        else
                        {
                            Console.WriteLine("Номер отсутствует");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка, введите номер");
                    }
                    break;
                    }
                case 4:
                    {
                    int SubChoice2;
                    Console.WriteLine("=== Поиск контакта ===");
                    Console.WriteLine("1. Поиск по имени");
                    Console.WriteLine("2. Поиск по фамилии");
                    Console.WriteLine("3. Поиск по номеру");
                    Console.WriteLine("4. Посик по почте");
                    Console.WriteLine("======================");
                    if (int.TryParse(Console.ReadLine(),out SubChoice2))
                    {
                        switch (SubChoice2)
                        {
                            case 1:
                                {
                                    Console.Write("Имя: ");
                                    string name = Console.ReadLine();
                                    bool found = false;
                                    for (int i = 0; i < contacts.Count(); i++)
                                    {
                                        if (contacts[i].Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                                        {
                                            Console.WriteLine($"{i + 1}. {contacts[i].Name} {contacts[i].LastName} | Номер телефона: {contacts[i].Phone} | Почтовый адрес: {contacts[i].Email}");
                                            found = true;
                                        }
                                    }
                                    if (!found)
                                    {
                                        Console.WriteLine("Не найдено");
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    Console.Write("Фамилия: ");
                                    string lastname = Console.ReadLine();
                                    bool found = false;
                                    for (int i = 0; i < contacts.Count(); i++)
                                    {
                                        if (contacts[i].LastName.Contains(lastname, StringComparison.OrdinalIgnoreCase))
                                        {
                                            Console.WriteLine($"{i + 1}. {contacts[i].Name} {contacts[i].LastName} | Номер телефона: {contacts[i].Phone} | Почтовый адрес: {contacts[i].Email}");
                                            found = true;
                                        }

                                    }
                                    if (!found)
                                    {
                                        Console.WriteLine("Не найдено");
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    Console.Write("Имя: ");
                                    string phone = Console.ReadLine();
                                    bool found = false;
                                    for (int i = 0; i < contacts.Count(); i++)
                                    {
                                        if (contacts[i].Phone.Contains(phone, StringComparison.OrdinalIgnoreCase))
                                        {
                                            Console.WriteLine($"{i + 1}. {contacts[i].Name} {contacts[i].LastName} | Номер телефона: {contacts[i].Phone} | Почтовый адрес: {contacts[i].Email}");
                                            found = true;
                                        }
                                    }
                                    if (!found)
                                    {
                                        Console.WriteLine("Не найдено");
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    Console.Write("Имя: ");
                                    bool found = false;
                                    string email = Console.ReadLine();
                                    for (int i = 0; i < contacts.Count(); i++)
                                    {
                                        if (contacts[i].Email.Contains(email, StringComparison.OrdinalIgnoreCase))
                                        {
                                            Console.WriteLine($"{i + 1}. {contacts[i].Name} {contacts[i].LastName} | Номер телефона: {contacts[i].Phone} | Почтовый адрес: {contacts[i].Email}");
                                            found= true;
                                        }
                                    }
                                    if (!found)
                                    {
                                        Console.WriteLine("Не найдено");
                                    }
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Ошибка, выберите из списка");
                                    break;
                                }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка, введите число");
                    }
                    break;
                    }
                case 5:
                    {
                        Console.WriteLine("Выходим");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Ошибка");
                        break;
                    }
            }
        }
        else
        {
            Console.WriteLine("Ошибка, введите число");
        }
        if (Mainchoice == 5) break;
    }

void Save()
{
    File.WriteAllText("contacts.txt", "");
    for (int i = 0; i < contacts.Count; i++)
    {
        File.AppendAllText("contacts.txt", $"{contacts[i].Name}|{contacts[i].LastName}|{contacts[i].Phone}|{contacts[i].Email} \n");
    }
}
void Outputting()
{
    for (int i = 0; i < contacts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {contacts[i].Name} {contacts[i].LastName} | Номер телефона: {contacts[i].Phone} | Почтовый адрес: {contacts[i].Email}");
    }
}
class Contacts
{
    public string Name;
    public string LastName;
    public string Phone;
    public string Email;
}