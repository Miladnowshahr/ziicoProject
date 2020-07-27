using ECommerce.Models.Models.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.Services.Repository.EF.TagRepo
{
    public interface ITagRepository
    {

        Task AddAsync(Tag tag );
        Task SaveAsync();
        Task<Tag> GetTagAsync(int id);

        Task<IEnumerable<Tag>> GetTagsAsync(int? id, string title);
        
        void Update(Tag tag);

        Task Remove(int id);
    }
}
