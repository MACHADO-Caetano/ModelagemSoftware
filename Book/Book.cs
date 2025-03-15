public class Book{
   public string Tittle;
  
   public string Author;


   public int PublicateDate;


   public Book(string tittle, string author, int publicateDate)
   {
       this.Tittle = tittle;
       this.Author = author;
       this.PublicateDate = publicateDate;
   }


   public void showInformations()
   {
       System.Console.WriteLine($"Tittle: {Tittle}, Author: {Author}, Publicate date: {PublicateDate} ");
   }

}
