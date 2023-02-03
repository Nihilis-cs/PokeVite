namespace server.models.DTO;
public class CreateCollectionDto
{
    public string Name {get; set;} = null!;
    public string? Description {get; set;}
    public string UserId {get; set;} = null!;

}