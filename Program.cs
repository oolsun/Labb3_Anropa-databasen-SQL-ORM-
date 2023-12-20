using _3._Anropa_databasen__SQL___ORM_.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace _3._Anropa_databasen__SQL___ORM_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // When program starts, go to menu.StartMenu()
            Menu menu = new();
            menu.StartMenu();
        }
    }
}