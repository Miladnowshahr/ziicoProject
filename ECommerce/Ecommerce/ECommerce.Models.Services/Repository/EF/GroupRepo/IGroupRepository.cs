using ECommerce.Models.Model.Products.Groups;
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

        void Update(Group group);

        Task<IEnumerable<Group>> GetGroupsAsync();

        Task DeleteAsync(Group group);

        Task SaveAsync();

    }
}
