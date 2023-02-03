namespace server.models.DTO;
public class GetCollectionListDto
{
    public string Name {get; set;} = null!;
    public string? Description {get; set;}
    public string UserId {get; set;} = null!;
    public string ColId {get; set;} = null!;

}