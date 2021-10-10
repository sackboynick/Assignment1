namespace Models {
public class Interest {
    public Interest(string interestType, string interestDescription)
    {
        Type = interestType;
        Description = interestDescription;
    }

    public Interest()
    {
        Type = "";
        Description = "";
    }

    public string Type { get; set; }
    public string Description { get; set; }

    public override string ToString()
    {
        return Type + ": " + Description;
    }
}
}