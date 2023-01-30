using MediatR;
using server.Models.DTO;

public class GetUserByNameQuery : IRequest<GetUsersDto>
{ 
    public string Name { get; set; }
    public GetUserByNameQuery(string aName)
    {
        Name = aName;
    }
}