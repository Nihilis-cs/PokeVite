using MediatR;
using Microsoft.EntityFrameworkCore;
using server.models;

namespace server.Commands;

public class CreateCollectionCommandHandler : IRequestHandler<CreateCollectionCommand, string>
{
    private readonly PokeDbContext _DbContext;

    public CreateCollectionCommandHandler(PokeDbContext aDbContext) 
    {
        _DbContext = aDbContext;
    }
    public async Task<string> Handle(CreateCollectionCommand request, CancellationToken cancellationToken)
    {
        var vDto = request.Collection;
        var vUser = await _DbContext.Users.Where(u => u.Id == new Guid(vDto.UserId)).FirstAsync();

        var vNewCollection = new Collection(){Name = vDto.Name, Description = vDto.Description, User = vUser};
        await _DbContext.Collections.AddAsync(vNewCollection);
        await _DbContext.SaveChangesAsync();

        return vNewCollection.Id.ToString();
    }
}