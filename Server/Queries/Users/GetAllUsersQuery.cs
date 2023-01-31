using MediatR;
using server.Models.DTO;

namespace server.Queries;

public class GetAllUsersQuery : IRequest<ICollection<GetUsersDto>>{}
