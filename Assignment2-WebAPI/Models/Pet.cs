namespace Assignment2_WebAPI.Models {
public class Pet {
    public Pet(int petsCount, string petName, int petAge, string petSpecie)
    {
        Id = petsCount;
        Name = petName;
        Age = petAge;
        Species = petSpecie;
    }

    public Pet()
    {
        Id=-1;
        Species = "";
        Name = "";
        Age = 0;
    }

    public int Id { get; set; }
    public string Species { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return Name + ", a " + Species;
    }
}
}