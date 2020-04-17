using ECommerce.Models.Model.Products.Groups;
using ECommerce.Models.Model.Products.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.Services.Repository.EF.GroupRepo
{
    public interface IGroupRepository
    {
        Task AddAsync(Group group);

        Task<Group> GetGroupAsync(int id);

        Task Update(Group group);

        Task<IEnumerable<Group>> GetGroupsAsync(int? id, string title, string slug, State? state);

        Task DeleteAsync(int id);

        Task SaveAsync();

    }
}
