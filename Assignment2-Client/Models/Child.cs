using System.Collections.Generic;

namespace Assignment2_Client.Models {
public class Child : Person {
    public Child()
    {
        Interests = new List<Interest>();
        Pets = new List<Pet>();
    }
    
    public List<Interest> Interests { get; set; }
    public List<Pet> Pets { get; set; }
}
}