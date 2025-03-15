public class Beach{
   public string Name:


   public string Location;


   public int Temperature;


   public bool HasKiosk;


   public Beach(string name, string location, int temperature, bool hasKiosk)
   {
       Name = name
       Location = location
       Temperature = temperature
       if(hasKiosk){
           HasKiosk = hasKiosk
           System.Console.WriteLine("Possui quiosque");
       }
       else{
           HasKiosk = hasKiosk
           System.Console.WriteLine("Não possui quiosque");
       }
      
   }


   public void showInformations()
   {
       System.Console.WriteLine($"Beach informations: {Name}, {Location}, {Temperature}, {HasKiosk}");
   }
}
